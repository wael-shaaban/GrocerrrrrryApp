using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using DLL.DTOs;
using GrocerrrrrryApp.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrocerrrrrryApp.ViewModels
{
    public partial class CartViewModel : ObservableObject
    {
        [ObservableProperty]
        ObservableCollection<CartItemModel> cartItems;

        [ObservableProperty]
        int cartItemsCount;
        public CartViewModel()
        {
            cartItems = new ObservableCollection<CartItemModel>();
            CartItemsCount = 0;
        }
        [RelayCommand]
        void AddToCart(ProductDto product)
        {
            var productCart = CartItems.FirstOrDefault(c => c.ProductId == product.Id);
            if (productCart is not null)
                productCart.Quantity++;
            else
            {
                CartItems.Add(new CartItemModel
                {
                    Id = Guid.NewGuid(),
                    ProductId = product.Id,
                    PoductName = product.Name,
                    Price = product.Price,
                    Quantity = 1
                });
                CartItemsCount = CartItems.Count;
            }
        }
        [RelayCommand]  
        void RemoveFromCart(int productId)
        {
            var productCart = CartItems.FirstOrDefault(c => c.ProductId == productId);
            if(productCart is not null)
            {
                if (productCart.Quantity == 1)
                {
                    CartItems.Remove(productCart);
                    CartItemsCount = CartItems.Count;
                }
                else
                    productCart.Quantity--;
            }
        }
        [RelayCommand]
        void ClearCart()
        {
            CartItems.Clear();  
            CartItemsCount = 0; 
        }
    }
}