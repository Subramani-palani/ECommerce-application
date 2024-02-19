using Assignment.Contracts.Data.Entities;
using Assignment.Contracts.Data.Repositories;
using MediatR;

namespace Assignment.Core.Features.Carts.GetCartItemsQuery
{
    public class GetCartItemsQueryHandler : IRequestHandler<GetCartItemsQuery, List<Product>>
    {   
        private readonly ICartRepository _cartRepository;
        public GetCartItemsQueryHandler(ICartRepository cartRepository)
        {
            _cartRepository = cartRepository;
        }
        public async Task<List<Product>> Handle(GetCartItemsQuery request, CancellationToken cancellationToken)
        {
            List<Product> cartItems = await _cartRepository.GetAllCartItemsAsync(request.UserId);
            return cartItems;
        }
    }
}