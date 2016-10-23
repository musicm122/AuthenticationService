using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HackerFerretSoftware.SendOwl
{
    public class SendOwlCore
    {
        public LicenseService LicenseApi { get; private set; }

        public SendOwlCore(string key, string secret, string baseUrl = "https://www.sendowl.com/")
        {
            this.LicenseApi = new LicenseService(key, secret, baseUrl);
        }
    }
}

