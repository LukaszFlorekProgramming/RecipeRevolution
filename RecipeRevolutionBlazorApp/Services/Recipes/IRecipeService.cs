using Microsoft.AspNetCore.Http;
using RecipeRevolutionBlazorApp.Models;
using RecipeRevolutionBlazorApp.Models.Category;
using RecipeRevolutionBlazorApp.Models.Recipe;

namespace RecipeRevolutionBlazorApp.Services.Recipes
{
    public interface IRecipeService
    {
        Task<List<RecipeDto>> GetRecipes();
        Task<List<RecipeDto>> GetUserRecipes();
        Task<PagedResult<NameAndIMGRecipeDto>> GetAllWithPhoto(RecipeQuery query);
        Task<RecipeDto> GetRecipe(int recipeId);
        Task<RecipeDto> CreateRecipe(CreateRecipeDto recipeDto);
        Task<bool> UpdateRecipe(int recipeId, UpdateRecipeDto updateRecipeDto);
        Task<bool> DeleteRecipe(int recipeId);

        Task<IEnumerable<CategoryDto>> GetAllCategory();
        Task<bool> UploadProfilePictureAsync(Stream fileStream, string fileName, int id);
        Task<IEnumerable<NameAndIMGRecipeDto>> GetRecipesByCategory(string name);
    }
}
