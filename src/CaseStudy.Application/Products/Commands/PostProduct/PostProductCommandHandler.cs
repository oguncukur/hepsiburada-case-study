using AutoMapper;
using CaseStudy.Application.Repository;
using CaseStudy.Domain.Entities;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace CaseStudy.Application.Products.Commands.PostProduct
{
    public class PostProductCommandHandler : IRequestHandler<PostProductCommand, Product>
    {
        private readonly IMapper _mapper;
        private readonly IProductRepository _productRepository;
        private readonly ILogger<PostProductCommandHandler> _logger;

        public PostProductCommandHandler(IProductRepository productRepository, IMapper mapper, ILogger<PostProductCommandHandler> logger)
        {
            _productRepository = productRepository ?? throw new ArgumentNullException(nameof(productRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task<Product> Handle(PostProductCommand request, CancellationToken cancellationToken)
        {
            var validator = new PostProductCommandValidator();
            var validationResult = await validator.ValidateAsync(request, cancellationToken);
            if (!validationResult.IsValid)
            {
                _logger.LogError("Post request model is not valid. Errors: {0}", string.Join(",", validationResult.Errors.Select(x => x.ErrorMessage)));
                throw new ValidationException(string.Join(",", validationResult.Errors.Select(x => x.ErrorMessage)));
            }

            return await _productRepository.CreateAsync(_mapper.Map<Product>(request));
        }
    }
}