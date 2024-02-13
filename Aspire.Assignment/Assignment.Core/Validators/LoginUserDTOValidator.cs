using Assignment.Contracts.Data.Repositories;
using Assignment.Contracts.DTO;
using FluentValidation;

namespace Assignment.Core.Validators
{
    public class LoginUserDTOValidator : AbstractValidator<LoginUserDTO>
    {

        public LoginUserDTOValidator()
        {
            RuleFor(p => p.Email)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull().WithMessage("{PropertyName} can't be null.")
                .EmailAddress().WithMessage("Invalid EmailAddress.");
                

            RuleFor(p => p.Password)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull().WithMessage("{PropertyName} can't be null.");
        }
    }
}
