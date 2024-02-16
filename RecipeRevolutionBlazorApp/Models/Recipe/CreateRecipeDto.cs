using System.ComponentModel.DataAnnotations;

namespace RecipeRevolutionBlazorApp.Models.Recipe
{
    public class CreateRecipeDto
    {
        [Required(ErrorMessage = "Tytuł jest wymagany.")]
        [StringLength(60, ErrorMessage = "Tytuł nie może być dłuższy niż 60 znaków.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Opis jest wymagany.")]
        [StringLength(300, ErrorMessage = "Opis nie może być dłuższy niż 300 znaków.")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Instrukcje są wymagane.")]
        [StringLength(1000, ErrorMessage = "Instrukcje nie mogą być dłuższe niż 1000 znaków.")]
        public string Instructions { get; set; }

        [Required(ErrorMessage = "Czas przygotowania jest wymagany.")]
        [Range(1, int.MaxValue, ErrorMessage = "Czas przygotowania musi być większy niż 0.")]
        public int PreparationTime { get; set; }

        [Required(ErrorMessage = "Poziom trudności jest wymagany.")]
        [Range(1, int.MaxValue, ErrorMessage = "Nieprawidłowy poziom trudności.")]
        public short DifficultyLevel { get; set; }

        [Required(ErrorMessage = "Kategoria jest wymagana.")]
        [Range(1, int.MaxValue, ErrorMessage = "Nieprawidłowa kategoria.")]
        public int CategoryId { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "Liczba porcji musi być większa niż 0.")]
        public short Portions { get; set; }
    }
}
