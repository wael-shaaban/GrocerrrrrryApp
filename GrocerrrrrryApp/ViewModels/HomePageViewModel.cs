using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using DLL.DTOs;
using GrocerrrrrryApp.Models;
using GrocerrrrrryApp.Services;
using System.Collections.ObjectModel;

namespace GrocerrrrrryApp.ViewModels
{
    public partial class HomePageViewModel : ObservableObject
    {
        private readonly CategoryService categoryService;
        private readonly OfferService offerService;
        private readonly ProductService productService;
        [ObservableProperty]
        ObservableCollection<CategoryModel> categories;

        [ObservableProperty]
        ObservableCollection<OfferModel> offers;

        [ObservableProperty]
        ObservableCollection<ProductDto> popularProducts;

        [ObservableProperty]
        bool isBusy = true;
        public HomePageViewModel(CategoryService categoryService, OfferService offerService,ProductService productService)
        {
            this.categoryService = categoryService;
            this.offerService = offerService;
            this.productService = productService;
            Categories = new ObservableCollection<CategoryModel>();
            Offers = new ObservableCollection<OfferModel>();
            PopularProducts = new ObservableCollection<ProductDto>(); 
        }
        [RelayCommand]
        public async Task InitializeAsync()
        {
            IsBusy = true;
            try
            {
                var offerTask = offerService.GetOffersAsync();
                var productTask = productService.GetPopularProductAsync();
                foreach (var category in await categoryService.GetCategoriesAsync())
                    Categories.Add(category);
                foreach (var offer in await offerTask)
                    Offers.Add(offer);
                foreach (var product in await productTask)
                    PopularProducts.Add(product);
            }
            finally
            {
                IsBusy = false;
            }
        }
        [RelayCommand]
        private void AddProduct(int productId) => UpdateProdcut(productId, 1);
        [RelayCommand]
        private void RemoveProduct(int productId)=>UpdateProdcut(productId, -1);

        private void UpdateProdcut(int productId,int count)
        {
            var selectedProduct = PopularProducts.FirstOrDefault(x => x.Id == productId);
            if (selectedProduct is not null)
                selectedProduct.ProductQuantity += count;
        }
    }
}