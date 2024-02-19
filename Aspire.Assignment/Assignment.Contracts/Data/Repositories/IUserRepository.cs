using Assignment.Contracts.Data.Entities;
using Assignment.Contracts.Data.Entities.Identity;
using Assignment.Contracts.DTO;

namespace Assignment.Contracts.Data.Repositories
{
    public interface IUserRepository{ 
        public Task<Guid> RegisterUserAsync(ApplicationUser applicationUser,string password);
        public Task<bool> IsEmailAlreadyExistsAsync(string email);
        public Task<AuthenticationResponse?> AuthenticateUser(string email,string password);
        public Task LogoutAsync();
        public Task<IEnumerable<ApplicationUser>> GetAllUsersAsync();
        public Task<bool> IsUserExistsAsync(Guid userId);
    }
}