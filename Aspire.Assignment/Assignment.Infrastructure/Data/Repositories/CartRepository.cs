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

            Console.WriteLine(user.UserName);

            if(user == null){
                return "User Not Found";
            }

            if(user.Cart == null){
                return "Cart not found!!";
            }

            Cart? userCart = _databaseContext.Carts.Find(user.Cart.Id); 

            Console.WriteLine("********* "+userCart.Id+" ***********");

            CartProduct cartProduct = new(){
                CartId = userCart.Id,
                ProductId = productId
            };

            // Add the CartProduct to the cart
            userCart.CartProducts.Add(cartProduct);

            // Attach the userCart to the context
            _databaseContext.Update(userCart);

            Console.WriteLine("******************" +_databaseContext.Entry(userCart).State + " *****************");

            // Save changes to the database
            await _databaseContext.SaveChangesAsync();

            return "Product added successfully";
            
        }
    }
}