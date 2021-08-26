﻿using Microsoft.Web.Administration;
using NLog;
using NLog.Config;
using NLog.Targets;
using Org.BouncyCastle.Crypto;
using Org.BouncyCastle.Crypto.Parameters;
using Org.BouncyCastle.Math;
using Org.BouncyCastle.OpenSsl;
using Org.BouncyCastle.Security;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Management.Automation.Runspaces;
using System.Reflection;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Security.Principal;
using System.Text;
using System.Text.RegularExpressions;
using TS = Microsoft.Win32.TaskScheduler;


namespace WinCertes
{
    /// <summary>
    /// Convenience class to store PFX and its password together
    /// </summary>
    public class AuthenticatedPFX
    {
        /// <summary>
        /// Constructor for the class
        /// </summary>
        /// <param name="pfxFullPath"></param>
        /// <param name="pfxPassword"></param>
        public AuthenticatedPFX(string pfxFullPath, string pfxPassword, string pemCertPath, string pemKeyPath)
        {
            PfxFullPath = pfxFullPath;
            PfxPassword = pfxPassword;
            PemCertPath = pemCertPath;
            PemKeyPath = pemKeyPath;
        }

        /// <summary>
        /// Full path to the pfx, including the PFX
        /// </summary>
        public string PfxFullPath { get; private set; }

        /// <summary>
        /// PFX password
        /// </summary>
        public string PfxPassword { get; private set; }

        /// <summary>
        /// Full path to the PEM certificate
        /// </summary>
        public string PemCertPath { get; private set; }

        /// <summary>
        /// Full path to the PEM private key
        /// </summary>
        public string PemKeyPath { get; private set; }
    }

    /// <summary>
    /// This static class is a catalog of static methods to be used for various purposes within WinCertes
    /// </summary>
    public static class Utils
    {
        private static readonly ILogger logger = LogManager.GetLogger("WinCertes.Utils");

        /// <summary>
        /// Executes powershell script scriptFile
        /// </summary>
        /// <param name="scriptFile"></param>
        /// <param name="pfx"></param>
        /// <param name="pfxPassword"></param>
        /// <returns></returns>
        public static bool ExecutePowerShell(string scriptFile, AuthenticatedPFX pfx, string executionPolicy)
        {
            if (scriptFile == null) return false;
            try
            {
                // First let's create the execution runspace
                Runspace runspace = RunspaceFactory.CreateRunspace();
                runspace.Open();

                if (!string.IsNullOrEmpty(executionPolicy))
                {
                    // Create a new Pipeline to set the Execution Policy
                    Pipeline execPolicyPipeline = runspace.CreatePipeline();

                    // Now add the command 'Set-ExecutionPolicy' to the pipeline to ensure Scripts are allowed to run
                    Command execPolicy = new Command("Set-ExecutionPolicy");
                    CommandParameter policy = new CommandParameter("ExecutionPolicy", executionPolicy);
                    execPolicy.Parameters.Add(policy);

                    // add the created Command to the pipeline
                    execPolicyPipeline.Commands.Add(execPolicy);

                    // and we invoke it to set the Policy before trying to run the script
                    execPolicyPipeline.Invoke();
                }

                // Now we create the pipeline
                Pipeline pipeline = runspace.CreatePipeline();

                // We create the script to execute with its arguments as a Command
                System.Management.Automation.Runspaces.Command myCommand = new System.Management.Automation.Runspaces.Command(scriptFile);
                CommandParameter pfxParam = new CommandParameter("pfx", pfx.PfxFullPath);
                myCommand.Parameters.Add(pfxParam);
                CommandParameter pfxPassParam = new CommandParameter("pfxPassword", pfx.PfxPassword);
                myCommand.Parameters.Add(pfxPassParam);
                CommandParameter cerParam = new CommandParameter("cer", pfx.PemCertPath);
                myCommand.Parameters.Add(cerParam);
                CommandParameter keyParam = new CommandParameter("key", pfx.PemKeyPath);
                myCommand.Parameters.Add(keyParam);

                // add the created Command to the pipeline
                pipeline.Commands.Add(myCommand);

                // and we invoke it
                var results = pipeline.Invoke();
                logger.Info($"Executed script {scriptFile}.");
                return true;
            }
            catch (Exception e)
            {
                logger.Error($"Could not execute {scriptFile}: {e.Message}");
                return false;
            }
        }

        /// <summary>
        /// Gets a List of Sites from the local IIS server
        /// </summary>
        /// <returns>null if failed, or a List of Sites</returns>
        public static SiteCollection GetIISSites()
        {
            try
            {
                ServerManager serverMgr = new ServerManager();
                if (serverMgr == null) return null;
                return serverMgr.Sites;

            }
            catch (Exception)
            {
                return null;
            }
        }

        /// <summary>
        /// Binds the specified certificate located in "MY" store to the specified IIS site on the local machine
        /// </summary>
        /// <param name="certificate"></param>
        /// <param name="siteName"></param>
        /// <returns>true in case of success, false otherwise</returns>
        public static bool BindCertificateForIISSite(X509Certificate2 certificate, string siteName, int port, bool sni)
        {
            if (siteName == null) return false;
            try
            {
                ServerManager serverMgr = new ServerManager();
                Site site = serverMgr.Sites[siteName];
                if (site == null)
                {
                    logger.Error($"Could not find IIS site {siteName}");
                    return false;
                }
                // Use whether they want SNI on, rather than it not being on Port 0 = 443
                if (!sni)
                {
                    bool foundBinding = false;
                    foreach (Binding binding in site.Bindings)
                    {
                        if (binding.Protocol == "https")
                        {
                            if (binding.EndPoint.Port == port)
                            {
                                binding.CertificateHash = certificate.GetCertHash();
                                binding.CertificateStoreName = "MY";
                                foundBinding = true;
                                logger.Debug("Found binding by port for site: " + siteName + " Will update it with cert with serial: " + certificate.SerialNumber);
                            }
                        }
                    }
                    if (!foundBinding)
                    {
                        Binding binding = site.Bindings.Add("*:" + port + ":", certificate.GetCertHash(), "MY");
                        binding.Protocol = "https";
                        // This is technically not necessary, but seems it doesn't always put the Hash on the binding without this extra confirmation!
                        binding.CertificateHash = certificate.GetCertHash();
                        binding.CertificateStoreName = "MY";
                        logger.Debug("Could not find binding, will try to create one on port " + port);
                    }
                }
                else
                {
                    foreach (string sanDns in ParseSubjectAlternativeName(certificate))
                    {
                        bool foundBinding = false;
                        foreach (Binding binding in site.Bindings)
                        {
                            if (binding.Protocol == "https")
                            {
                                if (binding.Host.Equals(sanDns, StringComparison.OrdinalIgnoreCase))
                                {
                                    binding.CertificateHash = certificate.GetCertHash();
                                    binding.CertificateStoreName = "MY";
                                    foundBinding = true;
                                    logger.Debug("Found binding by hostname for site: " + siteName + " Will update it with cert with serial: " + certificate.SerialNumber);
                                }
                            }
                        }
                        if (!foundBinding)
                        {
                            // Use whatever port is specified (or 443 if it's 0)
                            Binding binding = site.Bindings.Add("*:" + (port == 0 ? 443 : port) + ":" + sanDns, certificate.GetCertHash(), "MY");
                            binding.Protocol = "https";
                            // This is technically not necessary, but seems it doesn't always put the Hash on the binding without this extra confirmation!
                            binding.CertificateHash = certificate.GetCertHash();
                            binding.SslFlags = SslFlags.Sni;
                            binding.CertificateStoreName = "MY";
                            logger.Debug("Could not find binding, will try to create one on port 443");
                        }
                    }
                }
                if (site.ApplicationDefaults.EnabledProtocols.Split(',').Contains("http"))
                    site.ApplicationDefaults.EnabledProtocols = "http,https";
                else
                    site.ApplicationDefaults.EnabledProtocols = "https";
                serverMgr.CommitChanges();
                return true;
            }
            catch (Exception e)
            {
                logger.Error(e, $"Could not bind certificate to site {siteName}: {e.Message}");
                return false;
            }
        }

        /// <summary>
        /// Gets a list of the additional DNS Names on the certificate
        /// </summary>
        /// <param name="cert">The certificate to get SAN Addresses from</param>
        /// <returns>List of domain names</returns>
        public static List<string> ParseSubjectAlternativeName(X509Certificate2 cert)
        {
            var result = new List<string>();
            var subjectAlternativeName = cert.Extensions.Cast<X509Extension>()
                                                .Where(n => n.Oid.FriendlyName.Equals("Subject Alternative Name", StringComparison.Ordinal))
                                                .Select(n => new AsnEncodedData(n.Oid, n.RawData))
                                                .Select(n => n.Format(true))
                                                .FirstOrDefault();
            if (subjectAlternativeName != null)
            {
                var alternativeNames = subjectAlternativeName.Split(new[] { "\r\n", "\r", "\n" }, StringSplitOptions.None);
                foreach (var alternativeName in alternativeNames)
                {
                    var groups = Regex.Match(alternativeName, @"^DNS Name=(.*)").Groups;
                    if (groups.Count > 0 && !String.IsNullOrEmpty(groups[1].Value))
                    {
                        result.Add(groups[1].Value);
                    }
                }
            }
            return result;
        }

        /// <summary>
        /// Tells whether logged in user is admin or not
        /// </summary>
        /// <returns>true if admin, false otherwise</returns>
        public static bool IsAdministrator()
        {
            if (OperatingSystem.IsWindows())
            {
                WindowsIdentity identity = WindowsIdentity.GetCurrent();
                WindowsPrincipal principal = new WindowsPrincipal(identity);
                return principal.IsInRole(WindowsBuiltInRole.Administrator);
            }
            // false stops it from running on other OS', true allows, until we see if we even need root access on Linux
            return false;
        }

        /// <summary>
        /// Configures the console logger
        /// </summary>
        /// <param name="logPath">the path to the directory where to store the log files</param>
        public static void ConfigureLogger(string logPath)
        {

            var config = new LoggingConfiguration();

#if DEBUG
            config.LoggingRules.Add(new LoggingRule("*", LogLevel.Debug, new ColoredConsoleTarget { Layout = "[DEBUG] ${message}${onexception:${newline}${exception:format=tostring}}" }));
#endif
            config.LoggingRules.Add(new LoggingRule("*", LogLevel.Info, new ColoredConsoleTarget { Layout = "${message}" }));

            config.LoggingRules.Add(
                new LoggingRule("*", LogLevel.Info, new FileTarget
                {
                    FileName = Path.Combine(logPath, "wincertes.log"),
                    ArchiveAboveSize = 500000,
                    ArchiveFileName = Path.Combine(logPath, "wincertes.old.log"),
                    MaxArchiveFiles = 1,
                    ArchiveOldFileOnStartup = false,
                    Layout = "${longdate}|${level:uppercase=true}|${message}${onexception:${newline}${exception:format=tostring}}"
                }));

            LogManager.Configuration = config;
        }

        /// <summary>
        /// Creates the windows scheduled task
        /// </summary>
        /// <param name="domains">The domains to renew</param>
        /// <param name="taskName">The friendky certificate name or null to ignore</param>
        public static void CreateScheduledTask(string taskName, List<string> domains, int extra)
        {
            if (taskName == null) return;
            try
            {
                using (TS.TaskService ts = new TS.TaskService())
                {
                    // Create a new task definition and assign properties
                    TS.TaskDefinition td = ts.NewTask();
                    td.RegistrationInfo.Description = "Manages certificate using ACME";

                    // We need to run as SYSTEM user
                    td.Principal.UserId = @"NT AUTHORITY\SYSTEM";

                    // Create a trigger that will fire the task at this time every other day
                    td.Triggers.Add(new TS.DailyTrigger { DaysInterval = 2 });
                    String extraOpt = "";

                    if (extra > -1)
                        extraOpt = "--extra=" + extra.ToString() + " ";
                    // Create an action that will launch Notepad whenever the trigger fires
                    td.Actions.Add(new TS.ExecAction("WinCertes.exe", extraOpt + "-d " + String.Join(" -d ", domains), Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location)));

                    // Register the task in the root folder
                    ts.RootFolder.RegisterTaskDefinition($"WinCertes - {taskName}", td);
                }
                logger.Info($"Scheduled Task \"WinCertes - {taskName}\" created successfully");
            }
            catch (Exception e)
            {
                logger.Error("Unable to create Scheduled Task" + e.Message);
            }
        }

        /// <summary>
        /// Checks whether there is a Scheduled task created
        /// </summary>
        /// <param name="taskName">The friendly name of the Certificate or check any</param>
        /// <returns>True if one exists, False if it doesn't</returns>
        public static bool IsScheduledTaskCreated(string taskName = null)
        {
            try
            {
                using (TS.TaskService ts = new TS.TaskService())
                {
                    foreach (TS.Task t in ts.RootFolder.Tasks)
                    {
                        if (string.IsNullOrEmpty(taskName))
                        {
                            if (t.Name.StartsWith("WinCertes"))
                                return true;
                        }
                        else
                        {
                            if (t.Name == $"WinCertes - {taskName}")
                                return true;
                        }
                    }
                }
                return false;
            }
            catch (Exception e)
            {
                logger.Error("Unable to read Scheduled Task status" + e.Message);
                return false;
            }
        }

        /// <summary>
        /// Deletes the specified Scheduled Task or all of them
        /// </summary>
        /// <param name="taskName">The friendly name of the Certificate or null for All of them</param>
        public static void DeleteScheduledTasks(string taskName = null)
        {
            try
            {
                using (TS.TaskService ts = new TS.TaskService())
                {
                    foreach (TS.Task t in ts.RootFolder.Tasks)
                    {
                        if (string.IsNullOrEmpty(taskName))
                        {
                            if (t.Name.StartsWith("WinCertes"))
                                ts.RootFolder.DeleteTask(t.Name, false);
                        }
                        else
                        {
                            if (t.Name == $"WinCertes - {taskName}")
                            {
                                ts.RootFolder.DeleteTask(t.Name, false);
                                return;
                            }
                        }
                    }
                }
            }
            catch (Exception e)
            {
                logger.Error("Unable to read Scheduled Task status" + e.Message);
            }
        }

        /// <summary>
        /// Small, utilitary function, to compute an MD5 Hash. Yes, MD5 isn't wonderful, but we don't use it for high class crypto.
        /// </summary>
        /// <param name="md5Hash"></param>
        /// <param name="input"></param>
        /// <returns></returns>
        private static string GetMD5Hash(MD5 md5Hash, string input)
        {
            // Convert the input string to a byte array and compute the hash.
            byte[] data = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(input));
            // Create a new Stringbuilder to collect the bytes and create a string.
            StringBuilder sBuilder = new StringBuilder();
            // Loop through each byte of the hashed data and format each one as a hexadecimal string.
            for (int i = 0; i < data.Length; i++)
            {
                sBuilder.Append(data[i].ToString("x2"));
            }
            // Return the hexadecimal string.
            return sBuilder.ToString();
        }

        /// <summary>
        /// Convenience function to compute a digital identifier from the list of domains
        /// </summary>
        /// <param name="domains">the list of domains</param>
        /// <returns>the identifier</returns>
        public static string DomainsToHostId(List<string> domains)
        {
            List<string> wDomains = new List<string>(domains);
            wDomains.Sort();
            string domainList = String.Join("-", wDomains);
            return "_" + GetMD5Hash(new MD5(), domainList).Substring(0, 16).ToLower();
        }

        /// <summary>
        /// Convenience method to compute a humain readable name for a list of domains
        /// </summary>
        /// <param name="domains">the list of domains</param>
        /// <returns>the human readable name</returns>
        public static string DomainsToFriendlyName(List<string> domains)
        {
            if (domains.Count == 0)
            {
                return "WinCertes";
            }
            List<string> wDomains = new List<string>(domains);
            wDomains.Sort();
            wDomains.Sort();
            string friendly = wDomains[0].Replace(@"*", "").Replace("-", "").Replace(":", "").Replace(".", "");
            friendly += "0000000000000000";
            return friendly.Substring(0, 16);
        }

        /// <summary>
        /// Retrieves a certificate from machine store, given its serial number
        /// </summary>
        /// <param name="serial">the serial number of the certificate to retrieve</param>
        /// <returns>the certificate, or null if not found</returns>
        public static X509Certificate2 GetCertificateBySerial(string serial)
        {
            return GetCertificate(serial, X509FindType.FindBySerialNumber);
        }

        /// <summary>
        /// Retrieves a certificate from machine store, given the IIS Bind Hash
        /// </summary>
        /// <param name="hash">the IIS Bind Hash of the certificate to retrieve</param>
        /// <returns>the certificate, or null if not found</returns>
        public static X509Certificate2 GetCertificateByHash(byte[] hash)
        {
            var thumb = Convert.ToHexString(hash);
            return GetCertificate(thumb, X509FindType.FindByThumbprint);
        }

        /// <summary>
        /// Retreives a certificate from the machine store, given either the Serial or Thumbprint
        /// </summary>
        /// <param name="serialThumb">The Certificate Serial or Thumbprint</param>
        /// <param name="findBy">Either BySerial or ByThumbprint (others will fail)</param>
        /// <returns>The certificate, or null if not found</returns>
        public static X509Certificate2 GetCertificate(string serialThumb, X509FindType findBy)
        {
            try
            {
                X509Store store = new X509Store(StoreName.My, StoreLocation.LocalMachine);
                store.Open(OpenFlags.ReadOnly);
                X509Certificate2Collection collection = store.Certificates.Find(findBy, serialThumb, false);
                store.Close();
                if (collection.Count == 0)
                {
                    return null;
                }
                else
                {
                    X509Certificate2 cert = collection[0];
                    return cert;
                }
            }
            catch (Exception e)
            {
                logger.Error($"Could not retrieve certificate from store: {e.Message}");
                return null;
            }
        }

        /// <summary>
        /// Generates a new key pair
        /// </summary>
        /// <param name="keySize">Size of the key</param>
        /// <returns>new Key Pair as PEM</returns>
        public static string GenerateRSAKeyAsPEM(int keySize)
        {
            try
            {
                IAsymmetricCipherKeyPairGenerator generator = GeneratorUtilities.GetKeyPairGenerator("RSA");
                RsaKeyGenerationParameters generatorParams = new RsaKeyGenerationParameters(
                                BigInteger.ValueOf(0x10001), new SecureRandom(), keySize, 12);
                generator.Init(generatorParams);
                AsymmetricCipherKeyPair keyPair = generator.GenerateKeyPair();
                using (StringWriter sw = new StringWriter())
                {
                    PemWriter pemWriter = new PemWriter(sw);
                    pemWriter.WriteObject(keyPair);
                    return sw.ToString();
                }
            }
            catch (Exception e)
            {
                logger.Error($"Could not generate new key pair: {e.Message}");
                return null;
            }
        }
    }
}
