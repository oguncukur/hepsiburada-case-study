using FluentValidation;

namespace CaseStudy.Application.Products.Queries.GetProduct
{
    internal class GetProductQueryValidator : AbstractValidator<GetProductQuery>
    {
        public GetProductQueryValidator()
        {
            RuleFor(p => p.Id).NotEmpty().NotNull().WithMessage("{Id} is required.");
        }
    }
}