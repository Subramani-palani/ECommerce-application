using Assignment.Contracts.Data;
using Assignment.Contracts.Data.Entities.Identity;
using Assignment.Contracts.Data.Repositories;
using Assignment.Contracts.DTO;
using Assignment.Core.Exceptions;
using Assignment.Core.Features.User.Requests;
using AutoMapper;
using FluentValidation;
using MediatR;

namespace Assignment.Core.Features.User.Handlers.Commands
{
    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, Guid>
    {
        private readonly IMapper _mapper;
        private readonly IUserRepository _userRepository;
        
        private readonly IValidator<RegisterUserDTO> _validator;
        public CreateUserCommandHandler(IMapper mapper,IUserRepository userRepository,IValidator<RegisterUserDTO> validator)
        {
            _mapper = mapper;
            _userRepository = userRepository;
            _validator = validator;
        }
        public async Task<Guid> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            //Validation
            
            var validationResult = await _validator.ValidateAsync(request.RegisterUserDto);
            if(!validationResult.IsValid){
                throw new ValidatorException(validationResult);
            }

            //step1: convert to Domain Object
            var user = _mapper.Map<ApplicationUser>(request.RegisterUserDto);
            user.UserName = user.Email;

            Guid newId = await _userRepository.RegisterUserAsync(user,request.RegisterUserDto.Password);
            
            if(newId == Guid.Empty){
                throw new Exception("User Account Creation Failed");
            }

            return newId;
        }
    }
}