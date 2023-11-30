using RecipeRevolutionBlazor.Models;

namespace RecipeRevolutionBlazor.Services.Recipes
{
    public interface IRecipeService
    {
        Task<List<RecipeDto>> GetRecipes();
        Task <IEnumerable<MyRecipeDto>> GetUserRecipes(int id);
        Task<RecipeDto> GetById(int id);
        Task Create(CreateRecipeDto recipeDto);
        Task Update(UpdateRecipeDto recipeDto, int id);
        Task Delete(int id);
        Task<PagedResult<RecipeDto>> GetAll(RecipeQuery query);

    }
}
