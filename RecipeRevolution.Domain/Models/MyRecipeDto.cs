namespace RecipeRevolution.Domain.Models
{
    public class MyRecipeDto
    {
        public int RecipeId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Instructions { get; set; }
        public int PreparationTime { get; set; }
        public short DifficultyLevel { get; set; }
        public short Portions { get; set; }
    }
}
