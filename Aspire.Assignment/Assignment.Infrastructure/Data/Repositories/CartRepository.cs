using System.Net.Sockets;
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

            if(user == null){
                return "User Not Found";
            }

            // Guid cartId = (user.Cart == null) ? Guid.Empty : user.Cart.Id;

            // if(cartId == Guid.Empty){
            //     //This never gonna happen because for every user cart will be created at the time of account creation.
            //     return "Cart Not Found";
            // }

            // Cart? userUart = _databaseContext.Carts.Find(cartId);

            if(user.Cart == null){
                return "Cart not found!!";
            }

            Cart? userCart = _databaseContext.Carts.Find(user.Cart.Id);

            
        }
    }
}