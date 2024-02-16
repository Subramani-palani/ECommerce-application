
using Assignment.Contracts.Data.Entities;
using Assignment.Contracts.Data.Repositories;
using Assignment.Core.Exceptions;
using Assignment.Migrations;
using MediatR;
using Microsoft.AspNetCore.Server.IIS.Core;
using Microsoft.EntityFrameworkCore;


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

            Category? newCategory =  await _databaseContext.Categories.FirstOrDefaultAsync(c => c.CategoryName == category.CategoryName);

            if(newCategory == null){
                return Guid.Empty;
            }

            return newCategory.Id;
        }

        public async Task DeleteCategoryAsync(Guid categoryId)
        {
            Category? categoryToBeDeleted = await _databaseContext.Categories.FirstOrDefaultAsync(category => category.Id == categoryId) ?? throw new InvalidRequestBodyException();
            // if(categoryToBeDeleted == null){
            //     //Category Not Found
            //     throw new InvalidRequestBodyException();
            // }

            _databaseContext.Categories.Remove(categoryToBeDeleted);
            await _databaseContext.SaveChangesAsync();
        }

        public async Task<List<Category>> GetAllCategoriesAsync()
        {
            return await _databaseContext.Categories.ToListAsync();
        }

        public async Task<List<Product>> GetAllProductsByCategoryIdAsync(Guid categoryId)
        {
            List<Category> categories = await _databaseContext.Categories.Include(category => category.Products).ToListAsync();
            
            List<Product> allProducts =  categories.FirstOrDefault(category => category.Id == categoryId).Products;

            return allProducts;

        }
    }
}
