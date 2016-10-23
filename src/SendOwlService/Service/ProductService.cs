using HackerFerretSoftware.SendOwl.Components;
using HackerFerretSoftware.SendOwl.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HackerFerretSoftware.SendOwl.Service
{
    public class ProductService : BaseService
    {
        public ProductService(string key, string secret, string baseUrl = "https://www.sendowl.com/") : base(key, secret, baseUrl)
        {


        }

        public async Task<List<ProductWrapper>> GetProductListAsync()
        {
            var url = BaseUrl + "api/v1/products";
            var retval = new List<ProductWrapper>();
            var result = String.Empty;
            using (var client = GetSecureSendOwlHttpClient())
            {
                var responseString = await client.GetStringAsync(url);
                retval = JsonConvert.DeserializeObject<List<ProductWrapper>>(responseString);
            }
            return retval;
        }

    }
}
