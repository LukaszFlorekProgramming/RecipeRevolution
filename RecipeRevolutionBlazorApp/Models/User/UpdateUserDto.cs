using System.ComponentModel.DataAnnotations;

namespace RecipeRevolutionBlazorApp.Models.User
{
    public class UpdateUserDto
    {
        [Required(ErrorMessage = "Pole imię jest wymagane.")]
        [StringLength(50, ErrorMessage = "Imię może zawierać maksymalnie 50 znaków.")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "Pole nazwisko jest wymagane.")]
        [StringLength(50, ErrorMessage = "Nazwisko może zawierać maksymalnie 50 znaków.")]
        public string LastName { get; set; }
        [RegularExpression("Male|Female|Other", ErrorMessage = "Nieprawidłowa płeć.")]
        [Required(ErrorMessage = "Pole płeć jest wymagane.")]
        public string Gender { get; set; }
        [Range(typeof(DateTime), "1/1/1920", "1/1/2024", ErrorMessage = "Data urodzenia musi być między 01/01/1920 a 01/01/2024.")]
        public DateTime? DateOfBirth { get; set; }
        [StringLength(50, ErrorMessage = "Narodowość może zawierać maksymalnie 50 znaków.")]
        public string? Nationality { get; set; }
    }
}
