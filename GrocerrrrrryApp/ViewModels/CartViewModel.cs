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
        public event EventHandler<int> CartCountUpdated;   
        public event EventHandler<CartItemModel> CartItemUpdated;   
        public event EventHandler<int> CartItemRemoved;   


        [ObservableProperty]
        ObservableCollection<CartItemModel> cartItems;

        [ObservableProperty]
        int cartItemsCount;
        [ObservableProperty]
        decimal totalAmount;
        private void RecalculateAmount() => TotalAmount = CartItems.Sum(c => c.Amount);
        public CartViewModel()
        {
            cartItems = new ObservableCollection<CartItemModel>();
            CartItemsCount = 0;
        }
        [RelayCommand]
        void IncreaseProductToCart(Guid cartId)
        {
            var cart  = this.CartItems.FirstOrDefault(x => x.Id == cartId);
            if (cart is not null)
            {
                cart.Quantity++;
                RecalculateAmount();
                CartItemUpdated?.Invoke(this,cart);
            }
        }
        [RelayCommand]
        void AddToCart(ProductDto product)
        {
            var productCart = CartItems.FirstOrDefault(c => c.ProductId == product.Id);
            if (productCart is not null)
            {
                productCart.Quantity++;
            }
            else
            {
                productCart = new CartItemModel
                {
                    Id = Guid.NewGuid(),
                    ProductId = product.Id,
                    PoductName = product.Name,
                    Price = product.Price,
                    Quantity = 1
                };
                CartItems.Add(productCart);
                CartItemsCount = CartItems.Count;
                CartCountUpdated?.Invoke(this, CartItemsCount);
            }   
            RecalculateAmount();
            CartItemUpdated?.Invoke(this, productCart);
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
                    CartItemRemoved?.Invoke(this, productId);  
                    CartCountUpdated?.Invoke(this, CartItemsCount);
                }
                else
                {
                    productCart.Quantity--;
                    CartItemUpdated?.Invoke(this, productCart);
                }
            }
            RecalculateAmount();    
        }
        [RelayCommand]
        void ClearCart()
        {
            CartItems.Clear();  
            CartItemsCount = 0; 
            RecalculateAmount();    
        }
    }
}