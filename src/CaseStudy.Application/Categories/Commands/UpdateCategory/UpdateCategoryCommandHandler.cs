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

namespace CaseStudy.Application.Categories.Commands.UpdateCategory
{
    public class UpdateCategoryCommandHandler : IRequestHandler<UpdateCategoryCommand>
    {
        private readonly IMapper _mapper;
        private readonly ICategoryRepository _categoryRepository;
        private readonly ILogger<UpdateCategoryCommandHandler> _logger;

        public UpdateCategoryCommandHandler(ICategoryRepository categoryRepository, IMapper mapper, ILogger<UpdateCategoryCommandHandler> logger)
        {
            _categoryRepository = categoryRepository ?? throw new ArgumentNullException(nameof(categoryRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task<Unit> Handle(UpdateCategoryCommand request, CancellationToken cancellationToken)
        {
            var validator = new UpdateCategoryCommandValidator();
            var validationResult = await validator.ValidateAsync(request, cancellationToken);
            if (!validationResult.IsValid)
            {
                _logger.LogError("Update request model is not valid. Errors: {0}", string.Join(",", validationResult.Errors.Select(x => x.ErrorMessage)));
                throw new ValidationException(string.Join(",", validationResult.Errors.Select(x => x.ErrorMessage)));
            }

            await _categoryRepository.UpdateAsync(request.Id, _mapper.Map<Category>(request));
            _logger.LogInformation($"Product {request.Id} is successfully updated.");
            return Unit.Value;
        }
    }
}