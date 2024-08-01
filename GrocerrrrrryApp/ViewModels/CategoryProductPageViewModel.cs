using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using DLL.DTOs;
using GrocerrrrrryApp.Models;
using GrocerrrrrryApp.Services;
using System.Collections.ObjectModel;

namespace GrocerrrrrryApp.ViewModels
{
    [QueryProperty(nameof(SelectedCategory), nameof(SelectedCategory))]
    public partial class CategoryProductPageViewModel : ObservableObject, IDisposable
    {
        private readonly CategoryService categoryService;
        private readonly ProductService productService;
        private readonly CartViewModel cartViewModel;

        [ObservableProperty, NotifyPropertyChangedFor(nameof(PageTitle))]
        CategoryModel selectedCategory;

        public string PageTitle => $"{SelectedCategory?.Name ?? "Category"} Products";

        [ObservableProperty]
        ObservableCollection<CategoryModel> categories;//sub-cateogries

        [ObservableProperty]
        ObservableCollection<ProductDto> products;//products in this sub-cateogries


        [ObservableProperty]
        bool isBusy = true;

        [ObservableProperty]
        int cartItemsCount;

        public CategoryProductPageViewModel(CategoryService categoryService, ProductService productService, CartViewModel cartViewModel)
        {
            this.categoryService = categoryService;
            this.productService = productService;
            this.cartViewModel = cartViewModel;
            Categories = new ObservableCollection<CategoryModel>();
            Products = new ObservableCollection<ProductDto>();
            cartViewModel.CartItemUpdated += CartUpdated;
            cartViewModel.CartItemRemoved += CartRemoved;
            cartViewModel.CartCountUpdated += CartCountUpdated;
        }

        [RelayCommand]
        public async Task Initialize()
        {
            IsBusy = true;
            try
            {
                Categories.Clear();
                foreach (var category in await categoryService.GetMainOrSiblingCategoriesAsync(SelectedCategory.Id))
                    Categories.Add(category);

                Products.Clear();
                foreach (var product in await productService.GetCategoryProductsAsync(SelectedCategory.Id))
                    Products.Add(product);
            }
            finally
            {
                IsBusy = false;
            }
        }


        private void CartCountUpdated(object? sender, int cartItemsCount) => CartItemsCount = cartItemsCount;
        private void CartRemoved(object? sender, int prodcutId) => CartUpdateRemove(prodcutId, 0);
        private void CartUpdated(object? sender, CartItemModel cartItem) => CartUpdateRemove(cartItem.ProductId, cartItem.Quantity);
        private void CartUpdateRemove(int productId, int quantity)
        {
            var product = Products.FirstOrDefault(x => x.Id == productId);
            if (product is not null)
                product.ProductQuantity = quantity;
        }
        [RelayCommand]
        private void AddToCart(int productId) => UpdateCart(productId, 1);
        [RelayCommand]
        private void RemoveFromCart(int productId) => UpdateCart(productId, -1);

        private void UpdateCart(int productId, int count)
        {
            var selectedProduct = Products.FirstOrDefault(x => x.Id == productId);
            if (selectedProduct is not null)
            {
                selectedProduct.ProductQuantity += count;
                if (count == 1)//add new product to cart         
                    cartViewModel.AddToCartCommand.Execute(selectedProduct);
                else if (count == -1)// can be reomved but I add it for readability only
                    cartViewModel.RemoveFromCartCommand.Execute(selectedProduct.Id);
                CartItemsCount = cartViewModel.CartItemsCount;
            }
        }
        public void Dispose()
        {
            cartViewModel.CartItemUpdated -= CartUpdated;
            cartViewModel.CartItemRemoved -= CartRemoved;
            cartViewModel.CartCountUpdated -= CartCountUpdated;
        }
    }
}