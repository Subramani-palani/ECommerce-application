using Assignment.Contracts.Data.Entities;
using Assignment.Contracts.Data.Entities.Identity;
using Assignment.Contracts.DTO;

namespace Assignment.Contracts.Data.Repositories
{
    public interface ICategoryRepository{ 
        public Task<Guid> AddCategoryAsync(Category category);
        public Task DeleteCategoryAsync(Guid categoryId);
        public Task<List<Category>> GetAllCategoriesAsync();
        public Task<List<Product>> GetAllProductsByCategoryIdAsync(Guid categoryId);
    }
}