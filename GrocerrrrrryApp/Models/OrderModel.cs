using DLL.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrocerrrrrryApp.Models
{
    public class OrderModel
    {
        public long Id { get; set; }
        public IEnumerable<CartItemModel> CartItems { get; set; } = Enumerable.Empty<CartItemModel>();
        public DateTime Date { get; set; } = DateTime.Now;
        public decimal TotalAmount => CartItems.Sum(x => x.Amount);
        public OrderStatus Status { get; set; } = OrderStatus.Placed;
        public Color Color => OrdrerColors.TryGetValue(Status, out Color color) ? color : Colors.Yellow;
        private IReadOnlyDictionary<OrderStatus, Color> OrdrerColors =>
       new Dictionary<OrderStatus, Color>()
       {
           [OrderStatus.Placed] = Colors.Yellow,
           [OrderStatus.Confirmed] = Colors.Blue,
           [OrderStatus.Delivered] = Colors.Green,
           [OrderStatus.Cancelled] = Colors.Red

       };
    }
}