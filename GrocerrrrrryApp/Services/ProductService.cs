using DLL.DTOs;
using GrocerrrrrryApp.Models;

namespace GrocerrrrrryApp.Services
{
    public class ProductService : BaseService
    {
        public ProductService(IHttpClientFactory httpClientFactory) : base(httpClientFactory)
        {
        }
        public async Task<IEnumerable<ProductDto>?> GetPopularProductAsync()
        {
          //  var data = await HttpClient.GetAsync($"/masters/popular-products?{count}");//to get count dynamically for pagintion
            var data = await HttpClient.GetAsync("/popular-products");
            return await HandleResponse(data, Enumerable.Empty<ProductDto>());
        }
    }
}