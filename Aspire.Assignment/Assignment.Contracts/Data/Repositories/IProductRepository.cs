using Assignment.Contracts.Data.Entities;

namespace Assignment.Contracts.Data.Repositories
{
    public interface IProductRepository
    {
        public Task<Guid> AddProductAsync(Product product);
        public Task DeleteProductAsync(Guid productId);
        public Task<Product?> UpdateProductAsync(Product product);
        public Task<List<Product>> GetAllProductsAsync();
        public Task<List<CartProduct>> GetAllCartsListAsync();
        public Task<bool> IsProductExistsAsync(Guid productId);
    }
}