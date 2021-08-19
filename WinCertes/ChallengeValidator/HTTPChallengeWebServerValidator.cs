using NLog;
using System;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace WinCertes.ChallengeValidator
{
    class HTTPChallengeWebServerValidator : IHTTPChallengeValidator
    {
        private static readonly ILogger logger = LogManager.GetLogger("WinCertes.ChallengeValidator.HTTPChallengeWebServerValidator");
        private CancellationTokenSource _cts;
        private HttpListener _listener;
        private string _tokenContents;
        private int httpPort;

        private void Listen(CancellationToken token)
        {
            try {
                _listener = new HttpListener();
                _listener.Prefixes.Add("http://*:"+this.httpPort+"/");
                token.Register(() =>
                {
                    _listener.Stop();
                    logger.Debug("Thread has been disposed.");
                });
                _listener.Start();
                logger.Debug("Started HTTP Listener on port "+this.httpPort);
                while (!token.IsCancellationRequested) {
                    try {
                        HttpListenerContext context = _listener.GetContext();
                        Process(context);
                    } catch (Exception) {
                        // ignore error, as thread abort will generate one anyway
                    }
                }
            } catch (Exception e) {
                if (!e.Message.Equals("Thread was being aborted.")) logger.Error($"Could not start to listen on port {this.httpPort}: {e.Message}");
            }
        }

        private void Process(HttpListenerContext context)
        {
            logger.Debug($"Processing the serving of content: {_tokenContents}");
            byte[] buf = Encoding.UTF8.GetBytes(_tokenContents);
            // First the headers
            context.Response.ContentType = "application/octet-stream";
            context.Response.ContentLength64 = buf.Length;
            context.Response.AddHeader("Date", DateTime.Now.ToString("r"));
            context.Response.StatusCode = 200;

            // Then the contents...erm, always the same !
            context.Response.OutputStream.Write(buf, 0, buf.Length);

            // We flush and close
            context.Response.OutputStream.Flush();
            context.Response.OutputStream.Close();
        }

        /// <summary>
        /// Class constructor. Starts the simple web server on port 80.
        /// HTTPChallengeWebServerValidator.Stop() MUST be called after use.
        /// </summary>
        public HTTPChallengeWebServerValidator(int httpPort)
        {
            this.httpPort = httpPort;
            try {
                _cts = new CancellationTokenSource();
                Task.Run(() => { Listen(_cts.Token); });

            } catch (Exception e) {
                logger.Warn($"Could not start web server: {e.Message}.");
            }
        }

        /// <summary>
        /// <see cref="IHTTPChallengeValidator.PrepareChallengeForValidation(string, string)"/>
        /// </summary>
        /// <param name="token"></param>
        /// <param name="keyAuthz"></param>
        public bool PrepareChallengeForValidation(string token, string keyAuthz)
        {
            _tokenContents = keyAuthz;
            if (_listener != null) return true;
            return false;
        }

        /// <summary>
        /// <see cref="IHTTPChallengeValidator.CleanupChallengeAfterValidation(string)"/>
        /// </summary>
        /// <param name="token"></param>
        public void CleanupChallengeAfterValidation(string token)
        {
            _tokenContents = "";
        }

        /// <summary>
        /// Stops the simple web server
        /// </summary>
        public void EndAllChallengeValidations()
        {
            _cts.Cancel();
            _listener.Stop();
            logger.Debug("Just stopped the HTTP Listener");
        }
    }
}
