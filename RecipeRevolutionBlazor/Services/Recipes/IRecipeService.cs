using RecipeRevolutionBlazor.Models;

namespace RecipeRevolutionBlazor.Services.Recipes
{
    public interface IRecipeService
    {
        Task<List<RecipeDto>> GetRecipes();
        Task <IEnumerable<MyRecipeDto>> GetUserRecipes(int id);
        Task<RecipeDto> GetById(int id);
       
        Task<int> Create(CreateRecipeDto recipeDto);
        Task Update(UpdateRecipeDto recipeDto, int id);
        Task Delete(int id);
        Task<PagedResult<RecipeDto>> GetAll(RecipeQuery query);
        Task<PagedResult<RecipeWithPhotoDto>> GetAllWithPhoto(RecipeQuery query);

        Task<IEnumerable<CategoryDto>> GetAllCategory();

    }
}
