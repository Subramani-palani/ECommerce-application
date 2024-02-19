using Assignment.Contracts.Data.Repositories;
using Assignment.Core.Features.Carts.AddToCartCommand;
using FluentValidation;

namespace Assignment.Core.Validators
{
    public class AddToCartCommandValidator : AbstractValidator<AddToCartCommand>
    {
        private readonly IUserRepository _userRepository;
        private readonly IProductRepository _productRepository;

        public AddToCartCommandValidator(IUserRepository userRepository,IProductRepository productRepository)
        {
            _userRepository = userRepository;
            _productRepository = productRepository;

            RuleFor(p => p.UserId)
            .NotNull().WithMessage("{PropertyName} should't be null")
            .NotEmpty().WithMessage("{PropertName} can't be empty")
            .MustAsync(async (id,token)=>{
                return await _userRepository.IsUserExistsAsync(id);
            });

            RuleFor(p => p.ProductId)
            .NotNull().WithMessage("{PropertyName} should't be null")
            .NotEmpty().WithMessage("{PropertName} can't be empty")
            .MustAsync(async (id,token)=>{
                return await _productRepository.IsProductExistsAsync(id);
            });;
        }
    }
}