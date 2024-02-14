using MediatR;

namespace Assignment.Core.Features.User.Requests;

public record SignOutUserQuery : IRequest<Unit>;