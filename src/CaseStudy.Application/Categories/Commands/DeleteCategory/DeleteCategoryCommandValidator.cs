using FluentValidation;
using CaseStudy.Application.Products.Commands.DeleteProduct;

namespace CaseStudy.Application.Categories.Commands.DeleteCategory
{
    internal class DeleteCategoryCommandValidator : AbstractValidator<DeleteCategoryCommand>
    {
        public DeleteCategoryCommandValidator()
        {
            RuleFor(p => p.Id).NotEmpty().NotNull().WithMessage("{Id} is required.");
        }
    }
}