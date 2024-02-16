using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Assignment.Contracts.Data.Entities
{
    public class Category
    {
        [Key]
        // [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        public string? CategoryName { get; set; }
        public List<Product> Products { get; set; } = new();
    }
}