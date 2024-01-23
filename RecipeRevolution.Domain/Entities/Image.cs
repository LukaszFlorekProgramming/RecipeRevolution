namespace RecipeRevolution.Domain.Entities
{
    public class Image
    {
        public int ImageId { get; set; }
        public string FileName { get; set; }
        public byte[] Data { get; set; }
        public string ContentType { get; set; }
        public int RecipeId { get; set; }
        public Recipe Recipe { get; set; }
    }
}
