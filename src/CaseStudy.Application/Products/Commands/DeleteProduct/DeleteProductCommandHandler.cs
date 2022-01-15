using CaseStudy.Application.Repository;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace CaseStudy.Application.Products.Commands.DeleteProduct
{
    public class DeleteProductCommandHandler : IRequestHandler<DeleteProductCommand>
    {
        private readonly IProductRepository _productRepository;
        private readonly ILogger<DeleteProductCommandHandler> _logger;

        public DeleteProductCommandHandler(IProductRepository productRepository, ILogger<DeleteProductCommandHandler> logger)
        {
            _productRepository = productRepository ?? throw new ArgumentNullException(nameof(productRepository));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task<Unit> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
        {
            var validator = new DeleteProductCommandValidator();
            var validationResult = await validator.ValidateAsync(request, cancellationToken);
            if (!validationResult.IsValid)
            {
                _logger.LogError("Delete request model is not valid. Errors: {0}", string.Join(",", validationResult.Errors.Select(x => x.ErrorMessage)));
                throw new Exception();
            }

            await _productRepository.RemoveAsync(request.Id);
            _logger.LogInformation($"Product {request.Id} is successfully deleted.");

            return Unit.Value;
        }
    }
}