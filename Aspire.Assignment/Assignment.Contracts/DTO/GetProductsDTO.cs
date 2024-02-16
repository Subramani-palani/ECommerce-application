namespace Assignment.Contracts.DTO
{
    public class GetProductsDTO
    {
        public Guid Id { get; set; }
        public string? ProductName { get; set; }
        public string? ProductDescription { get; set; }
        public int ProductPrice { get; set; }
        public int ProductQuantity { get; set; }
        public Guid CategoryId { get; set; }
        
    }
}