using Assignment.Contracts.DTO;
using MediatR;

namespace Assignment.Core.Features.User.Requests
{
    public class CreateUserCommand : IRequest<Guid>
    {
        public RegisterUserDTO RegisterUserDto { get; set; }

        public CreateUserCommand(RegisterUserDTO registerUserDto)
        {
            RegisterUserDto = registerUserDto;
        }
    }
}