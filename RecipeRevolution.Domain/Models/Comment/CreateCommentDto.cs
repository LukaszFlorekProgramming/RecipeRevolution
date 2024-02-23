namespace RecipeRevolution.Domain.Models.Comment
{
    public class CreateCommentDto
    {
        public int CommentId { get; set; }
        public string Text { get; set; }
        public DateTime? CreatedAt { get; set; }
        public string? CreatedById { get; set; }
        public int RecipeId { get; set; }
    }
}
