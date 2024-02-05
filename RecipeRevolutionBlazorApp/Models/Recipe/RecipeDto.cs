namespace RecipeRevolutionBlazorApp.Models.Recipe
{
    public class RecipeDto
    {
        public int RecipeId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Instructions { get; set; }
        public int PreparationTime { get; set; }
        public string DifficultyLevel { get; set; }
        public short Portions { get; set; }
        public string? MainImage { get; set; }
        public int CategoryId { get; set; }
    }
}
