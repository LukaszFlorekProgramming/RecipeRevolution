using System.ComponentModel.DataAnnotations;

namespace RecipeRevolutionBlazorApp.Models.Comment
{
    public class CommentDto
    {
        public int CommentId { get; set; }
        [Required(ErrorMessage = "Komentarz nie może być pusty.")]
        [StringLength(500, ErrorMessage = "Komentarz nie może posiadać więcej niż 500 znaków.")]
        public string Text { get; set; }
        public DateTime? CreatedAt { get; set; }
        public string? CreatedById { get; set; }
        public int RecipeId { get; set; }
    }
}
