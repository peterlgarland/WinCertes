using NLog;
using System;
using System.Management.Automation.Runspaces;
using System.Threading.Tasks;
using WinCertes.Config;

namespace WinCertes.ChallengeValidator
{
    class DNSChallengePowerShellValidator : IDNSChallengeValidator
    {
        private static readonly ILogger logger = LogManager.GetLogger("WinCertes.ChallengeValidator.DNSChallengePowerShellValidator");

        private IConfig _config;

        public DNSChallengePowerShellValidator(IConfig config)
        {
            _config = config;
        }

        public async Task<bool> PrepareChallengeForValidationAsync(string dnsKeyName, string dnsKeyValue)
        {
            var scriptFile = _config.ReadStringParameter("DNSScriptFile");
            if (scriptFile == null)
                throw new Exception("No DNSScriptFile was configured while calling DNS PowerShell Validator plug-in");
            try
            {
                // First let's create the execution runspace
                Runspace runspace = RunspaceFactory.CreateRunspace();
                runspace.Open();

                // Now we create the pipeline
                Pipeline pipeline = runspace.CreatePipeline();

                // We create the script to execute with its arguments as a Command
                System.Management.Automation.Runspaces.Command myCommand = new System.Management.Automation.Runspaces.Command(scriptFile);
                CommandParameter dnsKeyNameParam = new CommandParameter("dnsKeyName", dnsKeyName);
                myCommand.Parameters.Add(dnsKeyNameParam);
                CommandParameter dnsKeyValueParam = new CommandParameter("dnsKeyValue", dnsKeyValue);
                myCommand.Parameters.Add(dnsKeyValueParam);

                // add the created Command to the pipeline
                pipeline.Commands.Add(myCommand);

                // and we invoke it
                var results = pipeline.Invoke();
                foreach (var item in results)
                {
                    logger.Debug("PS Output: " + item);
                }
                logger.Info($"Executed DNS Challenge Script {scriptFile}.");
                return true;
            }
            catch (Exception e)
            {
                logger.Error($"Could not execute {scriptFile}: {e.Message}");
                return false;
            }
        }
    }
}