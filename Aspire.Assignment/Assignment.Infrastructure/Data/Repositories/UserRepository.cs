using Assignment.Contracts.Data.Entities.Identity;
using Assignment.Contracts.Data.Enums;
using Assignment.Contracts.Data.Repositories;
using Assignment.Contracts.DTO;
using Assignment.Migrations;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;


namespace Assignment.Core.Data.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly  DatabaseContext _databaseContext;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly RoleManager<ApplicationRole> _roleManager;
        private readonly IJwtService _jwtService;
        private readonly ICartRepository _cartRepository;

        public UserRepository(DatabaseContext databaseContext, UserManager<ApplicationUser> userManager,SignInManager<ApplicationUser> signInManager,
                                IJwtService jwtService, RoleManager<ApplicationRole> roleManager,ICartRepository cartRepository)
        {
            _databaseContext = databaseContext;
            _userManager = userManager;
            _signInManager = signInManager;
            _jwtService = jwtService;
            _roleManager = roleManager;
            _cartRepository = cartRepository;
        }

        public async Task<Guid> RegisterUserAsync(ApplicationUser applicationUser, string password)
        {
            IdentityResult result =  await _userManager.CreateAsync(applicationUser,password);

            if(!result.Succeeded){
                string errorMessage = "";
                foreach(IdentityError error in result.Errors){
                    errorMessage += error.Description + "\n";
                }

                return Guid.Empty;
            }


            // Adding Buyer Role to to the AspNetRoles table for first time

            if(await _roleManager.FindByNameAsync(UserRoleOptions.Buyer.ToString()) is null){
                ApplicationRole applicationRole = new ApplicationRole(){
                    Name = UserRoleOptions.Buyer.ToString()
                };
                await _roleManager.CreateAsync(applicationRole);
            }

            // Adding current user into the Buyer Role ie into AspNetUserRoles 
            await _userManager.AddToRoleAsync(applicationUser,UserRoleOptions.Buyer.ToString());
            
            //step3: 
            ApplicationUser newUser = await _userManager.FindByEmailAsync(applicationUser.Email);

            //ToDo : Create a cart for every user.
            _cartRepository.CreatCartForUser(newUser.Id);

            return newUser.Id;
        }

        public async Task<AuthenticationResponse?> AuthenticateUser(string email, string password)
        {
            var result = await _signInManager.PasswordSignInAsync(email,password,isPersistent:false,lockoutOnFailure:false);
            if(!result.Succeeded){
                //Handle this InValid case
                return null;
            }

            //Create a JWT Token

            ApplicationUser existingUser = await _userManager.FindByEmailAsync(email);

            AuthenticationResponse authenticationResponse = _jwtService.CreateJwtToken(existingUser);

            return authenticationResponse;
        }


        public async Task<bool> IsEmailAlreadyExistsAsync(string email)
        {
            ApplicationUser existingUser = await _userManager.FindByEmailAsync(email);
            return existingUser == null;
        }

        public async Task LogoutAsync()
        {
           await _signInManager.SignOutAsync();
        }

        public async Task<IEnumerable<ApplicationUser>> GetAllUsersAsync()
        {
            var users = await _userManager.Users.Include(address => address.Address).Include(cart => cart.Cart).ToListAsync();
            return users;
        }

        public async Task<bool> IsUserExistsAsync(Guid userId)
        {
            ApplicationUser? existingUser = await _userManager.Users.FirstOrDefaultAsync(user => user.Id == userId);

            return existingUser != null;
        }
    }
}
