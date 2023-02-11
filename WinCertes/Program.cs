using Mono.Options;
using NLog;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Security.Cryptography.X509Certificates;
using System.Threading;
using System.Threading.Tasks;
using WinCertes.ChallengeValidator;
using System.Windows.Forms;
using WinCertes.Config;
using System.Runtime.InteropServices;
using System.Resources;

[assembly: NeutralResourcesLanguage("en")]
namespace WinCertes
{
    class Program
    {
        /// <summary>
        /// Import to free the Console Window when the windows form runs from Explorer
        /// </summary>
        /// <returns></returns>
        [DllImport("kernel32.dll")]
        private static extern IntPtr FreeConsole();

        private static readonly ILogger _logger = LogManager.GetLogger("WinCertes");

        private static CertesWrapper _certesWrapper;
        private static IConfig _config;
        private static string _winCertesPath;
        private static string _certTmpPath;
        private static WinCertesOptions _winCertesOptions;
        private static List<string> _domains;
        private static bool _periodic = false;
        private static bool _show = false;
        private static bool _reset = false;
        private static int _extra = -1;
        private static OptionSet _options;

        private static readonly int ERROR = 1;
        private static readonly int ERROR_INCORRECT_PARAMETER = 2;


        /// <summary>
        /// Handles command line options
        /// </summary>
        /// <param name="args">the command line options</param>
        /// <returns></returns>
        private static bool HandleOptions(string[] args)
        {
            _domains = new List<string>();
            bool _help = false;
            _winCertesOptions.MiscOpts = new Dictionary<string, string>();

            // Options that can be used by this application
            _options = new OptionSet() {
                { "s|service=", Resources.Program.OptionService, v => _winCertesOptions.ServiceUri = v },
                { "e|email=", Resources.Program.OptionEmail, v => _winCertesOptions.Email = v },
                { "d|domain=", Resources.Program.OptionDomain, v => _domains.Add(v) },
                { "w|webserver:", Resources.Program.OptionWebServer, v => _winCertesOptions.WebRoot = v ?? "c:\\inetpub\\wwwroot" },
                { "p|periodic", Resources.Program.OptionPeriodic, v => _periodic = (v != null) },
                { "b|bindname=", Resources.Program.OptionBindName, v => _winCertesOptions.BindName = v },
                { "n|bindport=", Resources.Program.OptionBindPort, (int v) => _winCertesOptions.BindPort = v },
                { "i|sni", Resources.Program.OptionSNI, v => _winCertesOptions.Sni = (v != null) },
                { "f|scriptfile=", Resources.Program.OptionScriptFile, v => _winCertesOptions.ScriptFile = v },
                { "x|execpolicy=", Resources.Program.OptionExecPolicy, v => _winCertesOptions.ScriptExecutionPolicy = v },
                { "a|standalone", Resources.Program.OptionStandalone, v => _winCertesOptions.Standalone = (v != null) },
                { "r|revoke:", Resources.Program.OptionRevoke, (int v) => _winCertesOptions.Revoke = v },
                { "k|csp=", Resources.Program.OptionCSP, v => _winCertesOptions.Csp = v },
                { "t|renewal=", Resources.Program.OptionRenewal, (int v) => _winCertesOptions.RenewalDelay = v },
                { "l|listenport=", Resources.Program.OptionListenPort, (int v) => _winCertesOptions.HttpPort = v },
                { "h|?|help", Resources.Program.OptionHelp, (v => _help = (v != null)) },
                { "show", Resources.Program.OptionShow, v=> _show = (v != null ) },
                { "reset", Resources.Program.OptionReset, (int v) => _extra = v },
                { "no-csp", Resources.Program.OptionNoCSP, v=> _winCertesOptions.NoCsp = (v != null) },
                { "setopt={:}", Resources.Program.OptionSetOpt, (k,v) => _winCertesOptions.MiscOpts.Add(k,v)  }
            };

            // and the handling of these options
            List<string> res;
            try
            {
                res = _options.Parse(args);
            }
            catch (Exception e) { WriteErrorMessageWithUsage(_options, e.Message); return false; }
            if (_help) { WriteErrorMessageWithUsage(_options, Resources.Program.NoCLIforGUI); return false; }
            if ((!_show) && (!_reset) && (_domains.Count == 0)) { WriteErrorMessageWithUsage(_options, Resources.Program.NoDomains); return false; }
            if (_winCertesOptions.Revoke > 5) { WriteErrorMessageWithUsage(_options, Resources.Program.RevokeReason); return false; }
            _domains = _domains.ConvertAll(d => d.ToLower());
            return true;
        }

        /// <summary>
        /// Writes the error message when handling options
        /// </summary>
        /// <param name="options"></param>
        /// <param name="message"></param>
        private static void WriteErrorMessageWithUsage(OptionSet options, string message)
        {
            Console.WriteLine("WinCertes.exe: " + message);
            options.WriteOptionDescriptions(Console.Out);
            Console.WriteLine(Resources.Program.ExampleUsage);
        }

        /// <summary>
        /// Revoke certificate issued for specified list of domains
        /// </summary>
        /// <param name="domains"></param>
        private static void RevokeCert(List<string> domains, int revoke)
        {
            string serial = _config.ReadStringParameter("certSerial" + Utils.DomainsToHostId(domains));
            if (serial == null)
            {
                _logger.Error(string.Format(Resources.Program.NoFindCertificateDomain, domains[0]));
                return;
            }
            X509Certificate2 cert = Utils.GetCertificateBySerial(serial);
            if (cert == null)
            {
                _logger.Error(string.Format(Resources.Program.NoFindCertificateSerial, serial));
                return;
            }
            // Here we revoke from ACME Service. Note that any error is already handled into the wrapper
            if (Task.Run(() => _certesWrapper.RevokeCertificate(cert, revoke)).GetAwaiter().GetResult())
            {
                WinCertesOptions.RemoveCertificateFromConfiguration(cert, _config, Utils.DomainsToHostId(domains));
                _logger.Info(string.Format(Resources.Program.SuccessRevokeSerialDomains, serial, string.Join(",", domains)));
            }
        }

        /// <summary>
        /// Initializes the CertesWrapper, and registers the account if necessary
        /// </summary>
        /// <param name="serviceUri">the ACME service URI</param>
        /// <param name="email">the email account used to register</param>
        private static void InitCertesWrapper(IConfig config, string serviceUri, string email)
        {
            // We get the CertesWrapper object, that will do most of the job.
            _certesWrapper = new CertesWrapper(config, serviceUri, email);

            // If local computer's account isn't registered on the ACME service, we'll do it.
            if (!_certesWrapper.IsAccountRegistered())
            {
                var regRes = Task.Run(() => _certesWrapper.RegisterNewAccount()).GetAwaiter().GetResult();
                if (!regRes)
                    throw new Exception(Resources.Program.FailedRegisterAccount);
            }
        }

        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static int Main(string[] args)
        {
#if DEBUG
            // Change to the culture you are translating into.
            //CultureInfo culture = CultureInfo.CreateSpecificCulture("fr-FR");
            //CultureInfo.DefaultThreadCurrentCulture = culture;
            //CultureInfo.DefaultThreadCurrentUICulture = culture;
            //Thread.CurrentThread.CurrentCulture = culture;
            //Thread.CurrentThread.CurrentUICulture = culture;
#endif

            // If No Parameters show the GUI and hide the console.
            if (args.Length == 0 && OperatingSystem.IsWindows())
            {
                Console.WriteLine(Resources.Program.LaunchGUI);
                Application.SetHighDpiMode(HighDpiMode.SystemAware);
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                if (!Utils.IsAdministrator()) { MessageBox.Show(Resources.Program.NoAdminGUI, Resources.Program.Error, MessageBoxButtons.OK, MessageBoxIcon.Error); return ERROR; }
                // This hides the Console if ran from Explorer.
                FreeConsole();
                Application.Run(new WinCertesForm());
                return 0;
            }

            // Main parameters with their default values
            string taskName = null;
            _winCertesOptions = new WinCertesOptions();

            if (!Utils.IsAdministrator()) { Console.WriteLine(Resources.Program.NoAdmin); return ERROR; }
            // Command line options handling and initialization stuff
            if (!HandleOptions(args)) return ERROR_INCORRECT_PARAMETER;
            if (_periodic) taskName = Utils.DomainsToFriendlyName(_domains);
            (_winCertesPath, _certTmpPath) = Utils.InitWinCertesDirectoryPath();
            Utils.ConfigureLogger(_winCertesPath);
            _config = new RegistryConfig(_extra);
            _winCertesOptions.WriteOptionsIntoConfiguration(_config);
            if (_show) { _winCertesOptions.DisplayOptions(_config); return 0; }

            // Reset is a full reset if --extra is not specified!
            if (_reset)
            {
                if (_extra == -1)
                {
                    IConfig baseConfig = new RegistryConfig(-1);
                    baseConfig.DeleteAllParameters();
                    Utils.DeleteScheduledTasks();
                }
                else
                {
                    if (!string.IsNullOrEmpty(_winCertesOptions.DomainsFriendlyName))
                        Utils.DeleteScheduledTasks(_winCertesOptions.DomainsFriendlyName);
                    _config.DeleteAllParameters(_extra);
                }
                return 0;
            }

            // Initialization and renewal/revocation handling
            try
            {
                InitCertesWrapper(_config, _winCertesOptions.ServiceUri, _winCertesOptions.Email);
            }
            catch (Exception e) { _logger.Error(e.Message); return ERROR; }
            if (_winCertesOptions.Revoke > -1) { RevokeCert(_domains, _winCertesOptions.Revoke); return 0; }
            // default mode: enrollment/renewal. check if there's something to be done
            // note that in any case, we want to be able to set the scheduled task (won't do anything if taskName is null)
            if (!_winCertesOptions.IsThereCertificateAndIsItToBeRenewed(_domains, _config)) { Utils.CreateScheduledTask(taskName, _domains, _extra); return 0; }

            // Now the real stuff: we register the order for the domains, and have them validated by the ACME service
            IHTTPChallengeValidator httpChallengeValidator = HTTPChallengeValidatorFactory.GetHTTPChallengeValidator(_winCertesOptions.Standalone, _winCertesOptions.HttpPort, _winCertesOptions.WebRoot);
            IDNSChallengeValidator dnsChallengeValidator = DNSChallengeValidatorFactory.GetDNSChallengeValidator(_config);
            if ((httpChallengeValidator == null) && (dnsChallengeValidator == null)) { WriteErrorMessageWithUsage(_options, Resources.Program.HTTPorDNS); return ERROR_INCORRECT_PARAMETER; }
            if (!(Task.Run(() => _certesWrapper.RegisterNewOrderAndVerify(_domains, httpChallengeValidator, dnsChallengeValidator)).GetAwaiter().GetResult())) { if (httpChallengeValidator != null) httpChallengeValidator.EndAllChallengeValidations(); return ERROR; }
            if (httpChallengeValidator != null) httpChallengeValidator.EndAllChallengeValidations();

            // We get the certificate from the ACME service
            var pfx = Task.Run(() => _certesWrapper.RetrieveCertificate(_domains, _certTmpPath, Utils.DomainsToFriendlyName(_domains))).GetAwaiter().GetResult();
            if (pfx == null) return ERROR;
            CertificateStorageManager certificateStorageManager = new CertificateStorageManager(pfx, ((_winCertesOptions.Csp == null) && (!_winCertesOptions.NoCsp)));
            // Let's process the PFX into Windows Certificate objet.
            certificateStorageManager.ProcessPFX();
            // and we write its information to the WinCertes configuration
            WinCertesOptions.RegisterCertificateIntoConfiguration(certificateStorageManager.Certificate, _domains, _config);
            // Import the certificate into the Windows store
            if (!_winCertesOptions.NoCsp) certificateStorageManager.ImportCertificateIntoCSP(_winCertesOptions.Csp);

            // Bind certificate to IIS Site (won't do anything if option is null)
            if (Utils.BindCertificateForIISSite(certificateStorageManager.Certificate, _winCertesOptions.BindName, _winCertesOptions.BindPort, _winCertesOptions.Sni))
                _logger.Info(Resources.Program.SuccessBind + _winCertesOptions.BindName);
            else
                _logger.Debug(Resources.Program.NoBound);
            // Execute PowerShell Script (won't do anything if option is null)
            Utils.ExecutePowerShell(_winCertesOptions.PsScript ? _winCertesOptions.ScriptFile : null, pfx, _winCertesOptions.PsExecPolicy ? _winCertesOptions.ScriptExecutionPolicy : null);
            // Create the AT task that will execute WinCertes periodically (won't do anything if taskName is null)
            Utils.CreateScheduledTask(taskName, _domains, _extra);

            // Let's delete the PFX file
            Utils.RemoveFileAndLog(pfx);

            return 0;
        }
    }
}
