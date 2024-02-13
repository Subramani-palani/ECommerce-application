using Assignment.Contracts.Data.Repositories;
using Assignment.Contracts.DTO;
using FluentValidation;

namespace Assignment.Core.Validators
{
    public class RegisterUserDTOValidator : AbstractValidator<RegisterUserDTO>
    {
        private readonly IUserRepository _userRepository;

        public RegisterUserDTOValidator(IUserRepository userRepository)
        {
            _userRepository = userRepository;

            RuleFor(p => p.PersonName)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull().WithMessage("{PropertyName} can't be null.")
                .MaximumLength(50).WithMessage("{PropertyName} can't exceed more than 50 characters.");

            RuleFor(p => p.Email)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull().WithMessage("{PropertyName} can't be null.")
                .EmailAddress().WithMessage("Invalid EmailAddress.")
                .MustAsync(async (email,token)=>{
                     return await _userRepository.IsEmailAlreadyExistsAsync(email);
                }).WithMessage("Email already exists.");
                
            
            RuleFor(p => p.PhoneNumber)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull().WithMessage("{PropertyName} can't be null.")
                .Matches(@"^[6789]\d{9}$").WithMessage("Invalid PhoneNumber.");

            RuleFor(p => p.Password)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull().WithMessage("{PropertyName} can't be null.")
                .Matches(@"^(?=.*?[a-z])(?=.*?[0-9])(?=.*?[!@#$%&~])(?=.*?[A-Z]).{8,20}$").WithMessage("{PropertyName} should contain atleast one capital,digit and a special charecter.")
                .MinimumLength(8).WithMessage("{PropertyName} should contain a minimum of 8 characters.")
                .MaximumLength(15).WithMessage("{PropertName} shouldn't exceed more than 20.");

            RuleFor(p => p.ConfirmPassword)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull().WithMessage("{PropertyName} can't be null.")
                .Equal(p => p.Password).WithMessage("Confirm password must match the password.");
        }
    }
}
