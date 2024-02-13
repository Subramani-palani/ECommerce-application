using Assignment.Contracts.Data.Entities;
using Assignment.Contracts.Data.Entities.Identity;

namespace Assignment.Contracts.Data.Repositories
{
    public interface IUserRepository{ 
        public Task<Guid> AddUserAsync(ApplicationUser applicationUser,string password);
        public Task<bool> IsEmailAlreadyExistsAsync(string email);
        public Task<Guid> AuthenticateUser(string email,string password);
    }
}