using FluentValidation;

namespace CaseStudy.Application.Categories.Queries.GetCategory
{
    internal class GetCategoryQueryValidator : AbstractValidator<GetCategoryQuery>
    {
        public GetCategoryQueryValidator()
        {
            RuleFor(p => p.Id).NotEmpty().NotNull().WithMessage("{Id} is required.");
        }
    }
}