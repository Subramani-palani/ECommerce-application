using Assignment.Contracts.Data.Repositories;
using Assignment.Core.Exceptions;
using FluentValidation;
using MediatR;

namespace Assignment.Core.Features.Carts.DeleteFromCartCommand
{
    public class DeleteFromCartCommandHandler : IRequestHandler<DeleteFromCartCommand, string>
    {
        private readonly IValidator<DeleteFromCartCommand> _validator;
        private readonly ICartRepository _cartRepository;

        public DeleteFromCartCommandHandler(IValidator<DeleteFromCartCommand> validator,ICartRepository cartRepository)
        {
            _validator = validator;
            _cartRepository = cartRepository;
        }
        public async Task<string> Handle(DeleteFromCartCommand request, CancellationToken cancellationToken)
        {
            //Validation
            var validationResult = _validator.Validate(request);
            if(!validationResult.IsValid)
            {
                throw new ValidatorException(validationResult);
            }

            string response = await _cartRepository.DeleteProductFromCartAsync(request.UserId,request.ProductId);

            return response;
        }
    }
}