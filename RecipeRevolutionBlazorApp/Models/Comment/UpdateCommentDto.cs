using System.ComponentModel.DataAnnotations;

namespace RecipeRevolutionBlazorApp.Models.Comment
{
    public class UpdateCommentDto
    {
        [Required(ErrorMessage = "Komentarz nie może być pusty.")]
        [StringLength(500, ErrorMessage = "Komentarz nie może posiadać więcej niż 500 znaków.")]
        public string Text { get; set; }
    }
}
