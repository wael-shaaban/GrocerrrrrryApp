using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrocerrrrrryApp.Services
{
    public class BaseService
    {
        private readonly IHttpClientFactory httpClientFactory;

        public BaseService(IHttpClientFactory httpClientFactory)
        {
            this.httpClientFactory = httpClientFactory;
        }
        protected HttpClient HttpClient =>httpClientFactory.CreateClient(Helpers.Constants.HttpsClientName);
        protected TData DeserializeData<TData>(string data) => JsonConvert.DeserializeObject<TData>(data);
        public async Task<TData> HandleResponse<TData>(HttpResponseMessage message,TData defaultValue)
        {
            if (message?.IsSuccessStatusCode == true)
            {
                var response = await message.Content.ReadAsStringAsync();
                if (!string.IsNullOrEmpty(response))
                    return DeserializeData<TData>(response);
            }
            return defaultValue;
        }
    }
}
