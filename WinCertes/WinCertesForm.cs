using Certes.Acme;
using Microsoft.Web.Administration;
using NLog;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Security.AccessControl;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Security.Principal;
using System.Text;
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
            (_winCertesPath, _certTmpPath) = Utils.InitWinCertesDirectoryPath();
            Utils.ConfigureLogger(_winCertesPath);
            InitializeComponent();
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
                actionToolStripProgressBar.Value = 10;
                actionToolStripStatusLabel.Text = "Registering New Account...";
                var regRes = await _certesWrapper.RegisterNewAccount();
                if (!regRes)
                    return false;
            }
            return true;

        }

        private async Task<bool?> RevokeCert(int revoke = 0)
        {
            actionToolStripProgressBar.Value = 25;
            actionToolStripStatusLabel.Text = "Getting Existing Certificate from Configuration...";
            string serial = _config.ReadStringParameter("certSerial" + _winCertesOptions.DomainsHostId);
            if (serial == null)
                return null;

            actionToolStripProgressBar.Value = 50;
            actionToolStripStatusLabel.Text = "Revoking Certificate with ACME Service...";
            // Here we revoke from ACME Service. Note that any error is already handled into the wrapper
            if (await _certesWrapper.RevokeCertificate(_cert, revoke))
            {
                actionToolStripProgressBar.Value = 75;
                actionToolStripStatusLabel.Text = "Removing Certificate from Configuration...";
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

            actionToolStripProgressBar.Value = 20;
            actionToolStripStatusLabel.Text = "Getting HTTP Validator...";

            // Now the real stuff: we register the order for the domains, and have them validated by the ACME service
            IHTTPChallengeValidator httpChallengeValidator = HTTPChallengeValidatorFactory.GetHTTPChallengeValidator(_winCertesOptions.Standalone, _winCertesOptions.HttpPort, _winCertesOptions.WebRoot);

            // Not supporting DNS yet!
            // IDNSChallengeValidator dnsChallengeValidator = DNSChallengeValidatorFactory.GetDNSChallengeValidator(_config);
            IDNSChallengeValidator dnsChallengeValidator = null;
            // This should never show!
            if ((httpChallengeValidator == null) && (dnsChallengeValidator == null)) { MessageBox.Show("Specify either an HTTP or a DNS validation method.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation); return false; }

            actionToolStripProgressBar.Value = 30;
            actionToolStripStatusLabel.Text = "Registering New Order and Verifiying...";
            if (!await _certesWrapper.RegisterNewOrderAndVerify(domains, httpChallengeValidator, dnsChallengeValidator))
            {
                actionToolStripProgressBar.Value = 40;
                actionToolStripStatusLabel.Text = "Failed to Verify, cleaning up...";
                if (httpChallengeValidator != null) httpChallengeValidator.EndAllChallengeValidations(); return false;
            }

            actionToolStripProgressBar.Value = 40;
            actionToolStripStatusLabel.Text = "Verified, cleaning up...";

            if (httpChallengeValidator != null)
            {
                httpChallengeValidator.EndAllChallengeValidations();
            }

            actionToolStripProgressBar.Value = 50;
            actionToolStripStatusLabel.Text = "Retrieving Certificate...";

            // We get the certificate from the ACME service
            var pfx = await _certesWrapper.RetrieveCertificate(domains, _certTmpPath, Utils.DomainsToFriendlyName(domains));
            if (pfx == null) return null;

            actionToolStripProgressBar.Value = 60;
            actionToolStripStatusLabel.Text = "Storing Certificate...";

            // Currently only supporting the default Csp
            CertificateStorageManager certificateStorageManager = new CertificateStorageManager(pfx, true);
            // Let's process the PFX into Windows Certificate objet.
            certificateStorageManager.ProcessPFX();
            // and we write its information to the WinCertes configuration
            WinCertesOptions.RegisterCertificateIntoConfiguration(certificateStorageManager.Certificate, domains, _config);
            // Import the certificate into the Windows store
            if (!_winCertesOptions.NoCsp) certificateStorageManager.ImportCertificateIntoCSP(_winCertesOptions.Csp);

            actionToolStripProgressBar.Value = 70;
            actionToolStripStatusLabel.Text = "Binding Certificate to IIS if required...";

            // Bind certificate to IIS Site (won't do anything if option is null)
            if (Utils.BindCertificateForIISSite(certificateStorageManager.Certificate, _winCertesOptions.BindName, _winCertesOptions.BindPort, _winCertesOptions.Sni))
            {
                result = true;
                _logger.Info("Successfully bound certificate for IIS site: " + _winCertesOptions.BindName);
            }
            else
            {
                result = string.IsNullOrEmpty(_winCertesOptions.BindName);
                _logger.Debug("Certificate not bound to any IIS site");
            }

            actionToolStripProgressBar.Value = 80;
            actionToolStripStatusLabel.Text = "Executing PowerShell Script if required...";

            // Execute PowerShell Script (won't do anything if option is null)
            Utils.ExecutePowerShell(_winCertesOptions.ScriptFile, pfx, _winCertesOptions.ScriptExecutionPolicy);

            actionToolStripProgressBar.Value = 90;
            actionToolStripStatusLabel.Text = "Creating Scheduled Task if required...";

            // Create the AT task that will execute WinCertes periodically (won't do anything if taskName is null)
            Utils.CreateScheduledTask(taskName, domains, _extra);

            actionToolStripProgressBar.Value = 95;
            actionToolStripStatusLabel.Text = "Removing temporary certificate...";

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
            webRootLabel.Text = "";

            configsComboBox.Items.Add("Default Configuration");

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
                psScriptTextBox.Text = "";
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
                        issueButton.Text = "Renew Certificate";
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
                issueButton.Text = "Issue Certificate";
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
                    issueButton.Text = "Update Settings";
                    issueButton.Enabled = !_iisBound;
                }
            }

            var extras = _config.GetExtrasConfigParams();

            if (extras.Count > 0)
            {
                foreach (var item in extras)
                {
                    configsComboBox.Items.Add($"Extra Configuration: {item}");
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

            if (Sites == null || Sites.Count == 0)
            {
                iisGroupBox.Enabled = false;
                iisRadioButton.Enabled = false;
                standaloneRadioButton.Select();
            }
            else
            {
                foreach (var site in Sites)
                {
                    sitesListBox.Items.Add($"{site.Name}");
                }
            }
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            if (AddDomain(domainTextBox.Text.Trim().ToLower()))
                domainTextBox.Text = "";

            CheckIssue();
        }

        private bool CheckIssue()
        {
            if (issueButton.Text == "Issue Certificate" || issueButton.Text == "Renew Certificate")
            {

                if (string.IsNullOrEmpty(emailTextBox.Text.Trim()) || !Regex.IsMatch(emailTextBox.Text.Trim(), @"^[^@\s]+@[^@\s]+\.[^@\s]+$", RegexOptions.IgnoreCase, TimeSpan.FromMilliseconds(250)))
                {
                    actionToolStripStatusLabel.Text = "Valid E-mail is Required.";
                    issueButton.Enabled = false;
                    return false;
                }

                if (string.IsNullOrEmpty(serviceComboBox.Text.Trim()) || !Regex.IsMatch(serviceComboBox.Text.Trim(), @"^https:\/\/(www\.)?[-a-zA-Z0-9@:%._\+~#=]{1,256}\.[a-zA-Z0-9()]{1,6}\b([-a-zA-Z0-9()@:%_\+.~#?&//=]*)$", RegexOptions.IgnoreCase, TimeSpan.FromMilliseconds(250)))
                {
                    actionToolStripStatusLabel.Text = "Valid Service address is Required.";
                    issueButton.Enabled = false;
                    return false;
                }

                if (standaloneRadioButton.Checked)
                {
                    if (!CheckPort())
                    {
                        actionToolStripStatusLabel.Text = "Standalone HTTP Server requires a Port that is Not in Use.";
                        issueButton.Enabled = false;
                        return false;
                    }
                    else if (iisCheckBox.Checked && sitesListBox.SelectedIndex == -1)
                    {
                        actionToolStripStatusLabel.Text = "IIS Site is required to Bind Certificate to.";
                        issueButton.Enabled = false;
                        return false;

                    }
                }

                if (iisRadioButton.Checked && (sitesListBox.SelectedIndex == -1 || string.IsNullOrEmpty(webRootLabel.Text)))
                {
                    actionToolStripStatusLabel.Text = "IIS Site is required for Challenge Response.";
                    issueButton.Enabled = false;
                    return false;
                }

                if (domainsListBox.Items.Count == 0)
                {
                    actionToolStripStatusLabel.Text = "Domains to generate certificate for are required.";
                    issueButton.Enabled = false;
                    return false;

                }

                actionToolStripStatusLabel.Text = issueButton.Text == "Renew Certificate" ? "Ready to Renew Certificate." : "Ready to Issue Certificate.";
                issueButton.Enabled = true;
                return true;

            }
            else if (issueButton.Text == "Update Settings")
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
                    actionToolStripStatusLabel.Text = "Ready to Update Settings.";
                else
                    actionToolStripStatusLabel.Text = "WinCertes";

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
                            bindingsListBox.Items.Add($"{bind.Protocol}://{(string.IsNullOrEmpty(bind.Host) ? "*" : bind.Host)}:{bind.EndPoint.Port}{virtualRoot.Path} {(bind.SslFlags == SslFlags.Sni ? "(SNI)" : "")}");
                        }
                    }
                    catch (ArgumentException err)
                    {
                        _logger.Error($"Cound not read IIS binding, try resetting IIS, continuing: {err.Message}");
                        continue;
                    }
                    catch (Exception err)
                    {
                        _logger.Error($"Cound not read IIS binding, try resetting IIS, breaking: {err.Message}");

                    }


                }

                CheckIssue();
            }
        }

        private void browseButton_Click(object sender, EventArgs e)
        {
            browseOpenFileDialog.Filter = "PowerShell Scripts (*.ps1)|*.ps1|All files (*.*)|*.*";
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
            if (inUseLabel.Visible) inUseLabel.Text = $"PORT {httpPortNumericUpDown.Value} IN USE";
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
            if (MessageBox.Show("Are you sure you wish to Revoke and delete the Certificate?", "Are you sure?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                this.Enabled = false;
                actionToolStripProgressBar.Value = 0;
                actionToolStripProgressBar.Visible = true;
                actionToolStripStatusLabel.Text = "Initializing Certes...";

                if (await InitCertesWrapperAsync(_config, _winCertesOptions.ServiceUri, _winCertesOptions.Email) && _certesWrapper != null)
                {
                    var result = await RevokeCert();
                    if (result.HasValue && result.Value)
                    {
                        actionToolStripProgressBar.Value = 100;
                        actionToolStripStatusLabel.Text = "Certificate successfully revoked.";
                        MessageBox.Show($"Certificate has been successfully revoked", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        BindConfig();
                    }
                    else
                    {
                        string message;

                        if (!result.HasValue)
                            message = "Could not find configuration or configuration does not match Certificate domains.\n\n";
                        else
                            message = "Error revoking certificate, it could already be revoked.\n\n";

                        if (MessageBox.Show(message + "Would you like to Delete the certificate and reset configuration?", "Error", MessageBoxButtons.YesNo, MessageBoxIcon.Error) == DialogResult.Yes)
                        {
                            actionToolStripProgressBar.Value = 75;
                            actionToolStripStatusLabel.Text = "Removing Certificate from Configuration...";
                            WinCertesOptions.RemoveCertificateFromConfiguration(_cert, _config, _winCertesOptions.DomainsHostId);
                            actionToolStripProgressBar.Value = 100;
                            actionToolStripStatusLabel.Text = "Certificate successfully deleted.";
                            MessageBox.Show($"Certificate has been successfully deleted", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            _cert = null;
                            certButton.Visible = false;
                            revokeButton.Visible = false;
                            BindConfig();
                        }

                    }
                }
                else
                    MessageBox.Show($"Could not register ACME service account with service address: {_winCertesOptions.ServiceUri ?? WellKnownServers.LetsEncryptV2.ToString()} e-mail address {_winCertesOptions.Email ?? "<None>"}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                this.Enabled = true;
                actionToolStripProgressBar.Visible = false;

            }

        }

        private void configsComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            var config = configsComboBox.Text;

            if ((config == "Default Configuration") && _extra != -1)
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
                var message = $"Are you sure you wish to delete the Extra Configuration {_extra}?";
                if (_cert != null) message += "\r\nIt is recommended to Revoke and Delete the Certificate first.";
                if (MessageBox.Show(message, "Are you sure?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
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

                if (issueButton.Text == "Update Settings")
                {
                    var message = "Are you sure you want to update the Settings?\r\n";

                    if (iisCheckBox.Checked != _winCertesOptions.BindSite)
                    {
                        if (iisCheckBox.Checked)
                        {
                            if (!_iisBound)
                                message += $"This will attempt to Rebind the Certificate to the IIS Site.\r\n";
                            else
                                message += $"This will bind the Certificate on renewal.\r\n";
                        }
                        else
                        {
                            if (_iisBound)
                                message += "This will not unbind the Certificate from the IIS Site, but will not rebind it on renewal.\r\n";
                            else
                                message += $"The certificate will not be bound to an IIS Site on renewal.\r\n";

                        }
                    }

                    if (sitesListBox.SelectedItem != null && sitesListBox.Text != _winCertesOptions.BindName)
                    {
                        if (iisCheckBox.Checked)
                            message += $"Certificate will be bound to IIS Site {sitesListBox.Text}.\r\n";
                        else if (iisRadioButton.Checked)
                            message += $"IIS Site {sitesListBox.Text} with Web Root at {webRootLabel.Text} will be used for Challange response at renewal.\r\n";
                    }
                    if (sniCheckBox.Checked != _winCertesOptions.Sni) message += $"IIS Binding SNI Ssl Flag will be updated to {(sniCheckBox.Checked ? "On" : "Off")}.\r\n";
                    if (iisPortNumericUpDown.Value != (_winCertesOptions.BindPort == 0 ? 443 : _winCertesOptions.BindPort)) message += $"IIS Binding Port will be updated to {iisPortNumericUpDown.Value}.\r\n";
                    if (psScriptCheckBox.Checked != _winCertesOptions.PsScript) message += $"PowerShell Script execution will be updated to {(psScriptCheckBox.Checked ? "On" : "Off")}.\r\n";
                    if (psScriptTextBox.Text.Trim() != (_winCertesOptions.ScriptFile ?? "")) message += $"PowerShell Script will be updated to {Path.GetFileName(psScriptTextBox.Text)}.\r\n";
                    if (psExecCheckBox.Checked != _winCertesOptions.PsExecPolicy) message += $"Setting PowerShell Script Execution Policy will be updated to {(psExecCheckBox.Checked ? "On" : "Off")}.\r\n";
                    if (psExecComboBox.Text != (_winCertesOptions.ScriptExecutionPolicy ?? "Undefined")) message += $"PowerShell Script Execution Policy will be updated to {psExecComboBox.Text}.\r\n";
                    if (renewalNumericUpDown.Value != _winCertesOptions.RenewalDelay) message += $"Days before Renewal Period will be updated to {renewalNumericUpDown.Value}.\r\n";
                    if (taskCheckBox.Checked != _winCertesOptions.TaskScheduled)
                    {
                        taskName = Utils.DomainsToFriendlyName(domains);
                        if (taskCheckBox.Checked)
                        {
                            message += "A Task will be Scheduled to renew the certificate automatically.\r\n";
                        }
                        else
                            message += "The Scheduled Task will be deleted so the certificate will not be renewed automatically.\r\n";
                    }

                    if (MessageBox.Show(message, "Update IIS Settings", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        this.Enabled = false;
                        actionToolStripProgressBar.Value = 0;
                        actionToolStripProgressBar.Visible = true;
                        actionToolStripStatusLabel.Text = "Updating Settings...";

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
                            actionToolStripProgressBar.Value = 33;
                            actionToolStripStatusLabel.Text = "Creating Scheduled Task...";
                            Utils.CreateScheduledTask(taskName, domains, _extra);
                        }
                        else if (taskName != null)
                        {
                            actionToolStripProgressBar.Value = 33;
                            actionToolStripStatusLabel.Text = "Deleting Scheduled Task...";
                            Utils.DeleteScheduledTasks(taskName);
                        }

                        actionToolStripProgressBar.Value = 50;
                        actionToolStripStatusLabel.Text = "Writing new Configuration...";
                        _winCertesOptions.WriteOptionsIntoConfiguration(_config, true);

                        if (iisCheckBox.Checked && !_iisBound)
                        {
                            actionToolStripProgressBar.Value = 75;
                            actionToolStripStatusLabel.Text = "Binding Certificate to IIS Site...";
                            if (Utils.BindCertificateForIISSite(_cert, _winCertesOptions.BindName, _winCertesOptions.BindPort, _winCertesOptions.Sni))
                            {
                                MessageBox.Show($"Certificate successfully rebound to IIS Site.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                PopulateSites();
                            }
                            else
                                MessageBox.Show($"Certificate failed to bind to IIS Site.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }

                        actionToolStripProgressBar.Value = 100;
                        actionToolStripStatusLabel.Text = "Settings Updated.";
                        BindConfig();

                        this.Enabled = true;
                        actionToolStripProgressBar.Visible = false;
                    }
                }
                else
                {
                    _winCertesOptions.ServiceUri = serviceComboBox.Text;
                    _winCertesOptions.Email = emailTextBox.Text.Trim();
                    var text = $"Are you sure you want to Generate a Certificate for the following domains {String.Join(",", domains)} using a service at {_winCertesOptions.ServiceUri} and registering with the e-mail address {_winCertesOptions.Email}.\r\n";

                    if (standaloneRadioButton.Checked)
                    {
                        _winCertesOptions.Standalone = true;
                        _winCertesOptions.HttpPort = (int)httpPortNumericUpDown.Value;
                        text += $"A Standalone HTTP Server on Port {_winCertesOptions.HttpPort} will be used for the Challange Response.\r\n";
                    }
                    else if (iisRadioButton.Checked)
                    {
                        _winCertesOptions.Standalone = false;
                        _winCertesOptions.WebRoot = webRootLabel.Text;
                        text += $"The IIS Site at {_winCertesOptions.WebRoot} will be used for the Challange Response.\r\n";
                    }

                    _winCertesOptions.BindName = sitesListBox.SelectedItem != null ? sitesListBox.Text : null;
                    _winCertesOptions.BindSite = iisCheckBox.Checked;
                    _winCertesOptions.BindPort = (int)iisPortNumericUpDown.Value;
                    _winCertesOptions.Sni = sniCheckBox.Checked;

                    if (_winCertesOptions.BindSite)
                    {
                        text += $"The Issued Certificate will be binded to the IIS Site {_winCertesOptions.BindName} on Port {_winCertesOptions.BindPort}{(_winCertesOptions.Sni ? " with the SNI Ssl Flag on." : "")}\r\n";
                    }

                    _winCertesOptions.PsScript = psScriptCheckBox.Checked;
                    _winCertesOptions.PsExecPolicy = psExecCheckBox.Checked;
                    _winCertesOptions.ScriptExecutionPolicy = psExecComboBox.Text;
                    _winCertesOptions.ScriptFile = psScriptTextBox.Text.Trim();

                    if (psScriptCheckBox.Checked)
                    {
                        text += $"The PowerShell Script {Path.GetFileName(_winCertesOptions.ScriptFile)} will be executed after successfully issuing and/or binding the certificate{(psExecCheckBox.Checked ? $" with the Execution Policy set to {_winCertesOptions.ScriptExecutionPolicy}" : "")}.\r\n";
                    }

                    _winCertesOptions.RenewalDelay = (int)renewalNumericUpDown.Value;

                    if (taskCheckBox.Checked)
                    {
                        taskName = Utils.DomainsToFriendlyName(domains);
                        text += $"A Scheduled Task will be created to insure the certificate is renewed within {_winCertesOptions.RenewalDelay} of expiry.";
                    }

                    if (MessageBox.Show(text, "Generate Certificate?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        this.Enabled = false;
                        actionToolStripProgressBar.Value = 0;
                        actionToolStripProgressBar.Visible = true;
                        actionToolStripStatusLabel.Text = "Writing Settings into Configuration...";

                        _winCertesOptions.WriteOptionsIntoConfiguration(_config, true);

                        actionToolStripProgressBar.Value = 5;
                        actionToolStripStatusLabel.Text = "Initializing Certes...";

                        if (await InitCertesWrapperAsync(_config, _winCertesOptions.ServiceUri, _winCertesOptions.Email) && _certesWrapper != null)
                        {
                            actionToolStripProgressBar.Value = 25;
                            actionToolStripStatusLabel.Text = "Issuing Certificate...";

                            var result = await IssueCert(domains, taskName);
                            if (result.HasValue && result.Value)
                            {
                                actionToolStripProgressBar.Value = 100;
                                actionToolStripStatusLabel.Text = "Certificate issued.";

                                MessageBox.Show($"Certificate has been successfully issued", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                PopulateSites();
                                BindConfig();
                            }
                            else
                            {
                                actionToolStripProgressBar.Value = 100;
                                actionToolStripStatusLabel.Text = "Error issuing Certificate.";

                                if (!result.HasValue)
                                    MessageBox.Show("Unable to retreive the generated Certificate.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                else
                                    MessageBox.Show("Error Binding to IIS Site, but certificate generated.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                            }

                        }
                        else
                        {
                            MessageBox.Show($"Could not register ACME service account with service address: {_winCertesOptions.ServiceUri ?? WellKnownServers.LetsEncryptV2.ToString()} e-mail address {_winCertesOptions.Email ?? "<None>"}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }

                        this.Enabled = true;
                        actionToolStripProgressBar.Visible = false;

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

            if (MessageBox.Show($"Are you sure you want to create a new Extra Configuration: {i}", "Create new Configuration", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
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
            var message = @"WinCertes allows you to generate a free certificate using Lets Encrypt or a service of your choice.

You must start by entering the e-mail address you will be registering the certificate with.

If you are using IIS, simply select the Local IIS Server radio button, now select the IIS Site you will be using for the challenge response and if you wish to bind the certificate after, tick the Bind to IIS Site box. If you are hosting multiple domains, you may want to ensure Server Name Indication is ticked.

If you are using the Standalong HTTP Server, select the Standalone HTTP Server radio button and ensure the Server Port is Free, you can still select an IIS site if you wish to bind the certificate to one after generating it.

The Domains box should contain the list of domains to generate the certificate for, if the IIS Site already has bindings, the names will automatically be added, otherwise you must add all the Domains you wish to add to the certificate, remember, this must also include www.

If you want to renew automatically select Schedule a Task to Renew Automatically, 30 days is the default renewal time, it can be less if you want.

If you wish to run a PowerShell Script after generating the certificate, click Browse and select it from the File System, or enter it in the Execute PowerShell Script box, the Tickbox should tick automatically. If you need the Execution Policy to be higher, select one from the PowerShell Execution Policy Dropdown box.

Now click Issue Certificate to generate the certificate.

Once the certificate is generated, you can view the certificate by pressing Show Certificate.

If you need to Revoke the certificate, press the Revoke Certificate button.

You can change the settings at any time, ready for the next renewal, or it will bind the certificate to another IIS Site for you.

Any issues, please report the Issue to the WinCertes GitHub repository.
";

            MessageBox.Show(message, "Help", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
