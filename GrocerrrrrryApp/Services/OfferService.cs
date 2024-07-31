using GrocerrrrrryApp.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace GrocerrrrrryApp.Services
{
    public class OfferService : BaseService
    {
        public OfferService(IHttpClientFactory _httpClientFactory) : base(_httpClientFactory)
        {
        }
        public async Task<IEnumerable<OfferModel>?> GetOffersAsync()
        {
            var data = await HttpClient.GetAsync("/masters/offers");
            return await HandleResponse(data, Enumerable.Empty<OfferModel>());
        }
    }
}