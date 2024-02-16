using Microsoft.AspNetCore.Identity;

namespace Assignment.Contracts.Data.Entities.Identity;

public class ApplicationUser : IdentityUser<Guid>
{
    public string? PersonName { get; set; }
    public Address? Address { get; set; }
    public Cart? Cart { get; set; }
}