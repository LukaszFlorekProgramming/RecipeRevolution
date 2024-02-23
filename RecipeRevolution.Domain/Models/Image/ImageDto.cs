namespace RecipeRevolution.Domain.Models.Image
{
    public class ImageDto
    {
        public string FileName { get; set; }
        public byte[] Data { get; set; }
        public string ContentType { get; set; }
        public int RecipeId { get; set; }
    }
}
