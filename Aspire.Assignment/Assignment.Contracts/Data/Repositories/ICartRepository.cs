using Assignment.Contracts.Data.Entities;

namespace Assignment.Contracts.Data.Repositories
{
    public interface ICartRepository
    {
        //create a cart for user
        //Add to cart
        //Delete from cart
        //Get all cartProducts
        
        //ToDo: Update Quantity in cart
        //      Delete cart on payment
        //      Update the price on successfull update of cart


        public void CreatCartForUser(Guid userId);
        public Task<string> AddProductToCartAsync(Guid userId,Guid productId);
        public Task<string> DeleteProductFromCartAsync(Guid userId,Guid productId);
        public Task<List<Product>> GetAllCartItemsAsync(Guid userId);
    
    }
}