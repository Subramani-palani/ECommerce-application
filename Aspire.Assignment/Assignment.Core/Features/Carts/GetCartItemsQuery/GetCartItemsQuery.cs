using Assignment.Contracts.Data.Entities;
using MediatR;

namespace Assignment.Core.Features.Carts.GetCartItemsQuery
{
    public class GetCartItemsQuery : IRequest<List<Product>>{
        public Guid UserId { get; set; }
    }
}