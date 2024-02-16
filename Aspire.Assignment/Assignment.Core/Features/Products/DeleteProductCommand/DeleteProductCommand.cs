using MediatR;

namespace Assignment.Core.Features.Products.DeleteProductCommand
{
    public class DeleteProductCommand : IRequest<Unit>
    {
        public Guid ProductId { get; set; }
    }
}