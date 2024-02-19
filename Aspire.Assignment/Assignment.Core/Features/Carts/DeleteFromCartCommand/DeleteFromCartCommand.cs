using MediatR;

namespace Assignment.Core.Features.Carts.DeleteFromCartCommand
{
    public class DeleteFromCartCommand : IRequest<string>
    {
        public Guid UserId { get; set; }    
        public Guid ProductId { get; set; }
    }
}