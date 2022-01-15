using CaseStudy.Domain.Entities;
using MediatR;

namespace CaseStudy.Application.Categories.Commands.PostCategory
{
    public class PostCategoryCommand : IRequest<Category>
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}