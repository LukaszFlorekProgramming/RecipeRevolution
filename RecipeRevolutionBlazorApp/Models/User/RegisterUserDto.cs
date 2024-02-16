using System.ComponentModel.DataAnnotations;

namespace RecipeRevolutionBlazorApp.Models.User
{
    public class RegisterUserDto
    {
        [Required(ErrorMessage = "Email jest wymagany.")]
        [EmailAddress(ErrorMessage = "Nieprawidłowy format adresu email.")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Hasło jest wymagane.")]
        [StringLength(100, ErrorMessage = "Hasło musi zawierać więcej niż 8 znaków.", MinimumLength = 8)]
        public string Password { get; set; }
    }
}
