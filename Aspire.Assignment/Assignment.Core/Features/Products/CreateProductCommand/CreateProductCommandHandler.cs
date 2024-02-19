using Assignment.Contracts.Data.Entities;
using Assignment.Contracts.Data.Repositories;
using Assignment.Core.Exceptions;
using AutoMapper;
using FluentValidation;
using MediatR;

namespace Assignment.Core.Features.Products.CreateProductCommand
{
    public class CreateProductCommandHandler : IRequestHandler<CreateProductCommand, Guid>
    {
        private readonly IValidator<CreateProductCommand> _validator;
        private readonly IMapper _mapper;
        private readonly IProductRepository _productRepository;

        public CreateProductCommandHandler(IValidator<CreateProductCommand> validator,IMapper mapper,IProductRepository productRepository)
        {
            _validator = validator;
            _mapper = mapper;
            _productRepository = productRepository;
        }
        public async Task<Guid> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            //validation
            var validatorResult = _validator.Validate(request);

            if(!validatorResult.IsValid){
                throw new ValidatorException(validatorResult);
            }

            //convert to Domain Object
            var product =  _mapper.Map<Product>(request);

            return await _productRepository.AddProductAsync(product);
            
        }
    }
}