using FluentValidation;
using RecipeRevolutionBlazor.Models;

namespace RecipeRevolutionBlazor.Validators
{
    public class RegisterUserDtoValidator : AbstractValidator<RegisterUserDto>
    {
        public RegisterUserDtoValidator()
        {
            RuleFor(x => x.FirstName)
                .NotEmpty()
                .MaximumLength(120);
            RuleFor(x => x.LastName)
                .NotEmpty()
                .MaximumLength(120);
            RuleFor(x => x.Password).NotEmpty().WithMessage("Your password cannot be empty")
                    .MinimumLength(6).WithMessage("Your password length must be at least 6.")
                    .MaximumLength(16).WithMessage("Your password length must not exceed 16.")
                    .Matches(@"[A-Z]+").WithMessage("Your password must contain at least one uppercase letter.")
                    .Matches(@"[a-z]+").WithMessage("Your password must contain at least one lowercase letter.")
                    .Matches(@"[0-9]+").WithMessage("Your password must contain at least one number.")
                    .Matches(@"[\@\!\?\*\.]+").WithMessage("Your password must contain at least one (@!? *.).");
            RuleFor(x => x.ConfirmPassword).Equal(e => e.Password);
            RuleFor(x => x.Nationality)
               .NotEmpty()
               .MaximumLength(120);
            RuleFor(x => x.DateOfBirth)
                .NotEmpty();
            RuleFor(x => x.Email)
                .NotEmpty();
        }
    }
}
