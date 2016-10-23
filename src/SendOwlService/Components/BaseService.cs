using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace HackerFerretSoftware.SendOwl.Components
{
    public abstract class BaseService
    {
        protected string Key { get; set; }
        protected string Secret { get; set; }
        protected string BaseUrl { get; set; }

        public BaseService(string key, string secret, string baseUrl = "https://www.sendowl.com/")
        {
            this.Key = key;
            this.Secret = secret;
            this.BaseUrl = baseUrl;

        }

        protected HttpClient GetSecureSendOwlHttpClient()
        {
            var result = String.Empty;

            var key = Key;
            var secret = Secret;
            var baseUrl = BaseUrl;

            var client = new HttpClient();
            client.BaseAddress = new Uri(baseUrl);
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", Convert.ToBase64String((Encoding.UTF8.GetBytes($"{key}:{secret}"))));
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            return client;
        }
    }

}
