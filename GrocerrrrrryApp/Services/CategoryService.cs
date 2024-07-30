using GrocerrrrrryApp.Models;
using Microsoft.Extensions.Http;
using Newtonsoft.Json;
using System.Net.Http;
using System.Text.Json;

namespace GrocerrrrrryApp.Services
{
    public class CategoryService:BaseService
    {
        public CategoryService(IHttpClientFactory _httpClientFactory):base(_httpClientFactory)
        {
        }
        private IEnumerable<CategoryModel>? _categories;
        public async ValueTask<IEnumerable<CategoryModel>?> GetCategoriesAsync()
        {
            if (_categories is null)
            {
                var data = await HttpClient.GetAsync("/masters/categories");
                var responseData = await HandleResponse<IEnumerable<CategoryModel>>(data, null);
                if(responseData is null)
                   return Enumerable.Empty<CategoryModel>();
                _categories = responseData;
            }
            return _categories;
            #region staticData
            //    var categories = new List<CategoryModel>();
            //    var fruits = new List<CategoryModel>{
            //     new (1, "Fruits", 0, "fruits.jpg", ""),
            //     new (2, "Seasonal Fruits", 1, "seasonal_fruits.jpg", ""),
            //     new (3, "Exotic Fruits", 1, "exotic_fruits.jpg", "")
            //     };
            //    categories.AddRange(fruits);

            //    var vegetables = new List<CategoryModel>
            //                {
            //  new (4, "Vegetables", 0, "vegetables.jpg", ""),
            //  new (5, "Green Vegetables", 4, "green_vegetables.jpg", ""),
            //  new (6, "Leafy Vegetables", 4, "leafy_vegetables.jpg", ""),
            //  new (7, "Salads", 4, "salads.jpg", "")
            //  };
            //    categories?.AddRange(vegetables);
            //    var dairy = new List<CategoryModel>
            //    {

            //        new (8, "Dairy", 0, "dairy.jpg", ""),
            //        new (9, "Milk, Curd & Yogurts", 8, "milk_curd_yogurt.jpg",""),
            //        new (10, "Butter & Cheese", 8, "butter_cheese.jpg", "")
            //        };
            //    categories?.AddRange(dairy);

            //    var eggsMeat = new List<CategoryModel>
            //        {
            //            new (11, "Eggs & Meat", 0, "eggs_meat.jpg", ""),
            //            new (12, "Eggs", 11, "eggs.jpg", ""),
            //            new (13, "Meat", 11, "meat.jpg", ""),
            //            new (14, "Seafood", 11, "seafood.jpg", "")
            //        };
            //    categories?.AddRange(eggsMeat);
            //    _categories = categories;
            #endregion
        }
        public async ValueTask<IEnumerable<CategoryModel>?> GetMainCategories() =>
            (await GetCategoriesAsync())?.Where(x => x.ParentId == 0);
    }
}