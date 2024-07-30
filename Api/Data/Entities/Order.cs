using groceryShared.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GerogercyApp.Api.Data.Entities
{
    [Table(nameof(Order))]  
    public class Order
    {
        public Order()
        {
            OrderItems = new HashSet<OrderItem>();
        }
        [Key]
        public long Id { get; set; }
        public DateTime Date { get; set; } = DateTime.Now;
        public decimal TotalAmount { get; set; }
        public OrderStatus Status { get; set; } = OrderStatus.Placed;
        public string Color { get; set; }
        public virtual ICollection<OrderItem> OrderItems { get; set; }
        public int UserId {  get; set; }    
        public virtual User User { get; set; }
    }
}