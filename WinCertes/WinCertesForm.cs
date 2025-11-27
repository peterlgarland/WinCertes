using Certes.Acme;
using Microsoft.Web.Administration;
using NLog;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using WinCertes.ChallengeValidator;
using WinCertes.Config;

namespace WinCertes
{
    public partial class WinCertesForm : Form
    {
        private static readonly ILogger _logger = LogManager.GetLogger("WinCertes.WinCertesForm");

        SiteCollection Sites;
        Site IisSite;
        IConfig _config;
        int _extra = -1;
        WinCertesOptions _winCertesOptions;
        X509Certificate2 _cert = null;
        CertesWrapper _certesWrapper = null;
        readonly string _winCertesPath;
        readonly string _certTmpPath;
        bool _iisBound = false;

        public WinCertesForm()
        {
#if DEBUG
            //CultureInfo culture = CultureInfo.CreateSpecificCulture("fr-FR");
            //CultureInfo.DefaultThreadCurrentCulture = culture;
            //CultureInfo.DefaultThreadCurrentUICulture = culture;
            //Thread.CurrentThread.CurrentCulture = culture;
            //Thread.CurrentThread.CurrentUICulture = culture;
#endif

            (_winCertesPath, _certTmpPath) = Utils.InitWinCertesDirectoryPath();
            Utils.ConfigureLogger(_winCertesPath);
            InitializeComponent();
            SetupInterface();
        }

        private void SetupInterface()
        {
            this.Text = Resources.WinCertesForm.WinCertes;
            tabPage1.Text = Resources.WinCertesForm.Settings;
            tabPage2.Text = Resources.WinCertesForm.IISSettings;
            tabPage3.Text = Resources.WinCertesForm.Domains;
            tabPage4.Text = Resources.WinCertesForm.Extra;
            tabPage5.Text = Resources.WinCertesForm.Help;
            certButton.Text = Resources.WinCertesForm.ShowCertificate;
            revokeButton.Text = Resources.WinCertesForm.RevokeCertificate;
            configLabel.Text = Resources.WinCertesForm.Configuration;
            newConfigButton.Text = Resources.WinCertesForm.NewConfiguration;
            settingsGroupBox.Text = Resources.WinCertesForm.Settings;
            deleteButton.Text = Resources.WinCertesForm.Delete;
            emailLabel.Text = Resources.WinCertesForm.Email;
            serverLabel.Text = Resources.WinCertesForm.Server;
            serviceLabel.Text = Resources.WinCertesForm.Service;
            standaloneRadioButton.Text = Resources.WinCertesForm.Standalone;
            iisRadioButton.Text = Resources.WinCertesForm.IIS;
            standaloneGroupBox.Text = Resources.WinCertesForm.StandaloneSettings;
            portLabel.Text = Resources.WinCertesForm.ServerPort;
            checkPortButton.Text = Resources.WinCertesForm.CheckPort;
            challangeLabel.Text = Resources.WinCertesForm.StandaloneWarning;
            iisGroupBox.Text = Resources.WinCertesForm.IISSettings;
            webChallengeLabel.Text = Resources.WinCertesForm.WebRootChallange;
            siteBindingsLabel.Text = Resources.WinCertesForm.SiteBindings;
            iisCheckBox.Text = Resources.WinCertesForm.BindIISSite;
            sniCheckBox.Text = Resources.WinCertesForm.SNI;
            iisPortLabel.Text = Resources.WinCertesForm.IISPort;
            domainsGroupBox.Text = Resources.WinCertesForm.Domains;
            domainsLabel.Text = Resources.WinCertesForm.GenerateDomains;
            removeButton.Text = Resources.WinCertesForm.Remove;
            addButton.Text = Resources.WinCertesForm.Add;
            newDomainlabel.Text = Resources.WinCertesForm.NewDomain;
            taskGroupBox.Text = Resources.WinCertesForm.ScheduledTask;
            psGroupBox.Text = Resources.WinCertesForm.PowerShell;
            taskCheckBox.Text = Resources.WinCertesForm.ScheduleTaskAuto;
            renewLabel.Text = Resources.WinCertesForm.RenewalDelay;
            psScriptCheckBox.Text = Resources.WinCertesForm.ExecutePS;
            psExecCheckBox.Text = Resources.WinCertesForm.PSExecPolicy;
            browseButton.Text = Resources.WinCertesForm.Browse;
            helpTextBox.Text = Resources.WinCertesForm.HelpText;
        }


        /// <summary>
        /// Initializes the CertesWrapper, and registers the account if necessary
        /// </summary>
        /// <param name="config">the Configuration</param>
        /// <param name="serviceUri">the ACME service URI</param>
        /// <param name="email">the email account used to register</param>
        private async Task<bool> InitCertesWrapperAsync(IConfig config, string serviceUri, string email)
        {
            // We get the CertesWrapper object, that will do most of the job.
            _certesWrapper = new CertesWrapper(config, serviceUri, email);

            // If local computer's account isn't registered on the ACME service, we'll do it.
            if (!_certesWrapper.IsAccountRegistered())
            {
                actionToolStripStatusLabel.Text = Resources.WinCertesForm.RegisteringNewAccount;
                var regRes = await _certesWrapper.RegisterNewAccount();
                if (!regRes)
                    return false;
            }
            return true;

        }

        private async Task<bool?> RevokeCert(int revoke = 0)
        {
            actionToolStripStatusLabel.Text = Resources.WinCertesForm.GettingExistingCertificate;
            string serial = _config.ReadStringParameter("certSerial" + _winCertesOptions.DomainsHostId);
            if (serial == null)
                return null;

            actionToolStripStatusLabel.Text = Resources.WinCertesForm.RevokingCertificate;
            // Here we revoke from ACME Service. Note that any error is already handled into the wrapper
            if (await _certesWrapper.RevokeCertificate(_cert, revoke))
            {
                actionToolStripStatusLabel.Text = Resources.WinCertesForm.RemovingCertificate;
                WinCertesOptions.RemoveCertificateFromConfiguration(_cert, _config, _winCertesOptions.DomainsHostId);

                _cert = null;
                certButton.Visible = false;
                revokeButton.Visible = false;
                return true;
            }

            return false;

        }

        private async Task<bool?> IssueCert(List<string> domains, string taskName = null)
        {
            bool? result;

            actionToolStripStatusLabel.Text = Resources.WinCertesForm.GettingHTTPValidator;

            // Now the real stuff: we register the order for the domains, and have them validated by the ACME service
            IHTTPChallengeValidator httpChallengeValidator = HTTPChallengeValidatorFactory.GetHTTPChallengeValidator(_winCertesOptions.Standalone, _winCertesOptions.HttpPort, _winCertesOptions.WebRoot);

            // Not supporting DNS yet!
            // IDNSChallengeValidator dnsChallengeValidator = DNSChallengeValidatorFactory.GetDNSChallengeValidator(_config);
            IDNSChallengeValidator dnsChallengeValidator = null;
            // This should never show!
            if ((httpChallengeValidator == null) && (dnsChallengeValidator == null)) { MessageBox.Show(Resources.WinCertesForm.ErrorSpecifyHTTPorDNS, Resources.WinCertesForm.Error, MessageBoxButtons.OK, MessageBoxIcon.Exclamation); return false; }

            actionToolStripStatusLabel.Text = Resources.WinCertesForm.RegisteringNewOrder;
            if (!await _certesWrapper.RegisterNewOrderAndVerify(domains, httpChallengeValidator, dnsChallengeValidator))
            {
                actionToolStripStatusLabel.Text = Resources.WinCertesForm.ErrorFailedCleaningUp;
                if (httpChallengeValidator != null) httpChallengeValidator.EndAllChallengeValidations(); return false;
            }

            actionToolStripStatusLabel.Text = Resources.WinCertesForm.VerifiedCleaningUp;

            if (httpChallengeValidator != null)
            {
                httpChallengeValidator.EndAllChallengeValidations();
            }

            actionToolStripStatusLabel.Text = Resources.WinCertesForm.RetrievingCertificate;

            // We get the certificate from the ACME service
            var pfx = await _certesWrapper.RetrieveCertificate(domains, _certTmpPath, Utils.DomainsToFriendlyName(domains));
            if (pfx == null) return null;

            actionToolStripStatusLabel.Text = Resources.WinCertesForm.StoringCertificate;

            // Currently only supporting the default Csp
            CertificateStorageManager certificateStorageManager = new CertificateStorageManager(pfx, true);
            // Let's process the PFX into Windows Certificate objet.
            certificateStorageManager.ProcessPFX();
            // and we write its information to the WinCertes configuration
            WinCertesOptions.RegisterCertificateIntoConfiguration(certificateStorageManager.Certificate, domains, _config);
            // Import the certificate into the Windows store
            if (!_winCertesOptions.NoCsp) certificateStorageManager.ImportCertificateIntoCSP(_winCertesOptions.Csp);

            actionToolStripStatusLabel.Text = Resources.WinCertesForm.BindingCertificateIIS;

            // Bind certificate to IIS Site (won't do anything if option is null)
            if (Utils.BindCertificateForIISSite(certificateStorageManager.Certificate, _winCertesOptions.BindName, _winCertesOptions.BindPort, _winCertesOptions.Sni))
            {
                result = true;
                _logger.Info($"{Resources.WinCertesForm.SuccessBindIIS} {_winCertesOptions.BindName}");
            }
            else
            {
                result = string.IsNullOrEmpty(_winCertesOptions.BindName);
                _logger.Debug(Resources.WinCertesForm.NoBindIIS);
            }

            actionToolStripStatusLabel.Text = Resources.WinCertesForm.ExecutingPS;

            // Execute PowerShell Script (won't do anything if option is null)
            Utils.ExecutePowerShell(_winCertesOptions.ScriptFile, pfx, _winCertesOptions.ScriptExecutionPolicy);

            actionToolStripStatusLabel.Text = Resources.WinCertesForm.CreatingTaskIfRequired;

            // Create the AT task that will execute WinCertes periodically (won't do anything if taskName is null)
            Utils.CreateScheduledTask(taskName, domains, _extra);

            actionToolStripStatusLabel.Text = Resources.WinCertesForm.RemovingTemp;

            // Let's delete the PFX file
            Utils.RemoveFileAndLog(pfx);

            return result;
        }

        private bool AddDomain(string domain)
        {
            if (domainsListBox.Items.Contains(domain))
                return false;
            else
            {
                domainsListBox.Items.Add(domain);
                return true;
            }
        }
        private void MainForm_Load(object sender, EventArgs e)
        {
            PopulateSites();
            PopulateExecutionPolicies();
            PopulateServers();

            BindConfig();
        }

        private void BindConfig()
        {
            _winCertesOptions = new WinCertesOptions();
            _config = new RegistryConfig(_extra);
            _winCertesOptions.MiscOpts = new Dictionary<string, string>();
            _winCertesOptions.WriteOptionsIntoConfiguration(_config);
            _certesWrapper = null;
            _cert = null;
            configsComboBox.Items.Clear();
            domainsListBox.Items.Clear();
            sitesListBox.SelectedIndex = -1;
            bindingsListBox.Items.Clear();
            webRootLabel.Text = string.Empty;

            configsComboBox.Items.Add(Resources.WinCertesForm.DefaultConfiguration);

            if (_extra == -1)
            {
                deleteButton.Visible = false;
                configsComboBox.SelectedIndex = 0;
            }

            emailTextBox.Text = _winCertesOptions.Email;

            if (!string.IsNullOrEmpty(_winCertesOptions.ServiceUri))
            {
                if (serviceComboBox.Items.Contains(_winCertesOptions.ServiceUri))
                {
                    serviceComboBox.SelectedItem = _winCertesOptions.ServiceUri;
                }
                else
                {
                    serviceComboBox.SelectedText = _winCertesOptions.ServiceUri;
                }
            }

            if (_winCertesOptions.Standalone)
                standaloneRadioButton.Checked = true;
            else
                iisRadioButton.Checked = true;

            if (!string.IsNullOrEmpty(_winCertesOptions.ScriptFile))
            {
                psScriptTextBox.Text = _winCertesOptions.ScriptFile;
            }
            else
            {
                psScriptTextBox.Text = string.Empty;
            }

            psScriptCheckBox.Checked = _winCertesOptions.PsScript && !string.IsNullOrEmpty(psScriptTextBox.Text);

            if (!string.IsNullOrEmpty(_winCertesOptions.ScriptExecutionPolicy))
            {
                if (psExecComboBox.Items.Contains(_winCertesOptions.ScriptExecutionPolicy))
                {
                    psExecComboBox.SelectedItem = _winCertesOptions.ScriptExecutionPolicy;
                }
            }
            else
            {
                psExecComboBox.SelectedItem = "Undefined";
            }

            psExecCheckBox.Checked = _winCertesOptions.PsExecPolicy && psExecComboBox.Text != "Undefined";

            sniCheckBox.Checked = _winCertesOptions.Sni;
            taskCheckBox.Checked = !string.IsNullOrEmpty(_winCertesOptions.DomainsFriendlyName) && Utils.IsScheduledTaskCreated(_winCertesOptions.DomainsFriendlyName);
            iisPortNumericUpDown.Value = _winCertesOptions.BindPort == 0 ? 443 : _winCertesOptions.BindPort;
            httpPortNumericUpDown.Value = _winCertesOptions.HttpPort == 0 ? 80 : _winCertesOptions.HttpPort;
            renewalNumericUpDown.Value = _winCertesOptions.RenewalDelay == 0 ? 30 : _winCertesOptions.RenewalDelay;

            if (!string.IsNullOrEmpty(_winCertesOptions.CertSerial))
            {
                _cert = Utils.GetCertificateBySerial(_winCertesOptions.CertSerial);
                if (_cert != null)
                {
                    revokeButton.Visible = true;
                    certButton.Visible = true;
                    settingsGroupBox.Enabled = false;
                    domainsGroupBox.Enabled = false;
                    if (_winCertesOptions.IsCertificateToBeRenewed(_cert))
                    {
                        issueButton.Text = Resources.WinCertesForm.RenewCertificate;
                        issueButton.Enabled = true;
                    }
                    else
                    {
                        issueButton.Enabled = false;
                    }

                    var sans = Utils.ParseSubjectAlternativeName(_cert);
                    foreach (var san in sans)
                    {
                        AddDomain(san);
                    }
                }
            }
            else
            {
                settingsGroupBox.Enabled = true;
                domainsGroupBox.Enabled = true;
                revokeButton.Visible = false;
                certButton.Visible = false;
                issueButton.Enabled = false;
                issueButton.Text = Resources.WinCertesForm.IssueCertificate;
            }

            iisCheckBox.Checked = _winCertesOptions.BindSite;

            if (!string.IsNullOrEmpty(_winCertesOptions.BindName))
            {
                if (sitesListBox.Items.Contains(_winCertesOptions.BindName))
                {
                    sitesListBox.SelectedItem = _winCertesOptions.BindName;
                }
                if (_cert != null)
                {
                    issueButton.Text = Resources.WinCertesForm.UpdateSettings;
                    issueButton.Enabled = !_iisBound;
                }
            }

            var extras = _config.GetExtrasConfigParams();

            if (extras.Count > 0)
            {
                foreach (var item in extras)
                {
                    configsComboBox.Items.Add($"{Resources.WinCertesForm.ExtraConfiguration} {item}");
                    if (item == _extra)
                    {
                        configsComboBox.SelectedIndex = configsComboBox.Items.Count - 1;
                        deleteButton.Visible = true;
                    }
                }
            }

            CheckIssue();
        }

        private void PopulateServers()
        {
            serviceComboBox.Items.Add(Certes.Acme.WellKnownServers.LetsEncryptV2.ToString());
            serviceComboBox.Items.Add(Certes.Acme.WellKnownServers.LetsEncryptStagingV2.ToString());
            serviceComboBox.SelectedIndex = 0;
        }

        private void PopulateExecutionPolicies()
        {
            psExecComboBox.Items.Add("Undefined");
            psExecComboBox.Items.Add("Restricted");
            psExecComboBox.Items.Add("AllSigned");
            psExecComboBox.Items.Add("RemoteSigned");
            psExecComboBox.Items.Add("Unrestricted");
            psExecComboBox.SelectedIndex = 0;
        }

        private void PopulateSites()
        {
            Sites = Utils.GetIISSites();
            sitesListBox.Items.Clear();

            if (Sites == null || Sites?.Count == 0)
            {
                iisGroupBox.Enabled = false;
                iisRadioButton.Enabled = false;
                standaloneRadioButton.Select();
            }
            else
            {
                foreach (var site in Sites)
                {
                    sitesListBox.Items.Add(site.Name);
                }
            }
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            if (AddDomain(domainTextBox.Text.Trim().ToLower()))
                domainTextBox.Text = string.Empty;

            CheckIssue();
        }

        private bool CheckIssue()
        {
            if (issueButton.Text == Resources.WinCertesForm.IssueCertificate || issueButton.Text == Resources.WinCertesForm.RenewCertificate)
            {

                if (string.IsNullOrEmpty(emailTextBox.Text.Trim()) || !Regex.IsMatch(emailTextBox.Text.Trim(), @"^[^@\s]+@[^@\s]+\.[^@\s]+$", RegexOptions.IgnoreCase, TimeSpan.FromMilliseconds(250)))
                {
                    actionToolStripStatusLabel.Text = Resources.WinCertesForm.ValidEmail;
                    issueButton.Enabled = false;
                    return false;
                }

                if (string.IsNullOrEmpty(serviceComboBox.Text.Trim()) || !Regex.IsMatch(serviceComboBox.Text.Trim(), @"^https:\/\/(www\.)?[-a-zA-Z0-9@:%._\+~#=]{1,256}\.[a-zA-Z0-9()]{1,6}\b([-a-zA-Z0-9()@:%_\+.~#?&//=]*)$", RegexOptions.IgnoreCase, TimeSpan.FromMilliseconds(250)))
                {
                    actionToolStripStatusLabel.Text = Resources.WinCertesForm.ValidService;
                    issueButton.Enabled = false;
                    return false;
                }

                if (standaloneRadioButton.Checked)
                {
                    if (!CheckPort())
                    {
                        actionToolStripStatusLabel.Text = Resources.WinCertesForm.StandaloneRequiresPort;
                        issueButton.Enabled = false;
                        return false;
                    }
                    else if (iisCheckBox.Checked && sitesListBox.SelectedIndex == -1)
                    {
                        actionToolStripStatusLabel.Text = Resources.WinCertesForm.IISBindNeedsSite;
                        issueButton.Enabled = false;
                        return false;

                    }
                }

                if (iisRadioButton.Checked && (sitesListBox.SelectedIndex == -1 || string.IsNullOrEmpty(webRootLabel.Text)))
                {
                    actionToolStripStatusLabel.Text = Resources.WinCertesForm.ChallengeNeedsSite;
                    issueButton.Enabled = false;
                    return false;
                }

                if (domainsListBox.Items.Count == 0)
                {
                    actionToolStripStatusLabel.Text = Resources.WinCertesForm.DomainsRequired;
                    issueButton.Enabled = false;
                    return false;

                }

                actionToolStripStatusLabel.Text = issueButton.Text == Resources.WinCertesForm.RenewCertificate ? Resources.WinCertesForm.ReadyRenew : Resources.WinCertesForm.ReadyIssue;
                issueButton.Enabled = true;
                return true;

            }
            else if (issueButton.Text == Resources.WinCertesForm.UpdateSettings)
            {
                issueButton.Enabled = ((iisCheckBox.Checked != _winCertesOptions.BindSite)
                                            || (sniCheckBox.Checked != _winCertesOptions.Sni)
                                            || (iisPortNumericUpDown.Value != (_winCertesOptions.BindPort == 0 ? 443 : _winCertesOptions.BindPort))
                                            || (psScriptCheckBox.Checked != _winCertesOptions.PsScript)
                                            || (psScriptTextBox.Text != (_winCertesOptions.ScriptFile ?? ""))
                                            || (psExecCheckBox.Checked != _winCertesOptions.PsExecPolicy)
                                            || (psExecComboBox.Text != (_winCertesOptions.ScriptExecutionPolicy ?? "Undefined"))
                                            || (taskCheckBox.Checked != _winCertesOptions.TaskScheduled)
                                            || (renewalNumericUpDown.Value != _winCertesOptions.RenewalDelay)
                                            || (sitesListBox.SelectedItem != null && sitesListBox.Text != _winCertesOptions.BindName)
                                            || (standaloneRadioButton.Checked && httpPortNumericUpDown.Value != (_winCertesOptions.HttpPort == 0 ? 80 : _winCertesOptions.HttpPort)));

                if (issueButton.Enabled)
                    actionToolStripStatusLabel.Text = Resources.WinCertesForm.ReadyUpdate;
                else
                    actionToolStripStatusLabel.Text = Resources.WinCertesForm.WinCertes;

            }

            return issueButton.Enabled;
        }

        private void domainsListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            removeButton.Enabled = true;
        }

        private void removeButton_Click(object sender, EventArgs e)
        {
            domainsListBox.Items.RemoveAt(domainsListBox.SelectedIndex);
            removeButton.Enabled = false;
            CheckIssue();
        }

        private void sitesListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (sitesListBox.SelectedIndex > -1)
            {
                IisSite = Sites[sitesListBox.Text];
                var applicationRoot = IisSite.Applications.First();
                var virtualRoot = applicationRoot.VirtualDirectories.First();
                webRootLabel.Text = Environment.ExpandEnvironmentVariables(virtualRoot.PhysicalPath);
                var bindings = IisSite.Bindings;
                bindingsListBox.Items.Clear();
                if (domainsGroupBox.Enabled) domainsListBox.Items.Clear();

                if (_cert != null) _iisBound = false;

                foreach (var bind in bindings)
                {
                    if (!string.IsNullOrEmpty(bind.Host) && domainsGroupBox.Enabled) AddDomain(bind.Host);

                    try
                    {

                        if (bind.CertificateHash != null)
                        {
                            var cert = Utils.GetCertificateByHash(bind.CertificateHash);
                            var domains = "";

                            if (cert != null)
                            {
                                var sans = Utils.ParseSubjectAlternativeName(cert);
                                if (_cert != null && cert.FriendlyName == _cert.FriendlyName && cert.Subject == _cert.Subject) _iisBound = true;
                                var flag = true;
                                foreach (var san in sans)
                                {
                                    if (flag)
                                        flag = false;
                                    else
                                        domains += ", ";
                                    if (domainsGroupBox.Enabled) AddDomain(san);
                                    domains += san;
                                }
                            }
                            bindingsListBox.Items.Add($"{bind.Protocol}://{(string.IsNullOrEmpty(bind.Host) ? "*" : bind.Host)}:{bind.EndPoint.Port}{virtualRoot.Path} {(bind.SslFlags == SslFlags.Sni ? "(SNI)" : "")} {(string.IsNullOrEmpty(domains) ? "" : $"[{domains}]")}");

                        }
                        else
                        {
                            if (bind.Protocol == "https")
                                bindingsListBox.Items.Add($"{bind.Protocol}://{(string.IsNullOrEmpty(bind.Host) ? "*" : bind.Host)}:{bind.EndPoint.Port}{virtualRoot.Path} {(bind.SslFlags == SslFlags.Sni ? "(SNI)" : "")}");
                        }
                    }
                    catch (ArgumentException err)
                    {
                        _logger.Error($"{Resources.WinCertesForm.ErrorGetBinding} {err.Message}");
                        continue;
                    }
                    catch (Exception err)
                    {
                        _logger.Error($"{Resources.WinCertesForm.ErrorGetBindingFail} {err.Message}");

                    }


                }

                CheckIssue();
            }
        }

        private void browseButton_Click(object sender, EventArgs e)
        {
            browseOpenFileDialog.Filter = Resources.WinCertesForm.PSFilter;
            if (browseOpenFileDialog.ShowDialog() == DialogResult.OK)
            {
                psScriptTextBox.Text = browseOpenFileDialog.FileName;
                psScriptCheckBox.Checked = true;
            }
        }

        private void psExecComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (psExecComboBox.SelectedIndex != 0)
                psExecCheckBox.Checked = true;

            CheckIssue();
        }

        private void iisRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            standaloneGroupBox.Enabled = false;
            CheckIssue();
        }

        private void standaloneRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            standaloneGroupBox.Enabled = standaloneRadioButton.Checked;

            checkPortButton.Visible = false;
            if (standaloneRadioButton.Checked)
                CheckIssue();
        }

        private bool CheckPort()
        {
            checkPortButton.Visible = false;
            inUseLabel.Visible = !HTTPChallengeValidatorFactory.CheckAvailableServerPort((int)httpPortNumericUpDown.Value);
            if (inUseLabel.Visible) inUseLabel.Text = string.Format(Resources.WinCertesForm.Port0InUse, httpPortNumericUpDown.Value);
            return !inUseLabel.Visible;
        }

        private void certButton_Click(object sender, EventArgs e)
        {
            if (_cert != null)
                X509Certificate2UI.DisplayCertificate(_cert);
        }

        private void emailTextBox_TextChanged(object sender, EventArgs e)
        {
            registeredLabel.Visible = (_winCertesOptions.Email == emailTextBox.Text.Trim() && _winCertesOptions.Registered);
            CheckIssue();
        }

        private async void revokeButton_ClickAsync(object sender, EventArgs e)
        {
            if (MessageBox.Show(Resources.WinCertesForm.ConfirmRevokeCertificate, Resources.WinCertesForm.AreYouSure, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                this.Enabled = false;
                actionToolStripStatusLabel.Text = Resources.WinCertesForm.InitCertes;

                if (await InitCertesWrapperAsync(_config, _winCertesOptions.ServiceUri, _winCertesOptions.Email) && _certesWrapper != null)
                {
                    var result = await RevokeCert();
                    if (result.HasValue && result.Value)
                    {
                        actionToolStripStatusLabel.Text = Resources.WinCertesForm.CertificateRevoked;
                        MessageBox.Show(Resources.WinCertesForm.CertificateHasBeenRevoked, Resources.WinCertesForm.Success, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        BindConfig();
                    }
                    else
                    {
                        string message;

                        if (!result.HasValue)
                            message = $"{Resources.WinCertesForm.ErrorFindCertificate}\n\n";
                        else
                            message = $"{Resources.WinCertesForm.ErrorRevokingCertificate}\n\n";

                        if (MessageBox.Show(message + Resources.WinCertesForm.ConfirmDeleteCertificate, Resources.WinCertesForm.Error, MessageBoxButtons.YesNo, MessageBoxIcon.Error) == DialogResult.Yes)
                        {
                            actionToolStripStatusLabel.Text = Resources.WinCertesForm.RemovingCertificate;
                            WinCertesOptions.RemoveCertificateFromConfiguration(_cert, _config, _winCertesOptions.DomainsHostId);
                            actionToolStripStatusLabel.Text = Resources.WinCertesForm.CertificateDeleted;
                            MessageBox.Show(Resources.WinCertesForm.CertificateHasBeenDeleted, Resources.WinCertesForm.Success, MessageBoxButtons.OK, MessageBoxIcon.Information);
                            _cert = null;
                            certButton.Visible = false;
                            revokeButton.Visible = false;
                            BindConfig();
                        }

                    }
                }
                else
                    MessageBox.Show(string.Format(Resources.WinCertesForm.ErrorACMEServiceEmail, (_winCertesOptions.ServiceUri ?? WellKnownServers.LetsEncryptV2.ToString()), (_winCertesOptions.Email ?? Resources.WinCertesForm.None)), Resources.WinCertesForm.Error, MessageBoxButtons.OK, MessageBoxIcon.Error);

                this.Enabled = true;

            }

        }

        private void configsComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            var config = configsComboBox.Text;

            if ((config == Resources.WinCertesForm.DefaultConfiguration) && _extra != -1)
            {
                _extra = -1;
                BindConfig();
            }
            else if (config.Contains(":"))
            {
                if (int.TryParse(config.Split(":")[1], out var extra))
                {
                    if (extra != _extra)
                    {
                        _extra = extra;
                        BindConfig();
                    }
                }
            }
        }

        private void deleteButton_Click(object sender, EventArgs e)
        {
            if (_extra != -1)
            {
                var message = $"{Resources.WinCertesForm.ConfirmDeleteConfiguration} {_extra}?";
                if (_cert != null) message += $"\n{Resources.WinCertesForm.RecommendDelete}";
                if (MessageBox.Show(message, Resources.WinCertesForm.AreYouSure, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    _config.DeleteAllParameters(_extra);
                    _extra = -1;
                    BindConfig();
                }
            }
        }

        private void checkPortButton_Click(object sender, EventArgs e)
        {
            CheckPort();
        }

        private void httpPortNumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            checkPortButton.Visible = true;

        }

        private async void issueButton_Click(object sender, EventArgs e)
        {
            if (CheckIssue())
            {
                var domains = new List<string>();
                string taskName = null;

                foreach (var item in domainsListBox.Items)
                {
                    domains.Add(item.ToString());
                }
                domains = domains.ConvertAll(d => d.ToLower());
                domains.Sort();

                if (issueButton.Text == Resources.WinCertesForm.UpdateSettings)
                {
                    var message = $"{Resources.WinCertesForm.ConfirmUpdateSettings}\n";

                    if (iisCheckBox.Checked != _winCertesOptions.BindSite)
                    {
                        if (iisCheckBox.Checked)
                        {
                            if (!_iisBound)
                                message += $"{Resources.WinCertesForm.AttemptRebind}\n";
                            else
                                message += $"{Resources.WinCertesForm.BindOnRenewal}\n";
                        }
                        else
                        {
                            if (_iisBound)
                                message += $"{Resources.WinCertesForm.NoRebind}\n";
                            else
                                message += $"{Resources.WinCertesForm.NoBindOnRenewal}\n";

                        }
                    }

                    if (sitesListBox.SelectedItem != null && sitesListBox.Text != _winCertesOptions.BindName)
                    {
                        if (iisCheckBox.Checked)
                            message += $"{Resources.WinCertesForm.CertificateWillBeBound} {sitesListBox.Text}.\n";
                        else if (iisRadioButton.Checked)
                            message += string.Format(Resources.WinCertesForm.IISSiteAtWebRootRenewal, sitesListBox.Text, webRootLabel.Text) + "\n";
                    }
                    if (sniCheckBox.Checked != _winCertesOptions.Sni) message += $"{Resources.WinCertesForm.IISBindingSNIFlag} {(sniCheckBox.Checked ? Resources.WinCertesForm.On : Resources.WinCertesForm.Off)}.\n";
                    if (iisPortNumericUpDown.Value != (_winCertesOptions.BindPort == 0 ? 443 : _winCertesOptions.BindPort)) message += $"{Resources.WinCertesForm.IISBindPortUpdate} {iisPortNumericUpDown.Value}.\n";
                    if (psScriptCheckBox.Checked != _winCertesOptions.PsScript) message += $"{Resources.WinCertesForm.PSExecUpdate} {(psScriptCheckBox.Checked ? Resources.WinCertesForm.On : Resources.WinCertesForm.Off)}.\n";
                    if (psScriptTextBox.Text.Trim() != (_winCertesOptions.ScriptFile ?? "")) message += $"{Resources.WinCertesForm.PSScriptUpdate} {Path.GetFileName(psScriptTextBox.Text)}.\n";
                    if (psExecCheckBox.Checked != _winCertesOptions.PsExecPolicy) message += $"{Resources.WinCertesForm.PSExecSetting} {(psExecCheckBox.Checked ? Resources.WinCertesForm.On : Resources.WinCertesForm.Off)}.\n";
                    if (psExecComboBox.Text != (_winCertesOptions.ScriptExecutionPolicy ?? "Undefined")) message += $"{Resources.WinCertesForm.PSScriptExecSetting} {psExecComboBox.Text}.\n";
                    if (renewalNumericUpDown.Value != _winCertesOptions.RenewalDelay) message += $"{Resources.WinCertesForm.DaysBeforeRenewal} {renewalNumericUpDown.Value}.\n";
                    if (taskCheckBox.Checked != _winCertesOptions.TaskScheduled)
                    {
                        taskName = Utils.DomainsToFriendlyName(domains);
                        if (taskCheckBox.Checked)
                        {
                            message += $"{Resources.WinCertesForm.TaskWillBeCreated}\n";
                        }
                        else
                            message += $"{Resources.WinCertesForm.TaskWillBeDeleted}\n";
                    }

                    if (MessageBox.Show(message, Resources.WinCertesForm.UpdateIISSetting, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        this.Enabled = false;
                        actionToolStripStatusLabel.Text = Resources.WinCertesForm.UpdatingSettings;

                        _winCertesOptions.BindPort = (int)iisPortNumericUpDown.Value;
                        _winCertesOptions.Sni = sniCheckBox.Checked;
                        _winCertesOptions.BindName = sitesListBox.SelectedItem != null ? sitesListBox.Text : null;
                        _winCertesOptions.BindSite = iisCheckBox.Checked;
                        _winCertesOptions.BindPort = (int)iisPortNumericUpDown.Value;
                        _winCertesOptions.PsScript = psScriptCheckBox.Checked;
                        _winCertesOptions.PsExecPolicy = psExecCheckBox.Checked;
                        _winCertesOptions.ScriptExecutionPolicy = psExecComboBox.Text;
                        _winCertesOptions.ScriptFile = psScriptTextBox.Text.Trim();
                        _winCertesOptions.WebRoot = webRootLabel.Text;
                        _winCertesOptions.RenewalDelay = (int)renewalNumericUpDown.Value;

                        if (taskCheckBox.Checked)
                        {
                            actionToolStripStatusLabel.Text = Resources.WinCertesForm.CreatingTask;
                            Utils.CreateScheduledTask(taskName, domains, _extra);
                        }
                        else if (taskName != null)
                        {
                            actionToolStripStatusLabel.Text = Resources.WinCertesForm.DeletingTask;
                            Utils.DeleteScheduledTasks(taskName);
                        }

                        actionToolStripStatusLabel.Text = Resources.WinCertesForm.WritingConfiguration;
                        _winCertesOptions.WriteOptionsIntoConfiguration(_config, true);

                        if (iisCheckBox.Checked && !_iisBound)
                        {
                            actionToolStripStatusLabel.Text = Resources.WinCertesForm.BindingCertToIIS;
                            if (Utils.BindCertificateForIISSite(_cert, _winCertesOptions.BindName, _winCertesOptions.BindPort, _winCertesOptions.Sni))
                            {
                                MessageBox.Show(Resources.WinCertesForm.SuccessCertBoundIIS, Resources.WinCertesForm.Success, MessageBoxButtons.OK, MessageBoxIcon.Information);
                                PopulateSites();
                            }
                            else
                                MessageBox.Show(Resources.WinCertesForm.FailedCertBindIIS, Resources.WinCertesForm.Error, MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }

                        actionToolStripStatusLabel.Text = Resources.WinCertesForm.SettingsUpdated;
                        BindConfig();

                        this.Enabled = true;
                    }
                }
                else
                {
                    _winCertesOptions.ServiceUri = serviceComboBox.Text;
                    _winCertesOptions.Email = emailTextBox.Text.Trim();
                    var text = string.Format(Resources.WinCertesForm.ConfirmGenerateCertificateDomainsServiceEmail, String.Join(",", domains), _winCertesOptions.ServiceUri, _winCertesOptions.Email);

                    if (standaloneRadioButton.Checked)
                    {
                        _winCertesOptions.Standalone = true;
                        _winCertesOptions.HttpPort = (int)httpPortNumericUpDown.Value;
                        text += string.Format(Resources.WinCertesForm.StandaloneUsedResponseOnPort, _winCertesOptions.HttpPort);
                    }
                    else if (iisRadioButton.Checked)
                    {
                        _winCertesOptions.Standalone = false;
                        _winCertesOptions.WebRoot = webRootLabel.Text;
                        text += string.Format(Resources.WinCertesForm.IISSiteChallange, _winCertesOptions.WebRoot);
                    }

                    _winCertesOptions.BindName = sitesListBox.SelectedItem != null ? sitesListBox.Text : null;
                    _winCertesOptions.BindSite = iisCheckBox.Checked;
                    _winCertesOptions.BindPort = (int)iisPortNumericUpDown.Value;
                    _winCertesOptions.Sni = sniCheckBox.Checked;

                    if (_winCertesOptions.BindSite)
                    {
                        text += string.Format(Resources.WinCertesForm.IssuedCertificateIISPort, _winCertesOptions.BindName, _winCertesOptions.BindPort);
                        if (_winCertesOptions.Sni)
                            text += $" {Resources.WinCertesForm.WithSNI}";
                    }

                    _winCertesOptions.PsScript = psScriptCheckBox.Checked;
                    _winCertesOptions.PsExecPolicy = psExecCheckBox.Checked;
                    _winCertesOptions.ScriptExecutionPolicy = psExecComboBox.Text;
                    _winCertesOptions.ScriptFile = psScriptTextBox.Text.Trim();

                    if (psScriptCheckBox.Checked)
                    {
                        text += string.Format(Resources.WinCertesForm.PSScriptWillBeExecuted, Path.GetFileName(_winCertesOptions.ScriptFile));
                        if (psExecCheckBox.Checked)
                            text += $" {Resources.WinCertesForm.WithPSExecPolicy} {_winCertesOptions.ScriptExecutionPolicy}";
                    }

                    _winCertesOptions.RenewalDelay = (int)renewalNumericUpDown.Value;

                    if (taskCheckBox.Checked)
                    {
                        taskName = Utils.DomainsToFriendlyName(domains);
                        text += string.Format(Resources.WinCertesForm.TaskCreatedDaysBefore, _winCertesOptions.RenewalDelay);
                    }

                    if (MessageBox.Show(text, Resources.WinCertesForm.GenerateCertificate, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        this.Enabled = false;
                        actionToolStripStatusLabel.Text = Resources.WinCertesForm.WritingSettings;

                        _winCertesOptions.WriteOptionsIntoConfiguration(_config, true);

                        actionToolStripStatusLabel.Text = Resources.WinCertesForm.InitCertes;

                        if (await InitCertesWrapperAsync(_config, _winCertesOptions.ServiceUri, _winCertesOptions.Email) && _certesWrapper != null)
                        {
                            actionToolStripStatusLabel.Text = Resources.WinCertesForm.IssuingCertificate;

                            var result = await IssueCert(domains, taskName);
                            if (result.HasValue && result.Value)
                            {
                                actionToolStripStatusLabel.Text = Resources.WinCertesForm.CertificateIssued;

                                MessageBox.Show(Resources.WinCertesForm.CertificateHasBeenIssued, Resources.WinCertesForm.Success, MessageBoxButtons.OK, MessageBoxIcon.Information);
                                PopulateSites();
                                BindConfig();
                            }
                            else
                            {
                                actionToolStripStatusLabel.Text = Resources.WinCertesForm.ErrorIssuingCertificate;

                                if (!result.HasValue)
                                    MessageBox.Show(Resources.WinCertesForm.ErrorRetrievingCertificate, Resources.WinCertesForm.Error, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                else
                                    MessageBox.Show(Resources.WinCertesForm.ErrorBindingCertificateGenerated, Resources.WinCertesForm.Error, MessageBoxButtons.OK, MessageBoxIcon.Error);

                            }

                        }
                        else
                        {
                            MessageBox.Show(string.Format(Resources.WinCertesForm.ErrorACMEServiceEmail, (_winCertesOptions.ServiceUri ?? WellKnownServers.LetsEncryptV2.ToString()), (_winCertesOptions.Email ?? Resources.WinCertesForm.None)), Resources.WinCertesForm.Error, MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }

                        this.Enabled = true;

                    }
                }
            }
        }

        private void newConfigButton_Click(object sender, EventArgs e)
        {
            var extras = _config.GetExtrasConfigParams();
            var i = 1;
            foreach (var item in extras)
            {
                if (i == item)
                    i++;
                else
                    break;
            }

            if (MessageBox.Show($"{Resources.WinCertesForm.ConfirmNewConfiguration} {i}", Resources.WinCertesForm.CreateNewConfiguration, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                _extra = i;
                BindConfig();
            }
        }

        private void iisCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            CheckIssue();
        }

        private void sniCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            CheckIssue();
        }

        private void iisPortNumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            CheckIssue();
        }

        private void psScriptCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            CheckIssue();

        }

        private void psExecCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            CheckIssue();

        }

        private void psScriptTextBox_TextChanged(object sender, EventArgs e)
        {
            CheckIssue();

        }

        private void taskCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            CheckIssue();

        }

        private void renewalNumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            CheckIssue();

        }

        private void WinCertesForm_HelpButtonClicked(object sender, CancelEventArgs e)
        {
            DisplayHelp();
        }

        private void WinCertesForm_HelpRequested(object sender, HelpEventArgs hlpevent)
        {
            DisplayHelp();
        }

        private void serviceComboBox_TextUpdate(object sender, EventArgs e)
        {
            CheckIssue();
        }

        private void serviceComboBox_DropDownClosed(object sender, EventArgs e)
        {
            CheckIssue();
        }

        private static void DisplayHelp()
        {
            MessageBox.Show(Resources.WinCertesForm.HelpText, Resources.WinCertesForm.Help, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
