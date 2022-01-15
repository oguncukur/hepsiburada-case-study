using MediatR;

namespace CaseStudy.Application.Products.Commands.UpdateProduct
{
    public class UpdateProductCommand : IRequest
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }
    }
}