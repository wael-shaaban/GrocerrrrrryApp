using groceryApp.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace groceryApp.Services
{
    public class OfferService
    {
        public OfferService(IHttpClientFactory _httpClientFactory)
        {
            httpClientFactory = _httpClientFactory;
        }
        private readonly IHttpClientFactory httpClientFactory;
        public async Task<IEnumerable<OfferModel>?> GetOffersAsync()
        {
            var httpClient = httpClientFactory.CreateClient(Helpers.Constants.HttpsClientName);
            var data = await httpClient.GetAsync("/masters/offers");
            if (data?.IsSuccessStatusCode == true)
            {
                var response = await data.Content.ReadAsStringAsync();
                if (!string.IsNullOrEmpty(response))
                {
                    var puredata =  JsonConvert.DeserializeObject<IEnumerable<OfferModel>>(response);
                    return puredata;
                }
            }
            return Enumerable.Empty<OfferModel>();
        }
    }
}