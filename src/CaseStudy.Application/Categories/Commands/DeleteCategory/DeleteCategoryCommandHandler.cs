using System;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using CaseStudy.Application.Repository;
using Microsoft.Extensions.Logging;
using System.Linq;
using FluentValidation;

namespace CaseStudy.Application.Categories.Commands.DeleteCategory
{
    public class DeleteCategoryCommandHandler : IRequestHandler<DeleteCategoryCommand>
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly ILogger<DeleteCategoryCommandHandler> _logger;

        public DeleteCategoryCommandHandler(ICategoryRepository categoryRepository, ILogger<DeleteCategoryCommandHandler> logger)
        {
            _categoryRepository = categoryRepository ?? throw new ArgumentNullException(nameof(categoryRepository));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task<Unit> Handle(DeleteCategoryCommand request, CancellationToken cancellationToken)
        {
            var validator = new DeleteCategoryCommandValidator();
            var validationResult = await validator.ValidateAsync(request, cancellationToken);
            if (!validationResult.IsValid)
            {
                throw new ValidationException(string.Join(",", validationResult.Errors.Select(x => x.ErrorMessage)));
            }

            await _categoryRepository.RemoveAsync(request.Id);
            _logger.LogInformation($"Product {request.Id} is successfully deleted.");

            return Unit.Value;
        }
    }
}