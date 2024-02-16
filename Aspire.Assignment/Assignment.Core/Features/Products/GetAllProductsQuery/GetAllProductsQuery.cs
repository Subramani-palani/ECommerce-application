using Assignment.Contracts.DTO;
using MediatR;

namespace Assignment.Core.Features.Products.GetAllProductsQuery
{
    public class GetAllProductsQuery : IRequest<List<GetProductsDTO>>
    {
        
    }
}