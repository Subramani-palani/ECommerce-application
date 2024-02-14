using Assignment.Contracts.Data.Repositories;
using Assignment.Core.Features.User.Requests;
using MediatR;

namespace Assignment.Core.Features.User.Handlers;

public class SignOutUserQueryHandler : IRequestHandler<SignOutUserQuery, Unit>
{
    private readonly IUserRepository _userRepository;

    public SignOutUserQueryHandler(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }
    public async Task<Unit> Handle(SignOutUserQuery request, CancellationToken cancellationToken)
    {
        //Handling Logout
        await _userRepository.LogoutAsync();
        return Unit.Value;
    }
}