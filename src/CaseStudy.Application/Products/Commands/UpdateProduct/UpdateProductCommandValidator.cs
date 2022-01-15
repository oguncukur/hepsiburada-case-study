using FluentValidation;

namespace CaseStudy.Application.Products.Commands.UpdateProduct
{
    internal class UpdateProductCommandValidator : AbstractValidator<UpdateProductCommand>
    {
        public UpdateProductCommandValidator()
        {
            RuleFor(p => p.Id).NotEmpty().NotNull().WithMessage("{Id} is required.");
            RuleFor(p => p.Name).NotEmpty().NotNull().WithMessage("{Name} is required.");
            RuleFor(p => p.Price).NotEmpty().NotNull().WithMessage("{Price} is required.");
            RuleFor(p => p.Description).NotEmpty().NotNull().WithMessage("{Description} is required.");
        }
    }
}