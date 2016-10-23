using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using AuthenticationService.Model;
using System.Net.Http;
using Microsoft.Extensions.Options;
using HackerFerretSoftware.SendOwl;
using HackerFerretSoftware.SendOwl.Model;

namespace AuthenticationService.Controllers
{
    [Route("api/[controller]")]
    public class ValidationController : Controller
    {
        public ApplicationSettings Settings { get; set; }
        public SendOwlCore SendOwlService { get; set; }

        public ValidationController(IOptions<ApplicationSettings> settings)
        {
            Settings = settings.Value;
            SendOwlService = new SendOwlCore(Settings.Key, Settings.Secret, Settings.BaseUrl);
        }

        [HttpGet]
        public async Task<HttpResponseMessage> Get(string productId, string license)
        {
            if (string.IsNullOrWhiteSpace(productId) || string.IsNullOrWhiteSpace(license))
            {
                return new HttpResponseMessage()
                {
                    StatusCode = System.Net.HttpStatusCode.BadRequest,
                    Content = new StringContent("Bad request arguments")
                };
            }
            try
            {

                var licenseResult = await SendOwlService.LicenseApi.GetMatchingLicenseAsync(productId, license);

                if (licenseResult.Count > 0)
                {
                    var licenseDetails = licenseResult.FirstOrDefault().license;
                    if (licenseDetails.order_refunded)
                    {
                        return new HttpResponseMessage()
                        {
                            StatusCode = System.Net.HttpStatusCode.PaymentRequired,
                            Content = new StringContent("Order has been refunded")
                        };
                    }
                    else
                    {
                        return new HttpResponseMessage()
                        {
                            StatusCode = System.Net.HttpStatusCode.OK,
                            Content = new StringContent("License is Valid")
                        };
                    }
                }
                else
                {
                    return new HttpResponseMessage()
                    {
                        StatusCode = System.Net.HttpStatusCode.Forbidden,
                        Content = new StringContent("Bad request arguments")
                    };
                }
            }
            catch (Exception ex)
            {

                return new HttpResponseMessage()
                {
                    StatusCode = System.Net.HttpStatusCode.BadRequest,
                    Content = new StringContent($"Auth Server Faliure:{ex.Message}")
                };
                throw;
            };

        }

    }
}

