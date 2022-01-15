using FluentValidation;

namespace CaseStudy.Application.Products.Commands.PostProduct
{
    internal class PostProductCommandValidator : AbstractValidator<PostProductCommand>
    {
        public PostProductCommandValidator()
        {
            RuleFor(p => p.Name).NotEmpty().NotNull().WithMessage("{Name} is required.");
            RuleFor(p => p.Price).NotEmpty().NotNull().WithMessage("{Price} is required.");
            RuleFor(p => p.Currency).NotEmpty().NotNull().WithMessage("{Currency} is required.");
        }
    }
}