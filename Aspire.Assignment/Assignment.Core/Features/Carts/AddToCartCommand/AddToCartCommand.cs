using MediatR;

namespace Assignment.Core.Features.Carts.AddToCartCommand
{
    public class AddToCartCommand : IRequest<string>
    {
        public Guid UserId { get; set; }    
        public Guid ProductId { get; set; }
    }
}