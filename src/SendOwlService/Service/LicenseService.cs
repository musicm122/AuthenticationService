using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using HackerFerretSoftware.SendOwl.Model;
using System.Text;
using HackerFerretSoftware.SendOwl.Components;
using System.Diagnostics;

namespace HackerFerretSoftware.SendOwl
{
    public class LicenseService : BaseService
    {
        public LicenseService(string key, string secret, string baseUrl = "https://www.sendowl.com/") : base(key, secret, baseUrl)
        {

        }

        public async Task<List<LicenseWrapper>> GetMatchingLicenseAsync(string productId, string license)
        {
            var result = new List<LicenseWrapper>();
            var url = BaseUrl + $"api/v1/products/{productId}/licenses/check_valid?key={license}";
            using (var client = GetSecureSendOwlHttpClient())
            {
                var request = new HttpRequestMessage(HttpMethod.Get, url);
                try
                {
                    var resultString = await client.GetStringAsync(url);
                    result = JsonConvert.DeserializeObject<List<LicenseWrapper>>(resultString);
                }
                catch (Exception ex)
                {
                    Debug.Write(ex.Message, "HackerFerretSoftware.SendOwl.LicenseService");
                    throw;
                }

            }
            return result;
        }

        public async Task<List<LicenseWrapper>> GetLicenseListAsync(string productId)
        {
            var result = new List<LicenseWrapper>();
            var url = BaseUrl + $"api/v1/products/{productId}/licenses";
            using (var client = GetSecureSendOwlHttpClient())
            {
                var request = new HttpRequestMessage(HttpMethod.Get, url);
                try
                {
                    var resultString = await client.GetStringAsync(url);
                    result = JsonConvert.DeserializeObject<List<LicenseWrapper>>(resultString);
                }
                catch (Exception ex)
                {
                    Debug.Write(ex.Message, "HackerFerretSoftware.SendOwl.LicenseService");
                    throw;
                }

            }
            return result;
        }

    }
}
