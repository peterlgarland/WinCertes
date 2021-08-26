using Microsoft.Win32;
using NLog;
using System;
using System.Collections.Generic;
using System.Security.AccessControl;
using System.Security.Principal;

namespace WinCertes
{
    /// <summary>
    /// Configuration class, managing WinCertes configuration into Windows Registry
    /// </summary>
    public class RegistryConfig : IConfig
    {
        private static readonly ILogger _logger = LogManager.GetLogger("WinCertes.WinCertesOptions");

        private string _registryKey = @"HKEY_LOCAL_MACHINE\SOFTWARE\WinCertes";
        private string _subKey = @"Software\WinCertes";

        /// <summary>
        /// Class constructor. if extra = false, builds the base config. if extra = true, builds the extra certificate config.
        /// </summary>
        public RegistryConfig(int extra = -1)
        {
            if (OperatingSystem.IsWindows())
            {
                try
                {
                    // First we check if WinCertes key is there
                    RegistryKey winCertesKey = Registry.LocalMachine.OpenSubKey("SOFTWARE", true).OpenSubKey("WinCertes", RegistryKeyPermissionCheck.ReadWriteSubTree, RegistryRights.FullControl);
                    if (winCertesKey == null)
                    {
                        // and if not, we create it
                        Registry.LocalMachine.OpenSubKey("SOFTWARE", true).CreateSubKey("WinCertes", RegistryKeyPermissionCheck.ReadWriteSubTree);
                        winCertesKey = Registry.LocalMachine.OpenSubKey("SOFTWARE", true).OpenSubKey("WinCertes", RegistryKeyPermissionCheck.ReadWriteSubTree, RegistryRights.FullControl);
                    }
                    // Let's fix the permissions
                    RegistrySecurity winCertesKeySec = winCertesKey.GetAccessControl(AccessControlSections.All);
                    // First we remove the inheritence
                    winCertesKeySec.SetAccessRuleProtection(true, false);
                    RegistrySecurity security = Registry.LocalMachine.OpenSubKey("SOFTWARE", false).GetAccessControl(AccessControlSections.Access);
                    // Copy rules from parent ("HKLM\Software"), except user access
                    foreach (RegistryAccessRule rule in security.GetAccessRules(true, true, typeof(NTAccount)))
                    {
                        try
                        {
                            // Copy all relevant rules except user
                            if (rule.IdentityReference.Value.IndexOf("Users", StringComparison.InvariantCultureIgnoreCase) < 0)
                            {
                                winCertesKeySec.AddAccessRule(rule);
                            }
                        }
                        catch { }
                    }
                    winCertesKey.SetAccessControl(winCertesKeySec);
                    if (extra > -1)
                    {
                        string extraIndex = "";
                        if (extra > 1)
                            extraIndex = extra.ToString();
                        if (Registry.LocalMachine.OpenSubKey("SOFTWARE").OpenSubKey("WinCertes").OpenSubKey("extra" + extraIndex) == null)
                        {
                            _logger.Debug("Creating SubKey 'extra" + extraIndex + "'");
                            Registry.LocalMachine.OpenSubKey("SOFTWARE").OpenSubKey("WinCertes", true).CreateSubKey("extra" + extraIndex, RegistryKeyPermissionCheck.ReadWriteSubTree);
                        }
                        _registryKey += @"\extra" + extraIndex;
                        _subKey += @"\extra" + extraIndex;
                    }
                }
                catch (Exception e)
                {
                    _logger.Warn(e, $"Warning: Could not open/create registry subkey: {e.Message}. We'll try to continue anyway.");
                }
            }
            else
            {
                _logger.Warn($"Warning: Not running on Windows so currently can't store the Configuration in the Registry, We'll try to continue anyway.");
            }
        }

        /// <summary>
        /// Reads parameter from configuration as string, null if none
        /// </summary>
        /// <param name="parameter">the parameter to manage</param>
        /// <returns>the parameter value, null if none</returns>
        public string ReadStringParameter(string parameter)
        {
            if (OperatingSystem.IsWindows()) return (string)Registry.GetValue(_registryKey, parameter, null);
            return null;
        }

        /// <summary>
        /// Writes parameter value into configuration
        /// </summary>
        /// <param name="parameter">the parameter to manage</param>
        /// <param name="value">the parameter value</param>
        public void WriteStringParameter(string parameter, string value)
        {
            if ((parameter == null) || (value == null)) { return; }
            if (OperatingSystem.IsWindows()) Registry.SetValue(_registryKey, parameter, value, RegistryValueKind.String);
        }

        /// <summary>
        /// For the given parameter, writes its value into configuration, if value != null. In any case, reads it from configuration.
        /// </summary>
        /// <param name="parameter">the configuration parameter to manage</param>
        /// <param name="value">the value of the configuration parameter</param>
        /// <returns>the value of the configuration parameter, null if none</returns>
        public string WriteAndReadStringParameter(string parameter, string value)
        {
            if (value != null)
            {
                WriteStringParameter(parameter, value);
            }
            return ReadStringParameter(parameter);
        }

        /// <summary>
        /// For the given parameter, writes its value into configuration, if value != defaultValue. In any case, reads it from configuration.
        /// </summary>
        /// <param name="parameter">the configuration parameter to manage</param>
        /// <param name="value">the value of the configuration parameter</param>
        /// <param name="defaultValue">the default value of the configuration parameter</param>
        /// <returns>the value of the configuration parameter, defaultValue if none</returns>
        public int WriteAndReadIntParameter(string parameter, int value, int defaultValue)
        {
            if (value != defaultValue)
                WriteIntParameter(parameter, value);
            return ReadIntParameter(parameter, defaultValue);
        }

        /// <summary>
        /// Tries to read parameter value from configuration. If it does not exist, uses provided value instead, and writes it to configuration
        /// </summary>
        /// <param name="parameter">the configuration parameter to manage</param>
        /// <param name="value">the default value is parameter does not exist in configuration</param>
        /// <returns>the value of the configuration parameter</returns>
        public string ReadOrWriteStringParameter(string parameter, string value)
        {
            string myValue = ReadStringParameter(parameter);
            if (myValue == null)
            {
                WriteStringParameter(parameter, value);
            }
            return ReadStringParameter(parameter);
        }

        /// <summary>
        /// Reads Integer parameter from the configuration
        /// </summary>
        /// <param name="parameter"></param>
        /// <param name="defaultValue"></param>
        /// <returns></returns>
        public int ReadIntParameter(string parameter, int defaultValue = 0)
        {
            if (OperatingSystem.IsWindows()) return (int)Registry.GetValue(_registryKey, parameter, defaultValue);
            return defaultValue;
        }

        /// <summary>
        /// Tries to read parameter value from configuration. If it does not exist, uses provided value instead, and writes it to configuration
        /// </summary>
        /// <param name="parameter">the configuration parameter to manage</param>
        /// <param name="value">the default value is parameter does not exist in configuration</param>
        /// <returns>the value of the configuration parameter</returns>
        public int ReadOrWriteIntParameter(string parameter, int value)
        {
            int myValue = ReadIntParameter(parameter, 0);
            if (myValue == 0)
            {
                WriteIntParameter(parameter, value);
            }
            return ReadIntParameter(parameter);
        }

        /// <summary>
        /// Writes integer parameter into configuration
        /// </summary>
        /// <param name="parameter"></param>
        /// <param name="value"></param>
        public void WriteIntParameter(string parameter, int value)
        {
            if (parameter == null) { return; }
            if (OperatingSystem.IsWindows()) Registry.SetValue(_registryKey, parameter, value, RegistryValueKind.DWord);
        }

        /// <summary>
        /// Aims at handling flags with configuration parameter. Deletes the flag
        /// </summary>
        /// <param name="parameter">the flag</param>
        /// <param name="value">the flag's value</param>
        /// <returns>the flag's value</returns>
        public bool WriteBooleanParameter(string parameter, bool value)
        {
            if (value)
            {
                WriteIntParameter(parameter, 1);
            }
            else
            {
                 DeleteParameter(parameter);
            }
            return (ReadIntParameter(parameter, 0) == 1);
        }

        /// <summary>
        /// Aims at handling flags with configuration parameter. Once a flag has been set to true, it's written forever in the configuration
        /// </summary>
        /// <param name="parameter">the flag</param>
        /// <param name="value">the flag's value</param>
        /// <returns>the flag's value</returns>
        public bool WriteAndReadBooleanParameter(string parameter, bool value)
        {
            if (value)
            {
                WriteIntParameter(parameter, 1);
            }
            return (ReadIntParameter(parameter, 0) == 1);
        }

        /// <summary>
        /// Deletes parameter from configuration
        /// </summary>
        /// <param name="parameter"></param>
        public void DeleteParameter(string parameter)
        {
            if (OperatingSystem.IsWindows())
            {
                if (isThereConfigParam(parameter))
                {
                    RegistryKey key = Registry.LocalMachine.OpenSubKey(_subKey, true);
                    if (key != null)
                    {
                        key.DeleteValue(parameter);
                    }
                }
            }
        }

        /// <summary>
        /// Is there a configuration parameter starting with given key?
        /// </summary>
        /// <param name="startsWith">the parameter to look for</param>
        public bool isThereConfigParam(string startsWith)
        {
            if (OperatingSystem.IsWindows())
            {
                foreach (string key in Registry.LocalMachine.OpenSubKey(_subKey).GetValueNames())
                {
                    if (key.StartsWith(startsWith))
                        return true;
                }
            }
            return false;
        }

        /// <summary>
        /// Deletes all WinCertes parameters from configuration, or a speicifc extra configuration
        /// </summary>
        public void DeleteAllParameters(int extra = -1)
        {
            if (OperatingSystem.IsWindows())
            {
                // If delete all Config or Extra Config 1
                if (extra == -1 || extra == 1)
                {
                    if (Registry.LocalMachine.OpenSubKey("SOFTWARE").OpenSubKey("WinCertes").OpenSubKey("extra") != null)
                    {
                        Registry.LocalMachine.OpenSubKey("SOFTWARE\\WinCertes", true).DeleteSubKeyTree("extra");
                    }
                }

                // If delete all Config, run through all keys
                if (extra == -1)
                {
                    foreach (string subKey in Registry.LocalMachine.OpenSubKey(_subKey).GetSubKeyNames())
                    {
                        if (Registry.LocalMachine.OpenSubKey("SOFTWARE").OpenSubKey("WinCertes").OpenSubKey(subKey) != null)
                            Registry.LocalMachine.OpenSubKey("SOFTWARE\\WinCertes", true).DeleteSubKeyTree(subKey);
                    }
                    foreach (string key in Registry.LocalMachine.OpenSubKey(_subKey).GetValueNames())
                    {
                        DeleteParameter(key);
                    }
                }
                else
                {
                    // just delete the extra key
                    var key = $"extra{extra}";
                    if (Registry.LocalMachine.OpenSubKey("SOFTWARE").OpenSubKey("WinCertes").OpenSubKey(key) != null)
                    {
                        Registry.LocalMachine.OpenSubKey("SOFTWARE\\WinCertes", true).DeleteSubKeyTree(key);
                    }
                }
            }
        }


        /// <summary>
        /// Gets the number of Extras in the configuration
        /// </summary>
        /// <returns>string list of the Extra numbers</returns>
        public IList<int> getExtrasConfigParams()
        {
            var list = new List<int>();

            if (OperatingSystem.IsWindows())
            {
                foreach (string subKey in Registry.LocalMachine.OpenSubKey("SOFTWARE").OpenSubKey("WinCertes").GetSubKeyNames())
                {
                    if (subKey.StartsWith("extra"))
                    {
                        if (subKey.Length == 5)
                            list.Add(1);
                        else
                        {
                            if (int.TryParse(subKey.Substring(5), out var extra))
                                list.Add(extra);
                        }
                    }

                }
            }
            list.Sort();
            return list;
        }

        /// <summary>
        /// Gets the DomainsToHostId for Certificates in the Registry
        /// </summary>
        /// <returns>string list of the DomainsToHostIds</returns>
        public IList<string> getCertificateParams(string startsWith)
        {
            var list = new List<string>();

            if (OperatingSystem.IsWindows())
            {
                foreach (string key in Registry.LocalMachine.OpenSubKey(_subKey).GetValueNames())
                {
                    if (key.StartsWith(startsWith))
                        list.Add(key.Substring(startsWith.Length));
                }
            }
            return list;
        }

    }
}
