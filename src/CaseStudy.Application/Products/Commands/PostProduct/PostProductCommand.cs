using MediatR;
using CaseStudy.Domain.Entities;

namespace CaseStudy.Application.Products.Commands.PostProduct
{
    public class PostProductCommand : IRequest<Product>
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string Currency { get; set; }
        public string CategoryId { get; set; }
        public string Description { get; set; }
    }
}