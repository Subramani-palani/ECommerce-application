using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Assignment.Contracts.Data.Entities
{
    /// <summary>
    /// Juntion class to map Cart and Product classes and maintains many to many relationship
    /// </summary>
    public class CartProduct
    {
        [Key]
        public Guid ID { get; set; }
        public Guid CartId { get; set; }

        [ForeignKey("CartId")]
        public Cart? Cart { get; set; }
        public Guid ProductId { get; set; }

        [ForeignKey("ProductId")]
        public Product? Product { get; set; }

    }
}