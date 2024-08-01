using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using DLL.DTOs;
using GrocerrrrrryApp.Models;
using GrocerrrrrryApp.Pages;
using GrocerrrrrryApp.Services;
using System.Collections.ObjectModel;

namespace GrocerrrrrryApp.ViewModels
{
    public partial class HomePageViewModel : ObservableObject,IDisposable
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
            cartViewModel.CartItemUpdated += CartUpdated;
            cartViewModel.CartItemRemoved += CartRemoved;
            cartViewModel.CartCountUpdated += CartCountUpdated;
        }

        private void CartCountUpdated(object? sender, int cartItemsCount) => CartItemsCount = cartItemsCount;
        private void CartRemoved(object? sender, int prodcutId) => CartUpdateRemove(prodcutId, 0);
        private void CartUpdated(object? sender, CartItemModel cartItem) => CartUpdateRemove(cartItem.ProductId, cartItem.Quantity);
        private void CartUpdateRemove(int productId,int quantity)
        {
            var product = PopularProducts.FirstOrDefault(x => x.Id ==productId);
            if (product is not null)
                product.ProductQuantity = quantity;
        }
        private bool isInitialize = false;
        [RelayCommand]
        public async Task InitializeAsync()
        {
            if (isInitialize) return;
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
                isInitialize = true;
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
        [RelayCommand]
        async Task GotoCategoryPage(CategoryModel _selectedcategory)
        {
            if(_selectedcategory is not null)
            {
                var parameter = new ShellNavigationQueryParameters
                {
                    [nameof(CategoryProductPageViewModel.SelectedCategory)] = _selectedcategory
                }; 
                await Shell.Current.GoToAsync(nameof(CategoryProductPage), parameter);
            }
        }


        public void Dispose()
        {
            cartViewModel.CartItemUpdated -= CartUpdated;
            cartViewModel.CartItemRemoved -= CartRemoved;
            cartViewModel.CartCountUpdated-= CartCountUpdated;
        }
    }
}