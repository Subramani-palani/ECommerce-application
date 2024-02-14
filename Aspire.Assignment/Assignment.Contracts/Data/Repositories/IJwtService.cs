using Assignment.Contracts.Data.Entities.Identity;
using Assignment.Contracts.DTO;

namespace Assignment.Contracts.Data.Repositories;

public interface IJwtService
{
    public AuthenticationResponse CreateJwtToken(ApplicationUser applicationUser);
}