using Assignment.Contracts.Data.Entities;
using Assignment.Contracts.Data.Repositories;
using Assignment.Contracts.DTO;
using AutoMapper;
using MediatR;

namespace Assignment.Core.Features.Categories.GetProductsByIdQuery
{
    public class GetProductsByIdQueryHandler : IRequestHandler<GetProductsByIdQuery, List<GetProductsDTO>>
    {
        private readonly IMapper _mapper;
        private readonly ICategoryRepository _categoryRepository;

        public GetProductsByIdQueryHandler(IMapper mapper,ICategoryRepository categoryRepository)
        {
            _mapper = mapper;
            _categoryRepository = categoryRepository;
        }
        public async Task<List<GetProductsDTO>> Handle(GetProductsByIdQuery request, CancellationToken cancellationToken)
        {
            List<Product> allProducts = await _categoryRepository.GetAllProductsByCategoryIdAsync(request.CategotyId);

            List<GetProductsDTO> allProductsByCategory = new();

            //AutoMapping Product Domain obj to GetProductsDTO
            foreach(var product in allProducts){
                allProductsByCategory.Add(_mapper.Map<GetProductsDTO>(product));
            }

            return allProductsByCategory;

        }
    }
}