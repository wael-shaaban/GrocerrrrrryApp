using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrocerrrrrryApp.Models
{
    public partial class CartItemModel : ObservableObject
    {
        public Guid Id { get; set; }
        public int ProductId { get; set; }
        public string PoductName { get; set; }
        public decimal Price { get; set; }
        [ObservableProperty, NotifyPropertyChangedFor(nameof(Amount))]
        int quantity;
        public decimal Amount => Price * Quantity;
    }
}