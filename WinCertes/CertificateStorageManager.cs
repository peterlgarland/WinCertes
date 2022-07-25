using NLog;
using System;
using System.Diagnostics;
using System.Security.Cryptography.X509Certificates;

namespace WinCertes
{
    public class CertificateStorageManager
    {
        private static readonly ILogger _logger = LogManager.GetLogger("WinCertes.CertificateStorageManager");

        public AuthenticatedPFX AuthenticatedPFX { get; set; }
        public X509Certificate2 Certificate { get; set; }
        private readonly bool _defaultCSP;

        /// <summary>
        /// Class constructor
        /// </summary>
        /// <param name="authenticatedPFX">the PFX that we will store</param>
        /// <param name="useDefaultCSP">do we use the default CSP to store the certificate?</param>
        public CertificateStorageManager(AuthenticatedPFX authenticatedPFX, bool useDefaultCSP)
        {
            AuthenticatedPFX = authenticatedPFX;
            Certificate = null;
            _defaultCSP = useDefaultCSP;
        }

        /// <summary>
        /// Process PFX to extract its certificate/key into Windows objects
        /// </summary>
        public void ProcessPFX()
        {
            try {
                // If we use the default CSP, then the key should be persisted as local machine while we parse the certificate
                X509KeyStorageFlags flags = X509KeyStorageFlags.MachineKeySet | X509KeyStorageFlags.PersistKeySet;
                // else it should be left non-persistent so that it can disappear after treatment
                if (!_defaultCSP) {
                    _logger.Debug(Resources.CertificateStorageManager.NotImportingCSP);
                    flags = X509KeyStorageFlags.DefaultKeySet | X509KeyStorageFlags.Exportable; 
                }
                Certificate = new X509Certificate2(AuthenticatedPFX.PfxFullPath, AuthenticatedPFX.PfxPassword, flags);
            } catch (Exception e) {
                _logger.Error($"{Resources.CertificateStorageManager.ErrorExtractingPFX} {e.Message}");
            }
        }

        /// <summary>
        /// Imports the member certificate into default windows store. ProcessPFX must be called before this method.
        /// </summary>
        public void ImportCertificateIntoDefaultCSP()
        {
            if (Certificate == null) { _logger.Error(Resources.CertificateStorageManager.ErrorNoCertificate); return; }
            try {
                X509Store store = new X509Store(StoreName.My, StoreLocation.LocalMachine);
                store.Open(OpenFlags.ReadWrite);
                store.Add(Certificate);
                store.Close();
                _logger.Info(string.Format(Resources.CertificateStorageManager.StoreCertificateSubject, Certificate.Subject));
                // Now let's try to import the full chain
                try {
                    X509Certificate2Collection certCol = new X509Certificate2Collection();
                    X509KeyStorageFlags flags = X509KeyStorageFlags.MachineKeySet | X509KeyStorageFlags.PersistKeySet;
                    certCol.Import(AuthenticatedPFX.PfxFullPath, AuthenticatedPFX.PfxPassword, flags);
                    foreach (X509Certificate2 certFile in certCol) {
                        if (certFile.Equals(Certificate)) continue;
                        store = new X509Store(StoreName.CertificateAuthority, StoreLocation.LocalMachine);
                        store.Open(OpenFlags.ReadWrite);
                        store.Add(certFile);
                        store.Close();
                    }
                } catch (Exception) { /* discarded as it's not so important if it fails */ }
            } catch (Exception e) {
                _logger.Error(e,$"{Resources.CertificateStorageManager.ErrorImportingCSP} {e.Message}");
            }
        }

        /// <summary>
        /// Imports PFX into specified CSP/KSP
        /// </summary>
        /// <param name="KSP">the CSP/KSP name</param>
        public void ImportPFXIntoKSP(string KSP)
        {
            try {
                Process process = new Process();
                process.StartInfo.FileName = @"c:\Windows\System32\certutil.exe";
                process.StartInfo.Arguments = $"-importPFX -p {AuthenticatedPFX.PfxPassword} -csp \"{KSP}\" -f My \"{AuthenticatedPFX.PfxFullPath}\"";
                process.StartInfo.UseShellExecute = false;
                process.StartInfo.RedirectStandardOutput = true;
                process.StartInfo.CreateNoWindow = true;
                process.Start();
                string output = "";
                while (!process.StandardOutput.EndOfStream) {
                    output += process.StandardOutput.ReadLine() + "\n";
                }
                process.WaitForExit();
                _logger.Debug(output);
                if (output.Contains("FAILED")) {
                    _logger.Error(string.Format(Resources.CertificateStorageManager.ErrorImportKSPOutMsg, KSP, output));
                } else {
                    _logger.Info($"{Resources.CertificateStorageManager.SuccessImportKSP} {KSP}");
                }
            } catch (Exception e) {
                _logger.Error(string.Format(Resources.CertificateStorageManager.ErrorImportKSPOutMsg, KSP, e.Message));
            }
        }

        /// <summary>
        /// Imports the certificate into the specified CSP, or into default one if csp parameter is null
        /// </summary>
        /// <param name="csp">the name of the csp/ksp to import certificate</param>
        public void ImportCertificateIntoCSP(string csp = null)
        {
            if (csp == null) {
                this.ImportCertificateIntoDefaultCSP();
            } else {
                this.ImportPFXIntoKSP(csp);
            }
        }
    }
}
