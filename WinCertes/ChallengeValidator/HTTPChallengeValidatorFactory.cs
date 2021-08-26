using NLog;
using System.Net;
using System.Net.NetworkInformation;

namespace WinCertes.ChallengeValidator
{
    /// <summary>
    /// Gets the appropriate HTTP Chalenge method, made public so GUI can access
    /// </summary>
    public class HTTPChallengeValidatorFactory
    {
        private static readonly ILogger logger = LogManager.GetLogger("WinCertes.ChallengeValidator.HTTPChallengeValidatorFactory");

        /// <summary>
        /// Builds the HTTP Challenge Validator. It will also initialise them.
        /// </summary>
        /// <param name="standalone">true if we use the built-in webserver, false otherwise</param>
        /// <param name="webRoot">the full path to the web server root, when not using built-in</param>
        /// <returns>the HTTP challenge Validator</returns>
        public static IHTTPChallengeValidator GetHTTPChallengeValidator(bool standalone, int httpPort, string webRoot = null)
        {
            IHTTPChallengeValidator challengeValidator = null;
            if (standalone) {
                if (!CheckAvailableServerPort(httpPort)) return null;
                challengeValidator = new HTTPChallengeWebServerValidator(httpPort);
            } else if (webRoot != null) {
                challengeValidator = new HTTPChallengeFileValidator(webRoot);
            }
            return challengeValidator;
        }

        /// <summary>
        /// Checks the Port is not in use
        /// </summary>
        /// <param name="port">Port to check</param>
        /// <returns>Result of whether its Available, i.e. False = In Use</returns>
        public static bool CheckAvailableServerPort(int port)
        {
            bool isAvailable = true;
            IPGlobalProperties ipGlobalProperties = IPGlobalProperties.GetIPGlobalProperties();
            IPEndPoint[] tcpConnInfoArray = ipGlobalProperties.GetActiveTcpListeners();
            foreach (IPEndPoint endpoint in tcpConnInfoArray) {
                if (endpoint.Port == port) {
                    isAvailable = false;
                    break;
                }
            }
            if (!isAvailable) logger.Error($"Impossible to bind on port {port}. A program is probably already listening on it.");
            return isAvailable;
        }
    }
}
