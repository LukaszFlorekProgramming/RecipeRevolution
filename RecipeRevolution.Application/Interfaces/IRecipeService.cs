using Microsoft.AspNetCore.Http;
using RecipeRevolution.Domain.Models;
using RecipeRevolution.Domain.Models.Category;
using RecipeRevolution.Domain.Models.Recipe;
using RecipeRevolution.Models;

namespace RecipeRevolution.Application.Interfaces
{
    public interface IRecipeService
    {
        RecipeDto GetById(int id);
        PagedResult<RecipeDto> GetAll(RecipeQuery query);
        public PagedResult<RecipeWithPhotoDto> GetAllWithPhoto(RecipeQuery query);
        public PagedResult<NameAndIMGRecipeDto> GetNameAndIMGRecipe(RecipeQuery query);
        IEnumerable<MyRecipeDto> GetUserRecipes(string id);
        IEnumerable<NameAndIMGRecipeDto> GetRecipesByCategory(string name);
        IEnumerable<CategoryDto> GetAllCategory();
        int Create(CreateRecipeDto recipeDto);
        bool Delete(int id);
        bool Update(UpdateRecipeDto recipeDto, int id);
        Task<string> AddRecipePhoto(int recipeId, IFormFile photo);

    }
}
