using MediatR;

namespace Assignment.Core.Features.Categories.CreateCategoryCommand
{
    public class CreateCategoryCommand : IRequest<Guid>
    {
        public string? CategoryName { get; set; }
    }
}