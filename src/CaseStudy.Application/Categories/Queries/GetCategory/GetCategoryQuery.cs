using MediatR;

namespace CaseStudy.Application.Categories.Queries.GetCategory
{
    public class GetCategoryQuery : IRequest<CategoryDto>
    {
        public string Id { get; set; }
        public GetCategoryQuery(string id)
        {
            Id = id;
        }
    }
}