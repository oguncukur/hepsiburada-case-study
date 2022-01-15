using MediatR;

namespace CaseStudy.Application.Products.Commands.DeleteProduct
{
    public class DeleteProductCommand : IRequest
    {
        public string Id { get; private set; }

        public DeleteProductCommand(string id)
        {
            Id = id;
        }
    }
}