using MediatR;

namespace Assignment.Core.Features.Products.CreateProductCommand
{
    public class CreateProductCommand : IRequest<Guid>
    {
        public string? ProductName { get; set; }
        public string? ProductDescription { get; set; }
        public int ProductPrice { get; set; }
        public int ProductQuantity { get; set; }
        public Guid CategoryId { get; set; }
    }
}