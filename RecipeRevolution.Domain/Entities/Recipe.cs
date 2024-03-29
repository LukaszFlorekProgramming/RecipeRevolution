﻿namespace RecipeRevolution.Domain.Entities
{
    public class Recipe
    {
        public int RecipeId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Instructions { get; set; }
        public int PreparationTime { get; set; }
        public short DifficultyLevel { get; set; }
        public short Portions { get; set; }
        public string CreatedById { get; set; }
        public string? MainImage { get; set; }
        public virtual User CreatedBy { get; set; }

        public int CategoryId { get; set; }
        public Category Category { get; set; }

        public ICollection<Ingredient> Ingredients { get; set; }
        public ICollection<Image> Images { get; set; }
        public NutritionalValues NutritionalValues { get; set; }
        public ICollection<Comment> Comments { get; set; }
    }
}
