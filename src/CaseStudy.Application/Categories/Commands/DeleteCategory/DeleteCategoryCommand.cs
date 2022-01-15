using MediatR;

namespace CaseStudy.Application.Categories.Commands.DeleteCategory
{
    public class DeleteCategoryCommand : IRequest
    {
        public string Id { get; set; }
    }
}