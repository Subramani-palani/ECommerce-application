using MediatR;

namespace Assignment.Core.Features.Categories.DeleteCategoryCommand
{
    public class DeleteCategoryCommand : IRequest<Unit>
    {
        public Guid CategoryId { get; set; }
    }
}