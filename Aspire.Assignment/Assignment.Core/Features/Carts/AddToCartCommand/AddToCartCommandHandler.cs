using Assignment.Contracts.Data.Repositories;
using Assignment.Core.Exceptions;
using FluentValidation;
using MediatR;

namespace Assignment.Core.Features.Carts.AddToCartCommand
{
    public class AddToCartCommandHandler : IRequestHandler<AddToCartCommand, string>
    {
        private readonly ICartRepository _cartRepository;
        private readonly IValidator<AddToCartCommand> _validator;

        public AddToCartCommandHandler(ICartRepository cartRepository,IValidator<AddToCartCommand> validator)
        {
            _cartRepository = cartRepository;
            _validator = validator;
        }
        public async Task<string> Handle(AddToCartCommand request, CancellationToken cancellationToken)
        {
            //Validation
            var validationResult = _validator.Validate(request);
            if(!validationResult.IsValid)
            {
                throw new ValidatorException(validationResult);
            }

            string response = await _cartRepository.AddProductToCartAsync(request.UserId,request.ProductId);

            return response;

        }
    }
}