using AutoMapper;
using CaseStudy.Application.Infrastructure;
using CaseStudy.Application.Repository;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace CaseStudy.Application.Products.Queries.GetProduct
{
    public class GetProductQueryHandler : IRequestHandler<GetProductQuery, ProductDto>
    {
        private readonly IMapper _mapper;
        private readonly ICacheService _cacheService;
        private readonly IProductRepository _productRepository;
        private readonly ILogger<GetProductQueryHandler> _logger;

        public GetProductQueryHandler(IProductRepository productRepository, IMapper mapper, ICacheService cacheService, ILogger<GetProductQueryHandler> logger)
        {
            _productRepository = productRepository ?? throw new ArgumentNullException(nameof(productRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _cacheService = cacheService ?? throw new ArgumentNullException(nameof(cacheService));
        }

        public async Task<ProductDto> Handle(GetProductQuery request, CancellationToken cancellationToken)
        {
            var validator = new GetProductQueryValidator();
            var validationResult = await validator.ValidateAsync(request, cancellationToken);
            if (!validationResult.IsValid)
            {
                _logger.LogError("Get request model is not valid. Errors: {0}", string.Join(",", validationResult.Errors.Select(x => x.ErrorMessage)));
                throw new Exception();
            }

            var cachedProduct = _cacheService.Get<ProductDto>(request.Id);

            if (cachedProduct != null)
            {
                return cachedProduct;
            }

            var product = await _productRepository.GetWithCategoryAsync(request.Id);
            var productDto = _mapper.Map<ProductDto>(product);
            _cacheService.Set(product.Id, productDto, TimeSpan.FromMinutes(5));
            return productDto;
        }
    }
}