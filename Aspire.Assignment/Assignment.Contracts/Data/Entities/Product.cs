using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Assignment.Contracts.Data.Entities
{
    public class Product
    {
        [Key]
        public Guid Id { get; set; }
        public string? ProductName { get; set; }
        public string? ProductDescription { get; set; }
        public int ProductPrice { get; set; }
        public int ProductQuantity { get; set; }
        public List<CartProduct> CartProducts { get; set; } = new();

        public Guid CategoryId { get; set; }
        
        [ForeignKey("CategoryId")]
        public Category? Category { get; set; }
    }
}