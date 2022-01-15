using MediatR;

namespace CaseStudy.Application.Products.Queries.GetProduct
{
    public class GetProductQuery : IRequest<ProductDto>
    {
        public string Id { get; set; }
        public GetProductQuery(string id)
        {
            Id = id;
        }
    }
}