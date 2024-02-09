using RecipeRevolution.Domain.Entities;

namespace RecipeRevolution.Domain.Models
{
    public class CreateRecipeDto
    {
        public int RecipeId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Instructions { get; set; }
        public int PreparationTime { get; set; }
        public DifficultyLevel DifficultyLevel { get; set; }
        public short Portions { get; set; }
        public string? CreatedById { get; set; }
        public string? MainImage { get; set; }
        public int CategoryId { get; set; }
    }
}
