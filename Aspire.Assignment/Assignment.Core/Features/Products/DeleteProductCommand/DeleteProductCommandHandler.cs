using Assignment.Contracts.Data.Repositories;
using MediatR;

namespace Assignment.Core.Features.Products.DeleteProductCommand
{
    public class DeleteProductCommandHandler : IRequestHandler<DeleteProductCommand, Unit>
    {
        private readonly IProductRepository _projectRepository;

        public DeleteProductCommandHandler(IProductRepository projectRepository)
        {
            _projectRepository = projectRepository;
        }
        public async Task<Unit> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
        {
            await _projectRepository.DeleteProductAsync(request.ProductId);

            return Unit.Value;
        }
    }
}