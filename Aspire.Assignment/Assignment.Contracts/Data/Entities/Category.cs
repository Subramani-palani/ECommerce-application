using System.ComponentModel.DataAnnotations;

namespace Assignment.Contracts.Data.Entities
{
    public class Category
    {
        [Key]
        public Guid Id { get; set; }
        public string? CategoryName { get; set; }
        public List<Product> Products { get; set; } = new();
    }
}