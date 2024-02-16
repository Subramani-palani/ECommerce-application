using Assignment.Contracts.Data.Entities;
using Assignment.Contracts.DTO;
using MediatR;

namespace Assignment.Core.Features.Categories.GetAllCategoryQuery
{
    public class GetAllCategoryQuery : IRequest<List<CategoriesDTO>>
    {

    }
}