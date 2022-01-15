using AutoMapper;
using CaseStudy.Application.Repository;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace CaseStudy.Application.Categories.Queries.GetCategory
{
    public class GetCategoryQueryHandler : IRequestHandler<GetCategoryQuery, CategoryDto>
    {
        private readonly IMapper _mapper;
        private readonly ICategoryRepository _categoryRepository;
        private readonly ILogger<GetCategoryQueryHandler> _logger;

        public GetCategoryQueryHandler(ICategoryRepository categoryRepository, IMapper mapper, ILogger<GetCategoryQueryHandler> logger)
        {
            _categoryRepository = categoryRepository ?? throw new ArgumentNullException(nameof(categoryRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task<CategoryDto> Handle(GetCategoryQuery request, CancellationToken cancellationToken)
        {
            var validator = new GetCategoryQueryValidator();
            var validationResult = await validator.ValidateAsync(request, cancellationToken);
            if (!validationResult.IsValid)
            {
                _logger.LogError("Get request model is not valid. Errors: {0}", string.Join(",", validationResult.Errors.Select(x => x.ErrorMessage)));
                throw new Exception();
            }

            var product = await _categoryRepository.GetAsync(request.Id);
            return _mapper.Map<CategoryDto>(product);
        }
    }
}