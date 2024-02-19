using Assignment.Contracts.Data.Repositories;
using Assignment.Core.Features.Products.UpdateProductCommand;
using FluentValidation;

namespace Assignment.Core.Validators
{
    public class UpdateProductCommandValidator : AbstractValidator<UpdateProductCommand>
    {
        private readonly ICategoryRepository _categoryRepository;

        public UpdateProductCommandValidator(ICategoryRepository categoryRepository)
        {
            RuleFor(p => p.ProductName)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull().WithMessage("{PropertyName} can't be null.")
                .MaximumLength(20)
                .WithMessage("{PropertyName} must be at max {MaxLength} characters long.");
                

            RuleFor(p => p.ProductPrice)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull().WithMessage("{PropertyName} can't be null.");

             RuleFor(p => p.ProductQuantity)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull().WithMessage("{PropertyName} can't be null.")
                .GreaterThan(0).WithMessage("{PropertyName} should be greater than {ComparisonValue}")
                .LessThan(50).WithMessage("{PropertyName} should be less than {ComparisonValue}");
                

            RuleFor(p => p.ProductDescription)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull().WithMessage("{PropertyName} can't be null.")
                .MaximumLength(300).WithMessage("{PropertyName} must be at max {MaxLength} characters long.");
                

            RuleFor(p => p.CategoryId)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull().WithMessage("{PropertyName} can't be null.")
                .MustAsync(async (id,token)=>{
                    return _categoryRepository.IsCategoryExistsAsync(id);
                }).WithMessage("Category didn't exists.");


                
            _categoryRepository = categoryRepository;
        }
    }
}