using AutoMapper;
using CaseStudy.Application.Repository;
using CaseStudy.Domain.Entities;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace CaseStudy.Application.Categories.Commands.PostCategory
{
    public class PostCategoryCommandHandler : IRequestHandler<PostCategoryCommand, Category>
    {
        private readonly IMapper _mapper;
        private readonly ICategoryRepository _categoryRepository;
        private readonly ILogger<PostCategoryCommandHandler> _logger;

        public PostCategoryCommandHandler(ICategoryRepository categoryRepository, IMapper mapper, ILogger<PostCategoryCommandHandler> logger)
        {
            _categoryRepository = categoryRepository ?? throw new ArgumentNullException(nameof(categoryRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task<Category> Handle(PostCategoryCommand request, CancellationToken cancellationToken)
        {
            var validator = new PostCategoryCommandValidator();
            var validationResult = await validator.ValidateAsync(request, cancellationToken);
            if (!validationResult.IsValid)
            {
                _logger.LogError("Post request model is not valid. Errors: {0}", string.Join(",", validationResult.Errors.Select(x => x.ErrorMessage)));
                throw new Exception();
            }

            return await _categoryRepository.CreateAsync(_mapper.Map<Category>(request));
        }
    }
}