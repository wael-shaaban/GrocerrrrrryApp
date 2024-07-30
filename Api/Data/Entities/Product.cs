using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Api.Data.Entities
{
    [Table(nameof(Product))]
    public class Product//Dependent
    {
        [Key]
        public int Id { get; set; }
        [Required,MaxLength(20)]
        public string Name { get; set; }
        [MaxLength(180)]
        public string? Image { get; set; }
        [Required]
        public decimal Price { get; set; }
        [Required, MaxLength(25)]
        public string Unit { get; set; }
        public short CategoryId { get; set; }
        public virtual Category Category { get; set; }
    }
}