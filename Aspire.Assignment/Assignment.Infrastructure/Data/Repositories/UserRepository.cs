using Assignment.Contracts.Data.Entities;
using Assignment.Contracts.Data.Entities.Identity;
using Assignment.Contracts.Data.Repositories;
using Assignment.Migrations;
using Microsoft.AspNetCore.Identity;


namespace Assignment.Core.Data.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly  DatabaseContext _databaseContext;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        public UserRepository(DatabaseContext databaseContext, UserManager<ApplicationUser> userManager,SignInManager<ApplicationUser> signInManager)
        {
            _databaseContext = databaseContext;
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public async Task<Guid> AddUserAsync(ApplicationUser applicationUser, string password)
        {
            IdentityResult result =  await _userManager.CreateAsync(applicationUser,password);

            if(!result.Succeeded){
                string errorMessage = "";
                foreach(IdentityError error in result.Errors){
                    errorMessage += error.Description + "\n";
                }

                return Guid.Empty;
            }
            
            //step3: 
            ApplicationUser newUser = await _userManager.FindByEmailAsync(applicationUser.Email);
            return newUser.Id;
        }

        public async Task<Guid> AuthenticateUser(string email, string password)
        {
            var result = await _signInManager.PasswordSignInAsync(email,password,isPersistent:false,lockoutOnFailure:false);
            if(!result.Succeeded){
                //Handle this InValid case
                return Guid.Empty;
            }

            ApplicationUser newUser = await _userManager.FindByEmailAsync(email);
            return newUser.Id;

        }


        public async Task<bool> IsEmailAlreadyExistsAsync(string email)
        {
            ApplicationUser existingUser = await _userManager.FindByEmailAsync(email);
            if(existingUser == null){
                Console.WriteLine("***************** User Didnt Exist ****************");
            }
            return existingUser == null;
        }

    }
}
