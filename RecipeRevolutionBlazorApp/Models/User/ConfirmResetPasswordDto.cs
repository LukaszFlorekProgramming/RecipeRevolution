using System.ComponentModel.DataAnnotations;

namespace RecipeRevolutionBlazorApp.Models.User
{
    public class ConfirmResetPasswordDto
    {
        public string Email { get; set; }
        [Required(ErrorMessage = "Kod resetowania jest wymagany.")]
        public string ResetCode { get; set; }
        [Required(ErrorMessage = "Nowe hasło jest wymagane.")]
        [StringLength(100, ErrorMessage = "Hasło musi zawierać więcej niż 8 znaków.", MinimumLength = 8)]
        public string NewPassword { get; set; }
    }
}
