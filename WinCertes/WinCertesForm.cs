using Certes.Acme;
using Microsoft.Web.Administration;
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
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using WinCertes.ChallengeValidator;
using WinCertes.Config;

namespace WinCertes
{
    public partial class WinCertesForm : Form
    {
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
            (_winCertesPath, _certTmpPath) = InitWinCertesDirectoryPath();
            InitializeComponent();
        }

        /// <summary>
        /// Initializes WinCertes Directory path on the filesystem
        /// </summary>
        /// <returns>(WinCertes Path, Cert Temp Path)</returns>
        private static (string, string) InitWinCertesDirectoryPath()
        {
            var _path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData), "WinCertes");
            if (!System.IO.Directory.Exists(_path))
            {
                System.IO.Directory.CreateDirectory(_path);
            }
            var _temp = Path.Combine(_path, "CertsTmp");
            if (!System.IO.Directory.Exists(_temp))
            {
                System.IO.Directory.CreateDirectory(_temp);
            }
            // We fix the permissions for the certs temporary directory
            // so that no user can have access to it
            DirectoryInfo winCertesTmpDi = new DirectoryInfo(_temp);
            DirectoryInfo programDataDi = new DirectoryInfo(Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData));
            if (OperatingSystem.IsWindows())
            {
                DirectorySecurity programDataDs = programDataDi.GetAccessControl(AccessControlSections.All);
                DirectorySecurity winCertesTmpDs = winCertesTmpDi.GetAccessControl(AccessControlSections.All);
                winCertesTmpDs.SetAccessRuleProtection(true, false);
                foreach (FileSystemAccessRule accessRule in programDataDs.GetAccessRules(true, true, typeof(NTAccount)))
                {
                    if (accessRule.IdentityReference.Value.IndexOf("Users", StringComparison.InvariantCultureIgnoreCase) < 0)
                    {
                        winCertesTmpDs.AddAccessRule(accessRule);
                    }
                }
                winCertesTmpDi.SetAccessControl(winCertesTmpDs);
            }
            return (_path, _temp);
        }

        /// <summary>
        /// Initializes the CertesWrapper, and registers the account if necessary
        /// </summary>
        /// <param name="serviceUri">the ACME service URI</param>
        /// <param name="email">the email account used to register</param>
        private async Task<bool> InitCertesWrapperAsync(IConfig config, string serviceUri, string email)
        {
            // We get the CertesWrapper object, that will do most of the job.
            _certesWrapper = new CertesWrapper(config, serviceUri, email);

            // If local computer's account isn't registered on the ACME service, we'll do it.
            if (!_certesWrapper.IsAccountRegistered())
            {
                var regRes = await _certesWrapper.RegisterNewAccount();
                if (!regRes)
                    return false;
            }
            return true;

        }

        /// <summary>
        /// Revoke certificate issued for specified list of domains
        /// </summary>
        /// <param name="domains"></param>
        private async Task<bool?> RevokeCert(int revoke = 0)
        {
            string serial = _config.ReadStringParameter("certSerial" + _winCertesOptions.DomainsHostId);
            if (serial == null)
                return null;

            // Here we revoke from ACME Service. Note that any error is already handled into the wrapper
            if (await _certesWrapper.RevokeCertificate(_cert, revoke))
            {
                _config.DeleteParameter("certExpDate" + _winCertesOptions.DomainsHostId);
                _config.DeleteParameter("certSerial" + _winCertesOptions.DomainsHostId);
                _config.DeleteParameter("domainsHostId");
                X509Store store = new X509Store(StoreName.My, StoreLocation.LocalMachine);
                store.Open(OpenFlags.ReadWrite);
                store.Remove(_cert);
                store.Close();
                _cert = null;
                certButton.Visible = false;
                revokeButton.Visible = false;
                string task = _config.ReadStringParameter("domainsFriendlyName");
                if (task != null)
                    Utils.DeleteScheduledTasks(task);
                _config.DeleteParameter("domainsFriendlyName");
                return true;
            }

            return false;

        }

        private async Task<bool?> IssueCert(List<string> domains, string taskName = null)
        {
            bool? result = null;

            // Now the real stuff: we register the order for the domains, and have them validated by the ACME service
            IHTTPChallengeValidator httpChallengeValidator = HTTPChallengeValidatorFactory.GetHTTPChallengeValidator(_winCertesOptions.Standalone, _winCertesOptions.HttpPort, _winCertesOptions.WebRoot);

            // Not supporting DNS yet!
            // IDNSChallengeValidator dnsChallengeValidator = DNSChallengeValidatorFactory.GetDNSChallengeValidator(_config);
            IDNSChallengeValidator dnsChallengeValidator = null;
            if ((httpChallengeValidator == null) && (dnsChallengeValidator == null)) { MessageBox.Show("Specify either an HTTP or a DNS validation method.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation); return false; }
            if (!await _certesWrapper.RegisterNewOrderAndVerify(domains, httpChallengeValidator, dnsChallengeValidator)) { if (httpChallengeValidator != null) httpChallengeValidator.EndAllChallengeValidations(); return false; }
            if (httpChallengeValidator != null) httpChallengeValidator.EndAllChallengeValidations();

            // We get the certificate from the ACME service
            var pfx = await _certesWrapper.RetrieveCertificate(domains, _certTmpPath, Utils.DomainsToFriendlyName(domains));
            if (pfx == null) return null;


            // Currently only supporting the default Csp
            CertificateStorageManager certificateStorageManager = new CertificateStorageManager(pfx, true);
            // Let's process the PFX into Windows Certificate objet.
            certificateStorageManager.ProcessPFX();
            // and we write its information to the WinCertes configuration
            RegisterCertificateIntoConfiguration(certificateStorageManager.Certificate, domains);
            // Import the certificate into the Windows store
            if (!_winCertesOptions.noCsp) certificateStorageManager.ImportCertificateIntoCSP(_winCertesOptions.Csp);

            // Bind certificate to IIS Site (won't do anything if option is null)
            if (Utils.BindCertificateForIISSite(certificateStorageManager.Certificate, _winCertesOptions.BindName, _winCertesOptions.BindPort, _winCertesOptions.Sni))
                result = true;
            else
                result = string.IsNullOrEmpty(_winCertesOptions.BindName);

            // Execute PowerShell Script (won't do anything if option is null)
            Utils.ExecutePowerShell(_winCertesOptions.ScriptFile, pfx, _winCertesOptions.ScriptExecutionPolicy);
            // Create the AT task that will execute WinCertes periodically (won't do anything if taskName is null)
            Utils.CreateScheduledTask(taskName, domains, _extra);

            // Let's delete the PFX file
            File.Delete(pfx.PfxFullPath);
            File.Delete(pfx.PemCertPath);
            File.Delete(pfx.PemKeyPath);

            return result;
        }

        /// <summary>
        /// Registers certificate into configuration
        /// </summary>
        /// <param name="pfx"></param>
        /// <param name="domains"></param>
        private void RegisterCertificateIntoConfiguration(X509Certificate2 certificate, List<string> domains)
        {
            // and we write its expiration date to the WinCertes configuration, into "InvariantCulture" date format
            Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;
            var domainsHostId = Utils.DomainsToHostId(domains);
            _config.WriteStringParameter("domainsHostId", domainsHostId);
            _config.WriteStringParameter("domainsFriendlyName", Utils.DomainsToFriendlyName(domains));
            _config.WriteStringParameter("certExpDate" + domainsHostId, certificate.GetExpirationDateString());
            _config.WriteStringParameter("certSerial" + domainsHostId, certificate.GetSerialNumberString());
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

            psExecCheckBox.Checked = _winCertesOptions.PsExec && psExecComboBox.Text != "Undefined";

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
                    Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;
                    DateTime expirationDate = DateTime.Parse(_cert.GetExpirationDateString());
                    DateTime futureThresold = DateTime.Now.AddDays(_winCertesOptions.RenewalDelay == 0 ? 30 : _winCertesOptions.RenewalDelay);
                    if (futureThresold > expirationDate)
                    {
                        issueButton.Text = "Renew Certificate";
                        issueButton.Visible = true;
                    }
                    else
                    {
                        issueButton.Visible = false;
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
                issueButton.Visible = false;
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
                    issueButton.Visible = !_iisBound;
                }
            }

            var extras = _config.getExtrasConfigParams();

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
            if (domainsListBox.Items.Count > 0
                && !string.IsNullOrEmpty(serviceComboBox.Text)
                && emailTextBox.Text.Contains("@")
                && issueButton.Text == "Issue Certificate")
            {
                if (standaloneRadioButton.Checked && CheckPort())
                    issueButton.Visible = true;
                else if (iisRadioButton.Checked && sitesListBox.SelectedIndex > -1 && !string.IsNullOrEmpty(webRootLabel.Text))
                    issueButton.Visible = true;
                else
                    issueButton.Visible = false;
            }
            else if (issueButton.Text == "Update Settings")
                issueButton.Visible = ((iisCheckBox.Checked != _winCertesOptions.BindSite)
                                            || (sniCheckBox.Checked != _winCertesOptions.Sni)
                                            || (iisPortNumericUpDown.Value != (_winCertesOptions.BindPort == 0 ? 443 : _winCertesOptions.BindPort))
                                            || (psScriptCheckBox.Checked != _winCertesOptions.PsScript)
                                            || (psScriptTextBox.Text != (_winCertesOptions.ScriptFile ?? ""))
                                            || (psExecCheckBox.Checked != _winCertesOptions.PsExec)
                                            || (psExecComboBox.Text != (_winCertesOptions.ScriptExecutionPolicy ?? "Undefined"))
                                            || (taskCheckBox.Checked != _winCertesOptions.TaskScheduled)
                                            || (renewalNumericUpDown.Value != _winCertesOptions.RenewalDelay)
                                            || (sitesListBox.SelectedItem != null && sitesListBox.Text != _winCertesOptions.BindName)
                                            || (standaloneRadioButton.Checked && httpPortNumericUpDown.Value != (_winCertesOptions.HttpPort == 0 ? 80 : _winCertesOptions.HttpPort)));
            else if (issueButton.Text != "Renew Certificate")
                issueButton.Visible = false;
            else
                issueButton.Visible = false;

            return issueButton.Visible;
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
                    catch (ArgumentException)
                    {
                        continue;
                    }


                }

                CheckIssue();
            }
        }

        private void browseButton_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "PowerShell Scripts (*.ps1)|*.ps1|All files (*.*)|*.*";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                psScriptTextBox.Text = openFileDialog1.FileName;
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
        }

        private void standaloneRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            standaloneGroupBox.Enabled = standaloneRadioButton.Checked;

            checkPortButton.Visible = false;
            if (standaloneRadioButton.Checked)
                CheckPort();
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
        }

        private async void revokeButton_ClickAsync(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you wish to Revoke and delete the Certificate?", "Are you sure?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                if (await InitCertesWrapperAsync(_config, _winCertesOptions.ServiceUri, _winCertesOptions.Email) && _certesWrapper != null)
                {
                    var result = await RevokeCert();
                    if (result.HasValue && result.Value)
                    {
                        MessageBox.Show($"Certificate has been successfully revoked", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        BindConfig();
                    }
                    else if (!result.HasValue)
                        MessageBox.Show("Could not find configuration or configuration does not match Certificate domains.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    else
                        MessageBox.Show("Error revoking certificate.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                    MessageBox.Show($"Could not register ACME service account with service address: {_winCertesOptions.ServiceUri ?? WellKnownServers.LetsEncryptV2.ToString()} e-mail address {_winCertesOptions.Email ?? "<None>"}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                    if (psExecCheckBox.Checked != _winCertesOptions.PsExec) message += $"Setting PowerShell Script Execution Policy will be updated to {(psExecCheckBox.Checked ? "On" : "Off")}.\r\n";
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
                        _winCertesOptions.BindPort = (int)iisPortNumericUpDown.Value;
                        _winCertesOptions.Sni = sniCheckBox.Checked;
                        _winCertesOptions.BindName = sitesListBox.SelectedItem != null ? sitesListBox.Text : null;
                        _winCertesOptions.BindSite = iisCheckBox.Checked;
                        _winCertesOptions.BindPort = (int)iisPortNumericUpDown.Value;
                        _winCertesOptions.PsScript = psScriptCheckBox.Checked;
                        _winCertesOptions.PsExec = psExecCheckBox.Checked;
                        _winCertesOptions.ScriptExecutionPolicy = psExecComboBox.Text;
                        _winCertesOptions.ScriptFile = psScriptTextBox.Text.Trim();
                        _winCertesOptions.WebRoot = webRootLabel.Text;
                        _winCertesOptions.RenewalDelay = (int)renewalNumericUpDown.Value;

                        if (taskCheckBox.Checked)
                            Utils.CreateScheduledTask(taskName, domains, _extra);
                        else if (taskName != null)
                            Utils.DeleteScheduledTasks(taskName);

                        _winCertesOptions.WriteOptionsIntoConfiguration(_config, true);

                        if (iisCheckBox.Checked && !_iisBound)
                        {
                            if (Utils.BindCertificateForIISSite(_cert, _winCertesOptions.BindName, _winCertesOptions.BindPort, _winCertesOptions.Sni))
                            {
                                MessageBox.Show($"Certificate successfully rebound to IIS Site.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                PopulateSites();
                            }
                            else
                                MessageBox.Show($"Certificate failed to bind to IIS Site.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }


                        BindConfig();
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
                    _winCertesOptions.PsExec = psExecCheckBox.Checked;
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
                        _winCertesOptions.WriteOptionsIntoConfiguration(_config, true);

                        if (await InitCertesWrapperAsync(_config, _winCertesOptions.ServiceUri, _winCertesOptions.Email) && _certesWrapper != null)
                        {
                            var result = await IssueCert(domains, taskName);
                            if (result.HasValue && result.Value)
                            {
                                MessageBox.Show($"Certificate has been successfully issued", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                PopulateSites();
                                BindConfig();
                            }
                            else if (!result.HasValue)
                                MessageBox.Show("Unable to retreive the generated Certificate.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            else
                                MessageBox.Show("Error Binding to IIS Site, but certificate generated.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        else
                            MessageBox.Show($"Could not register ACME service account with service address: {_winCertesOptions.ServiceUri ?? WellKnownServers.LetsEncryptV2.ToString()} e-mail address {_winCertesOptions.Email ?? "<None>"}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void newConfigButton_Click(object sender, EventArgs e)
        {
            var extras = _config.getExtrasConfigParams();
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
    }
}
