using RecipeRevolution.Domain.Models;
using RecipeRevolution.Models;

namespace RecipeRevolution.Application.Interfaces
{
    public interface IRecipeService
    {
        RecipeDto GetById(int id);
        PagedResult<RecipeDto> GetAll(RecipeQuery query);
        public PagedResult<RecipeWithPhotoDto> GetAllWithPhoto(RecipeQuery query);
        IEnumerable<MyRecipeDto> GetUserRecipes(string id);
        IEnumerable<RecipeWithPhotoDto> GetRecipesByCategory(string name);
        IEnumerable<CategoryDto> GetAllCategory();
        int Create(CreateRecipeDto recipeDto);
        bool Delete(int id);
        bool Update(UpdateRecipeDto recipeDto, int id);

    }
}
