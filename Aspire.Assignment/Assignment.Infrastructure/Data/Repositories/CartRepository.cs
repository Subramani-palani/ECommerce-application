using System.Net.Sockets;
using System.Reflection.Metadata.Ecma335;
using Assignment.Contracts.Data.Entities;
using Assignment.Contracts.Data.Entities.Identity;
using Assignment.Contracts.Data.Repositories;
using Assignment.Migrations;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Assignment.Infrastructure.Data.Repositories
{
    public class CartRepository : ICartRepository
    {
        private readonly DatabaseContext _databaseContext;
        private readonly UserManager<ApplicationUser> _userManager;

        public CartRepository(DatabaseContext databaseContext, UserManager<ApplicationUser> userManager)
        {
            _databaseContext = databaseContext;
            _userManager = userManager;
        }

        public async void CreatCartForUser(Guid userId)
        {
            Cart cart = new()
            {
                UserId = userId
            };

            await _databaseContext.Carts.AddAsync(cart);
            await _databaseContext.SaveChangesAsync();
            
        }

        public async Task<string> AddProductToCartAsync(Guid userId, Guid productId)
        {
            //Steps: 
            //1. Fetech the user cart
            //2. Add Product to list of CartProducts

            ApplicationUser? user = await _userManager.Users.Include(cart => cart.Cart).FirstOrDefaultAsync(user => user.Id == userId);

            if (user == null || user.Cart == null)
            {
                return "User or Cart not found";
            }   

            Cart? userCart = _databaseContext.Carts.Find(user.Cart.Id); 

            if(userCart == null){
                return "Cart not found";
            }

            CartProduct cartProduct = new(){
                CartId = userCart.Id,
                ProductId = productId
            };

            // Add the CartProduct to the cart
            userCart.CartProducts.Add(cartProduct);

            // Attach the userCart to the context
            _databaseContext.Update(userCart);

            // Console.WriteLine("******************" +_databaseContext.Entry(userCart).State + " *****************");

            // Save changes to the database
            await _databaseContext.SaveChangesAsync();

            return "Product added successfully";
            
        }

        public async Task<string> DeleteProductFromCartAsync(Guid userId, Guid productId)
        {
            //Steps: 
            //1. Fetech the user cart
            //2. Remove Product from list of CartProducts


            // ApplicationUser? user = await _userManager.Users.Include(cart => cart.Cart).FirstOrDefaultAsync(user => user.Id == userId);
            // Retrieve the user and their cart
            var user = await _userManager.Users
                .Include(u => u.Cart)
                .FirstOrDefaultAsync(u => u.Id == userId);

            // if(user == null){
            //     return "User Not Found";
            // }

            // if(user.Cart == null){
            //     return "Cart not found!!";
            // }

            if (user == null || user.Cart == null)
            {
                return "User or Cart not found";
            }  

            // Cart? userCart = _databaseContext.Carts.Include(cart => cart.CartProducts).FirstOrDefault(cart => cart.Id == user.Cart.Id); 
            
            // Retrieve the cart with its cart products
            var userCart = await _databaseContext.Carts
                .Include(cart => cart.CartProducts)
                .FirstOrDefaultAsync(cart => cart.Id == user.Cart.Id);

            if(userCart == null){
                return "Cart not found";
            }

            if (_databaseContext.Entry(userCart).State == EntityState.Detached)
            {
                _databaseContext.Attach(userCart);
            }

            // if(userCart.CartProducts.Count == 0){
            //     Console.WriteLine("********* U R Stupid ********");
            // }
            // else{
            //     Console.WriteLine("******** U IMproved **********");
            // }

            // //Note: The "Collection was modified; enumeration operation may not execute" exception typically occurs when you try to modify a collection while iterating over it. This often happens when you're iterating over a collection using a foreach loop or a LINQ query and then trying to modify the same collection within the loop.

            // var cartProductsCopy = userCart.CartProducts.ToList();

            // foreach(var cartProduct in cartProductsCopy)
            // {
            //     Console.WriteLine("************** "+cartProduct.ProductId+ " *******************");

            //     if(cartProduct.ProductId == productId)
            //     {
            //         Console.WriteLine("*************** Product fetched *********************");
            //         userCart.CartProducts.Remove(cartProduct);  //Removing the product from List
            //         _databaseContext.Update(userCart);    //Updating the context of Cart to "Modified"
            //     }
            // }

            // foreach(var cartProduct in userCart.CartProducts){
            //     Console.WriteLine("************** "+cartProduct.ProductId+ " *******************");
            // }

            // Console.WriteLine("******************" +_databaseContext.Entry(userCart).State + " *****************");

            // await _databaseContext.SaveChangesAsync();  //Save the changes to update the database

            // return "product removed from cart successfully";

            // Remove the specified product from the cart
            var cartProductToRemove = userCart.CartProducts.FirstOrDefault(cp => cp.ProductId == productId);

            if (cartProductToRemove != null)
            {
                userCart.CartProducts.Remove(cartProductToRemove);
            }

            foreach(var cartProduct in userCart.CartProducts){
                Console.WriteLine(cartProduct.ProductId);
            }

            // Mark the userCart entity as Modified
            _databaseContext.Entry(userCart).State = EntityState.Modified;

            Console.WriteLine("******************" +_databaseContext.Entry(userCart).State + " *****************");

            // Save the changes to the database
            await _databaseContext.SaveChangesAsync();

            return "Product removed from cart successfully";


        }

        public async Task<List<Product>> GetAllCartItemsAsync(Guid userId)
        {
            List<Product> products = new();

            // Retrieve the user and their cart
            var user = await _userManager.Users
                .Include(user => user.Cart)
                .FirstOrDefaultAsync(user => user.Id == userId);

            if(user == null || user.Cart == null){
                return products;
            }

            //Retreive the cart with Its cart products
            var userCart = await _databaseContext.Carts
                .Include(cart => cart.CartProducts)
                .ThenInclude(cartProduct => cartProduct.Product)
                .ThenInclude(product => product.Category)
                .FirstOrDefaultAsync(cart => cart.Id == user.Cart.Id);

            if(userCart == null){
                return products;
            }


            foreach(var cartProduct in userCart.CartProducts){
                if(cartProduct.Product != null){
                    products.Add(cartProduct.Product);
                }
            }

            return products;

        }
    }
}