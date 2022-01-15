using MediatR;

namespace CaseStudy.Application.Categories.Commands.DeleteCategory
{
    public class DeleteCategoryCommand : IRequest
    {
        public string Id { get; set; }
        public DeleteCategoryCommand(string id)
        {
            Id = id;
        }
    }
}