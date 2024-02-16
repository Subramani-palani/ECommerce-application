
using Assignment.Contracts.Data.Entities;
using Assignment.Contracts.Data.Repositories;
using Assignment.Core.Exceptions;
using AutoMapper;
using FluentValidation;
using MediatR;

namespace Assignment.Core.Features.Categories.CreateCategoryCommand
{
    public class CreateCategoryCommandHandler : IRequestHandler<CreateCategoryCommand, Guid>
    {
        private readonly IValidator<CreateCategoryCommand> _validator;
        private readonly IMapper _mapper;
        private readonly ICategoryRepository _categoryRepository;

        public CreateCategoryCommandHandler(IValidator<CreateCategoryCommand> validator,IMapper mapper,ICategoryRepository categoryRepository)
        {
            _validator = validator;
            _mapper = mapper;
            _categoryRepository = categoryRepository;
        }
        public async Task<Guid> Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
        {
            //Validation
            var validationResult = await _validator.ValidateAsync(request);
            if(!validationResult.IsValid){
                throw new ValidatorException(validationResult);
            }

            //convert to Domain Object
            var category =  _mapper.Map<Category>(request);

            return await _categoryRepository.AddCategoryAsync(category);

        }
    }
}