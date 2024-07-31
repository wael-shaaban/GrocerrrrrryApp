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
        private readonly CartViewModel cartViewModel;
        [ObservableProperty]
        ObservableCollection<CategoryModel> categories;

        [ObservableProperty]
        ObservableCollection<OfferModel> offers;

        [ObservableProperty]
        ObservableCollection<ProductDto> popularProducts;

        [ObservableProperty]
        bool isBusy = true;

        [ObservableProperty]
        int cartItemsCount;
        public HomePageViewModel(CategoryService categoryService, OfferService offerService,ProductService productService,CartViewModel cartViewModel)
        {
            this.categoryService = categoryService;
            this.offerService = offerService;
            this.productService = productService;
            this.cartViewModel = cartViewModel;
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
        private void AddToCart(int productId) => UpdateCart(productId, 1);
        [RelayCommand]
        private void RemoveFromCart(int productId)=>UpdateCart(productId, -1);

        private void UpdateCart(int productId,int count)
        {
            var selectedProduct = PopularProducts.FirstOrDefault(x => x.Id == productId);
            if (selectedProduct is not null)
            {
                selectedProduct.ProductQuantity += count;
                if (count == 1)//add new product to cart         
                    cartViewModel.AddToCartCommand.Execute(selectedProduct);
                else if(count ==-1)// can be reomved but I add it for readability only
                       cartViewModel.RemoveFromCartCommand.Execute(selectedProduct.Id);
                CartItemsCount = cartViewModel.CartItemsCount;
            }
        }
    }
}