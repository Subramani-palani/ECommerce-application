using Assignment.Contracts.Data.Repositories;
using Assignment.Contracts.DTO;
using Assignment.Core.Exceptions;
using Assignment.Core.Features.User.Requests;
using AutoMapper;
using FluentValidation;
using MediatR;

namespace Assignment.Core.Features.User.Handlers.Queries
{
    public class SignInUserQueryHandler : IRequestHandler<SignInUserQuery, Guid>
    {
        private readonly IMapper _mapper;
        private readonly IUserRepository _userRepository;
        private readonly IValidator<LoginUserDTO> _validator;

        public SignInUserQueryHandler(IMapper mapper,IUserRepository userRepository,IValidator<LoginUserDTO> validator)
        {
            _mapper = mapper;
            _userRepository = userRepository;
            _validator = validator;
        }
        public async Task<Guid> Handle(SignInUserQuery request, CancellationToken cancellationToken)
        {
            //validation
            var validationResult = await _validator.ValidateAsync(request.LoginUserDTO);
            if(!validationResult.IsValid){
                foreach(var error in validationResult.Errors){
                    Console.WriteLine("********************** "+error.ErrorMessage+" **************************");
                }
                throw new ValidatorException(validationResult);
            }

            return await _userRepository.AuthenticateUser(request.LoginUserDTO.Email,request.LoginUserDTO.Password);

        }
    }
}