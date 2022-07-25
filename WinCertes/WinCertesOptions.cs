using NLog;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading;
using WinCertes.ChallengeValidator;
using WinCertes.Config;

namespace WinCertes
{
    /// <summary>
    /// Class to handle the command line parameters given to WinCertes, made public for GUI to access
    /// </summary>
    public class WinCertesOptions
    {
        private static readonly ILogger _logger = LogManager.GetLogger("WinCertes.WinCertesOptions");

        public WinCertesOptions()
        {
            ServiceUri = null;
            Email = null;
            WebRoot = null;
            BindName = null;
            ScriptFile = null;
            ScriptExecutionPolicy = null;
            Standalone = false;
            Revoke = -1;
            Sni = false;
            Csp = null;
            NoCsp = false;
            RenewalDelay = 30;
            HttpPort = 80;
        }
        public string ServiceUri { get; set; }
        public string Email { get; set; }
        public string WebRoot { get; set; }
        public string BindName { get; set; }
        public int BindPort { get; set; }
        public string ScriptFile { get; set; }
        public string ScriptExecutionPolicy { get; set; }
        public bool Standalone { get; set; }
        public int Revoke { get; set; }
        public string Csp { get; set; }
        public bool NoCsp { get; set; }
        public bool Sni { get; set; }
        public int RenewalDelay { get; set; }
        public int HttpPort { get; set; }
        public bool BindSite { get; set; }
        public bool Registered { get; set; }
        public bool PsScript { get; set; }
        public bool PsExecPolicy { get; set; }
        public string DomainsHostId { get; set; }
        public string DomainsFriendlyName { get; set; }
        public string CertSerial { get; set; }
        public bool TaskScheduled { get; set; }

        public Dictionary<string, string> MiscOpts { get; set; }

        /// <summary>
        /// Checks whether the enrolled certificate should be renewed
        /// </summary>
        /// <param name="config">WinCertes config</param>
        /// <returns>true if certificate must be renewed or does not exists, false otherwise</returns>
        public bool IsThereCertificateAndIsItToBeRenewed(List<string> domains, IConfig config)
        {
            string certificateExpirationDate = config.ReadStringParameter("certExpDate" + Utils.DomainsToHostId(domains));
            _logger.Debug(Resources.WinCertesOptions.CertificateExpiration + certificateExpirationDate);
            if ((certificateExpirationDate == null) || (certificateExpirationDate.Length == 0)) return true;
            Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;
            DateTime expirationDate = DateTime.Parse(certificateExpirationDate);
            DateTime futureThresold = DateTime.Now.AddDays(RenewalDelay == 0 ? 30 : RenewalDelay);
            _logger.Debug(Resources.WinCertesOptions.ExpirationThreshold + futureThresold.ToString());
            if (futureThresold > expirationDate) return true;
            _logger.Debug(Resources.WinCertesOptions.CertificateNotRenewed);
            return false;
        }

        public bool IsCertificateToBeRenewed(X509Certificate2 cert)
        {
            Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;
            DateTime expirationDate = DateTime.Parse(cert.GetExpirationDateString());
            DateTime futureThresold = DateTime.Now.AddDays(RenewalDelay == 0 ? 30 : RenewalDelay);
            return (futureThresold > expirationDate);
        }

        /// <summary>
        /// Writes command line parameters into the specified config
        /// </summary>
        /// <param name="config">the configuration object</param>
        /// <param name="forceWrite">Forces writing new Boolean values</param>
        public void WriteOptionsIntoConfiguration(IConfig config, bool forceWrite = false)
        {
            try
            {
                // write service URI into conf, or reads from it, if any
                ServiceUri = config.WriteAndReadStringParameter("serviceUri", ServiceUri);
                // write account email into conf, or reads from it, if any
                Email = config.WriteAndReadStringParameter("accountEmail", Email);
                // Should we work with the built-in web server
                Standalone = config.WriteAndReadBooleanParameter("standalone", Standalone);
                // do we have a webroot parameter to handle?
                WebRoot = config.WriteAndReadStringParameter("webRoot", WebRoot);
                // Should we bind to IIS? If yes, let's do some config
                BindName = config.WriteAndReadStringParameter("bindName", BindName);
                BindPort = config.WriteAndReadIntParameter("bindPort", BindPort, 0);
                BindSite = forceWrite ? config.WriteBooleanParameter("bindSite", BindSite) : config.WriteAndReadBooleanParameter("bindSite", BindSite);
                Sni = forceWrite ? config.WriteBooleanParameter("sni", Sni) : config.WriteAndReadBooleanParameter("sni", Sni);

                // Should we execute some PowerShell ? If yes, let's do some config
                PsScript = forceWrite ? config.WriteBooleanParameter("psScript", PsScript) : config.WriteAndReadBooleanParameter("psScript", PsScript);
                PsExecPolicy = forceWrite ? config.WriteBooleanParameter("psExec", PsExecPolicy) : config.WriteAndReadBooleanParameter("psExec", PsExecPolicy);
                ScriptFile = config.WriteAndReadStringParameter("scriptFile", ScriptFile);
                ScriptExecutionPolicy = config.WriteAndReadStringParameter("scriptExecPolicy", ScriptExecutionPolicy);
                // Writing renewal delay to conf
                RenewalDelay = config.WriteAndReadIntParameter("renewalDays", RenewalDelay, 0);
                // Writing HTTP listening Port in conf
                HttpPort = config.WriteAndReadIntParameter("httpPort", HttpPort, 0);
                // Should we store certificate in the CSP?
                NoCsp = config.WriteAndReadBooleanParameter("noCsp", NoCsp);
                // Let's store the CSP name, if any
                Csp = config.WriteAndReadStringParameter("CSP", Csp);
                // Get some Readonly parameters to help out
                Registered = (config.ReadIntParameter("registered") == 1);

                DomainsHostId = config.ReadStringParameter("domainsHostId");

                // This is to upgrade 1.5.0 or below clients for the GUI (basically get the _xxxx after certSerial) Only works if 1 Certificate has been created in the Config
                if (string.IsNullOrEmpty(DomainsHostId) && config.IsThereConfigParam("certSerial"))
                {
                    IList<string> certs = config.GetCertificateParams("certSerial");
                    if (certs.Count == 1)
                    {
                        DomainsHostId = certs[0];
                        config.WriteStringParameter("domainsHostId", DomainsHostId);
                    }
                }
                CertSerial = config.ReadStringParameter("certSerial" + DomainsHostId);
                DomainsFriendlyName = config.ReadStringParameter("domainsFriendlyName");

                // This is also to upgrade 1.5.0 or below clients for the GUI (basically get the Friendly name from the Certificate)
                if (string.IsNullOrEmpty(DomainsFriendlyName) && !string.IsNullOrEmpty(CertSerial))
                {
                    var cert = Utils.GetCertificateBySerial(CertSerial);
                    if (cert != null && !string.IsNullOrEmpty(cert.FriendlyName))
                    {
                        DomainsFriendlyName = cert.FriendlyName;
                        config.WriteStringParameter("domainsFriendlyName", DomainsFriendlyName);
                    }
                }

                TaskScheduled = Utils.IsScheduledTaskCreated(DomainsFriendlyName);
                foreach (KeyValuePair<string, string> miscOpt in MiscOpts)
                {
                    if (miscOpt.Value.All(char.IsDigit))
                        config.WriteIntParameter(miscOpt.Key, int.Parse(miscOpt.Value));
                    else
                        config.WriteStringParameter(miscOpt.Key, miscOpt.Value);
                }
            }
            catch (Exception e)
            {
                _logger.Error(Resources.WinCertesOptions.ErrorReadWrite + e.Message);
            }
        }

        /// <summary>
        /// Registers certificate into configuration
        /// </summary>
        /// <param name="pfx"></param>
        /// <param name="domains"></param>
        public static void RegisterCertificateIntoConfiguration(X509Certificate2 certificate, List<string> domains, IConfig config)
        {
            // and we write its expiration date to the WinCertes configuration, into "InvariantCulture" date format
            Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;
            var domainsHostId = Utils.DomainsToHostId(domains);
            config.WriteStringParameter("domainsHostId", domainsHostId);
            config.WriteStringParameter("domainsFriendlyName", Utils.DomainsToFriendlyName(domains));
            config.WriteStringParameter("certExpDate" + domainsHostId, certificate.GetExpirationDateString());
            config.WriteStringParameter("certSerial" + domainsHostId, certificate.GetSerialNumberString());
        }

        public static void RemoveCertificateFromConfiguration(X509Certificate2 certificate, IConfig config, string domainsHostId)
        {
            config.DeleteParameter("certExpDate" + domainsHostId);
            config.DeleteParameter("certSerial" + domainsHostId);
            config.DeleteParameter("domainsHostId");
            X509Store store = new X509Store(StoreName.My, StoreLocation.LocalMachine);
            store.Open(OpenFlags.ReadWrite);
            store.Remove(certificate);
            store.Close();
            string task = config.ReadStringParameter("domainsFriendlyName");
            if (task != null)
                Utils.DeleteScheduledTasks(task);
            config.DeleteParameter("domainsFriendlyName");
        }

        public void DisplayOptions(IConfig config)
        {
            if (!config.IsThereConfigParam("accountKey"))
            {
                Console.WriteLine(Resources.WinCertesOptions.NotConfigured);
                return;
            }
            IDNSChallengeValidator dnsChallengeValidator = DNSChallengeValidatorFactory.GetDNSChallengeValidator(config);
            Console.WriteLine(Resources.WinCertesOptions.ServiceURI + "\t" + ((ServiceUri == null) ? Certes.Acme.WellKnownServers.LetsEncryptV2.ToString() : ServiceUri));
            Console.WriteLine(Resources.WinCertesOptions.Email + "\t" + Email);
            Console.WriteLine(Resources.WinCertesOptions.Registered + "\t" + (config.ReadIntParameter("registered") == 1 ? Resources.WinCertesOptions.Yes : Resources.WinCertesOptions.No));
            if (dnsChallengeValidator != null)
            {
                Console.WriteLine(Resources.WinCertesOptions.AuthMode + "\t" + Resources.WinCertesOptions.AuthDNS);
            }
            else
            {
                Console.WriteLine(Resources.WinCertesOptions.AuthMode + "\t" + (Standalone ? Resources.WinCertesOptions.AuthStandalone : Resources.WinCertesOptions.AuthIIS));
                if (Standalone) Console.WriteLine(Resources.WinCertesOptions.HTTPPort + "\t" + HttpPort);
                else Console.WriteLine(Resources.WinCertesOptions.WebRoot + "\t" + WebRoot);
            }
            Console.WriteLine(Resources.WinCertesOptions.IISBind + "\t" + (BindName ?? Resources.WinCertesOptions.None));
            Console.WriteLine(Resources.WinCertesOptions.SNI + "\t" + (config.IsThereConfigParam("sni") ? Resources.WinCertesOptions.Yes : Resources.WinCertesOptions.No));
            Console.WriteLine(Resources.WinCertesOptions.ImportCSP + "\t" + (config.IsThereConfigParam("noCsp") ? Resources.WinCertesOptions.No : Resources.WinCertesOptions.Yes));
            Console.WriteLine(Resources.WinCertesOptions.PSScript + "\t" + (ScriptFile ?? Resources.WinCertesOptions.None));
            Console.WriteLine(Resources.WinCertesOptions.PSExecPolicy + "\t" + (ScriptExecutionPolicy ?? "Undefined"));
            Console.WriteLine(Resources.WinCertesOptions.RenewalDelay + "\t" + RenewalDelay + Resources.WinCertesOptions.Days);
            Console.WriteLine(Resources.WinCertesOptions.Task + "\t" + (Utils.IsScheduledTaskCreated() ? Resources.WinCertesOptions.Yes : Resources.WinCertesOptions.No));
            Console.WriteLine(Resources.WinCertesOptions.Enrolled + "\t" + (config.IsThereConfigParam("certSerial") ? Resources.WinCertesOptions.Yes : Resources.WinCertesOptions.No));
            IList<int> extras = config.GetExtrasConfigParams();
            if (extras.Count > 0) Console.WriteLine(Resources.WinCertesOptions.ExtraConfigs + "\t" + string.Join(", ", extras.Select(n => n.ToString()).ToArray()));
        }
    }
}
