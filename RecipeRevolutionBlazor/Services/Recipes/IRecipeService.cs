using RecipeRevolutionBlazor.Models;

namespace RecipeRevolutionBlazor.Services.Recipes
{
    public interface IRecipeService
    {
        Task<List<RecipeDto>> GetRecipes();
        Task Create(CreateRecipeDto recipeDto);

    }
}
