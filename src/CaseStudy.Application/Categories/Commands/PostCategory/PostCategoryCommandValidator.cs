using FluentValidation;

namespace CaseStudy.Application.Categories.Commands.PostCategory
{
    public class PostCategoryCommandValidator : AbstractValidator<PostCategoryCommand>
    {
        public PostCategoryCommandValidator()
        {
            RuleFor(p => p.Name).NotEmpty().NotNull().WithMessage("{Name} is required.");
            RuleFor(p => p.Description).NotEmpty().NotNull().WithMessage("{Description} is required.");
        }
    }
}