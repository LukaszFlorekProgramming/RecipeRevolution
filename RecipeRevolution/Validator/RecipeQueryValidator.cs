using FluentValidation;
using RecipeRevolution.Domain.Models;

namespace RecipeRevolution.Validator
{
    public class RecipeQueryValidator : AbstractValidator<RecipeQuery>
    {
        private int[] allowedPageSizes = new[] { 5, 10, 15 };
        public RecipeQueryValidator()
        {
            RuleFor(r => r.PageNumber).GreaterThanOrEqualTo(1);
            RuleFor(r => r.PageSize).Custom((value, context) => 
            { 
                if(!allowedPageSizes.Contains(value))
                {
                    context.AddFailure("PageSize", $"PageSize must in [{string.Join(",", allowedPageSizes)}]");
                }
            });
        }
    }
}
