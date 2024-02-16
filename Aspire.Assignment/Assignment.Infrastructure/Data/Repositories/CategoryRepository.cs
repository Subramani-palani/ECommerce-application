
using Assignment.Contracts.Data.Entities;
using Assignment.Contracts.Data.Repositories;
using Assignment.Migrations;


namespace Assignment.Core.Data.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly DatabaseContext _databaseContext;

        public CategoryRepository(DatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
        }
        public async Task<Guid> AddCategoryAsync(Category category)
        {
            await _databaseContext.Categories.AddAsync(category);
            await _databaseContext.SaveChangesAsync();

            Category newCategory =  _databaseContext.Categories.FirstOrDefault(c => c.CategoryName == category.CategoryName);

            if(newCategory is null){
                return Guid.Empty;
            }

            return newCategory.Id;
        }

        public Task DeleteCategoryAsync(Guid categoryId)
        {
            throw new NotImplementedException();
        }

        public Task<List<Category>> GetAllCategoriesAsync()
        {
            throw new NotImplementedException();
        }
    }
}
