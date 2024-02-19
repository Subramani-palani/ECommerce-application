using Assignment.Contracts.Data.Entities;
using Assignment.Contracts.Data.Repositories;
using Assignment.Core.Exceptions;
using Assignment.Migrations;
using Microsoft.EntityFrameworkCore;

namespace Assignment.Infrastructure.Data.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly DatabaseContext _databaseContext;
        public ProductRepository(DatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
        }
        public async Task<Guid> AddProductAsync(Product product)
        {
            await _databaseContext.Products.AddAsync(product);
            await _databaseContext.SaveChangesAsync();

            //Get the new ProductId
            Product? newProduct = _databaseContext.Products.Find(product.Id);
            
            return newProduct == null ? Guid.Empty : newProduct.Id;
        }

        public async Task DeleteProductAsync(Guid productId)
        {
            Product? productToBeDeleted = _databaseContext.Products.Find(productId);

            if(productToBeDeleted == null){
                //Product Not Found
                throw new InvalidRequestBodyException();
            }

            _databaseContext.Products.Remove(productToBeDeleted);
            await _databaseContext.SaveChangesAsync();
        }

        public Task<List<CartProduct>> GetAllCartsListAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<List<Product>> GetAllProductsAsync()
        {
            return await _databaseContext.Products.ToListAsync();
        }

        public async Task<bool> IsProductExistsAsync(Guid productId)
        {
            Product? existingProduct = await _databaseContext.Products.FindAsync(productId);
            return existingProduct != null;
        }

        public async Task<Product?> UpdateProductAsync(Product product)
        {
            //fetch product by Id
            Product? productTobeUpdated = _databaseContext.Products.Find(product.Id);

            //checking if the product exists
            if(productTobeUpdated == null){
                return null;
            }

            //Update the product details
            productTobeUpdated.ProductName = product.ProductName;
            productTobeUpdated.ProductPrice = product.ProductPrice;
            productTobeUpdated.ProductQuantity = product.ProductQuantity;
            productTobeUpdated.CategoryId = product.CategoryId;
            productTobeUpdated.ProductDescription = product.ProductDescription;

            _databaseContext.Products.Update(productTobeUpdated);
            await _databaseContext.SaveChangesAsync();

            return product;

        }
    }
}