using FluentValidation;

namespace CaseStudy.Application.Categories.Commands.UpdateCategory
{
    public class UpdateCategoryCommandValidator : AbstractValidator<UpdateCategoryCommand>
    {
        public UpdateCategoryCommandValidator()
        {
            RuleFor(p => p.Id).NotEmpty().NotNull().WithMessage("{Id} is required.");
            RuleFor(p => p.Name).NotEmpty().NotNull().WithMessage("{Name} is required.");
            RuleFor(p => p.Description).NotEmpty().NotNull().WithMessage("{Description} is required.");
        }
    }
}