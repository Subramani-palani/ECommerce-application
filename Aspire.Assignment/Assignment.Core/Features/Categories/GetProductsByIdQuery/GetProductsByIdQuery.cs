using Assignment.Contracts.DTO;
using MediatR;

namespace Assignment.Core.Features.Categories.GetProductsByIdQuery
{
    public class GetProductsByIdQuery : IRequest<List<GetProductsDTO>>
    {
        public Guid CategotyId { get; set; }
    }
}