using AutoMapper;
using Assignment.Contracts.Data.Entities;
using Assignment.Contracts.DTO;
using Assignment.Contracts.Data.Entities.Identity;
using Assignment.Core.Features.Categories.CreateCategoryCommand;

namespace Assignment.Core.Mapper
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<RegisterUserDTO,ApplicationUser>();
            CreateMap<ApplicationUser,UserResponseDTO>();
            CreateMap<Category,CreateCategoryCommand>().ReverseMap();
            CreateMap<Category,CategoriesDTO>();
        }
    }
}
