﻿using System.Collections.Generic;

namespace WinCertes.Config
{
    /// <summary>
    /// Interface to Configuration Engine
    /// </summary>
    public interface IConfig
    {
        /// <summary>
        /// Deletes parameter from configuration
        /// </summary>
        /// <param name="parameter"></param>
        void DeleteParameter(string parameter);

        /// <summary>
        /// Reads Integer parameter from the configuration
        /// </summary>
        /// <param name="parameter"></param>
        /// <param name="defaultValue"></param>
        /// <returns></returns>
        int ReadIntParameter(string parameter, int defaultValue = 0);

        /// <summary>
        /// Tries to read parameter value from configuration. If it does not exist, uses provided value instead, and writes it to configuration
        /// </summary>
        /// <param name="parameter">the configuration parameter to manage</param>
        /// <param name="value">the default value is parameter does not exist in configuration</param>
        /// <returns>the value of the configuration parameter</returns>
        int ReadOrWriteIntParameter(string parameter, int value);

        /// <summary>
        /// For the given parameter, writes its value into configuration, if value != defaultValue. In any case, reads it from configuration.
        /// </summary>
        /// <param name="parameter">the configuration parameter to manage</param>
        /// <param name="value">the value of the configuration parameter</param>
        /// <param name="defaultValue">the default value of the configuration parameter</param>
        /// <returns>the value of the configuration parameter, defaultValue if none</returns>
        int WriteAndReadIntParameter(string parameter, int value, int defaultValue);

        /// <summary>
        /// Tries to read parameter value from configuration. If it does not exist, uses provided value instead, and writes it to configuration
        /// </summary>
        /// <param name="parameter">the configuration parameter to manage</param>
        /// <param name="value">the default value is parameter does not exist in configuration</param>
        /// <returns>the value of the configuration parameter</returns>
        string ReadOrWriteStringParameter(string parameter, string value);

        /// <summary>
        /// Reads parameter from configuration as string, null if none
        /// </summary>
        /// <param name="parameter">the parameter to manage</param>
        /// <returns>the parameter value, null if none</returns>
        string ReadStringParameter(string parameter);

        // <summary>
        /// Aims at handling flags with configuration parameter. Deletes the flag
        /// </summary>
        /// <param name="parameter">the flag</param>
        /// <param name="value">the flag's value</param>
        /// <returns>the flag's value</returns>
        public bool WriteBooleanParameter(string parameter, bool value);

        /// <summary>
        /// Aims at handling flags with configuration parameter. Once a flag has been set to true, it's written forever in the configuration
        /// </summary>
        /// <param name="parameter">the flag</param>
        /// <param name="value">the flag's value</param>
        /// <returns>the flag's value</returns>
        bool WriteAndReadBooleanParameter(string parameter, bool value);

        /// <summary>
        /// For the given parameter, writes its value into configuration, if value != null. In any case, reads it from configuration.
        /// </summary>
        /// <param name="parameter">the configuration parameter to manage</param>
        /// <param name="value">the value of the configuration parameter</param>
        /// <returns>the value of the configuration parameter, null if none</returns>
        string WriteAndReadStringParameter(string parameter, string value);

        /// <summary>
        /// Writes integer parameter into configuration
        /// </summary>
        /// <param name="parameter"></param>
        /// <param name="value"></param>
        void WriteIntParameter(string parameter, int value);

        /// <summary>
        /// Writes parameter value into configuration
        /// </summary>
        /// <param name="parameter">the parameter to manage</param>
        /// <param name="value">the parameter value</param>
        void WriteStringParameter(string parameter, string value);

        /// <summary>
        /// Is there a configuration parameter starting with given key?
        /// </summary>
        /// <param name="startsWith">the parameter to look for</param>
        bool IsThereConfigParam(string startsWith);

        /// <summary>
        /// Deletes all WinCertes parameters from configuration, or a speicifc extra configuration
        /// </summary>
        void DeleteAllParameters(int extra = -1);

        /// <summary>
        /// Gets the number of Extras in the configuration
        /// </summary>
        /// <returns>int list of the Extra numbers</returns>
        IList<int> GetExtrasConfigParams();

        /// <summary>
        /// Gets the DomainsToHostId for Certificates in the Registry
        /// </summary>
        /// <returns>string list of the DomainsToHostIds</returns>
        IList<string> GetCertificateParams(string startsWith);
    }
}