using FluentValidation;
using RecipeRevolutionBlazor.Models;

namespace RecipeRevolutionBlazor.Validators
{
    public class LoginDtoValidator : AbstractValidator<LoginDto>
    {
        public LoginDtoValidator()
        {
            RuleFor(x => x.Email)
                .NotEmpty()
                .MaximumLength(120);
            RuleFor(x => x.Password)
                .NotEmpty()
                .MaximumLength(120);
        }
    }
}
