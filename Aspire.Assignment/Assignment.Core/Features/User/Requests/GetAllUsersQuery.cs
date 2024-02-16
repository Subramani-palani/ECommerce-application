using Assignment.Contracts.Data.Entities.Identity;
using Assignment.Contracts.DTO;
using MediatR;

namespace Assignment.Core.Features.User.Requests;

public record GetAllUsersQuery() : IRequest<IEnumerable<ApplicationUser>>;