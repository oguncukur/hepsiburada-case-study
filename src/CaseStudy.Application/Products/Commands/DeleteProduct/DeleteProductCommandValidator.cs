using FluentValidation;

namespace CaseStudy.Application.Products.Commands.DeleteProduct
{
    internal class DeleteProductCommandValidator : AbstractValidator<DeleteProductCommand>
    {
        public DeleteProductCommandValidator()
        {
            RuleFor(p => p.Id).NotEmpty().NotNull().WithMessage("{Id} is required.");
        }
    }
}