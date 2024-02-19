using Assignment.Contracts.Data.Entities;
using Assignment.Contracts.Data.Repositories;
using Assignment.Contracts.DTO;
using Assignment.Core.Exceptions;
using AutoMapper;
using FluentValidation;
using MediatR;

namespace Assignment.Core.Features.Products.UpdateProductCommand
{
    public class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommand, GetProductsDTO>
    {
        private readonly IValidator<UpdateProductCommand> _validator;
        private readonly IMapper _mapper;
        private readonly IProductRepository _productRepository;

        public UpdateProductCommandHandler(IValidator<UpdateProductCommand> validator,IMapper mapper,IProductRepository productRepository)
        {
            _validator = validator;
            _mapper = mapper;
            _productRepository = productRepository;
        }
        public async Task<GetProductsDTO?> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
        {
            //Validation
            var validatorResult = _validator.Validate(request);

            if(!validatorResult.IsValid){
                throw new ValidatorException(validatorResult);
            }

            //Mapping the command to Domain Object
            var productTobeUpdated = _mapper.Map<Product>(request);

            //Update the project
            Product? updatedProduct = await _productRepository.UpdateProductAsync(productTobeUpdated);

            if(updatedProduct == null){
                return null;
            }

            //Mapping the Domain Object to GetProductsDTO
            return _mapper.Map<GetProductsDTO>(updatedProduct);

        }
    }
}