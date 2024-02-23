namespace RecipeRevolution.Domain.Models.Comment
{
    public class CommentDto
    {
        public int CommentId { get; set; }
        public string Text { get; set; }
        public DateTime CreatedAt { get; set; }
        public string CreatedById { get; set; }
        public int RecipeId { get; set; }
    }
}
