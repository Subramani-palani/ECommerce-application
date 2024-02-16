
using Assignment.Contracts.Data.Entities;
using Assignment.Contracts.Data.Repositories;
using Assignment.Contracts.DTO;
using Assignment.Core.Exceptions;
using AutoMapper;
using FluentValidation;
using MediatR;

namespace Assignment.Core.Features.Categories.GetAllCategoryQuery
{
    public class GetAllCategoryQueryHandler : IRequestHandler<GetAllCategoryQuery, List<CategoriesDTO>>
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;

        public GetAllCategoryQueryHandler(ICategoryRepository categoryRepository, IMapper mapper)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }
        public async Task<List<CategoriesDTO>> Handle(GetAllCategoryQuery request, CancellationToken cancellationToken)
        {
            List<Category> categories = await _categoryRepository.GetAllCategoriesAsync();
            List<CategoriesDTO> allCategories = new();

            //Map Category Domain obj to CategoriesDTO
            foreach(var category in categories){
                allCategories.Add(_mapper.Map<CategoriesDTO>(category));
            }

            return allCategories;
            
        }
    }
}