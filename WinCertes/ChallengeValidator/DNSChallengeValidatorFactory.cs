﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinCertes.ChallengeValidator
{
    /// <summary>
    /// Gets the appropriate DNS Chalenge method, made public so GUI can access
    /// </summary>
    public class DNSChallengeValidatorFactory
    {
        /// <summary>
        /// Builds the DNS Challenge validator. For now only ACME DNS is supported.
        /// </summary>
        /// <param name="config"></param>
        /// <returns></returns>
        public static IDNSChallengeValidator GetDNSChallengeValidator(IConfig config)
        {
            IDNSChallengeValidator challengeValidator = null;
            if (config.ReadStringParameter("DNSValidatorType") == null) return null;
            if (config.ReadStringParameter("DNSValidatorType") == "acme-dns") {
                challengeValidator = new DNSChallengeAcmeDnsValidator(config);
            }
            if (config.ReadStringParameter("DNSValidatorType") == "win-dns")
            {
                challengeValidator = new DNSChallengeWinDnsValidator(config);
            }
            if (config.ReadStringParameter("DNSValidatorType") == "aws")
            {
                challengeValidator = new DNSChallengeAWSValidator(config);
            }
            return challengeValidator;
        }
    }
}
