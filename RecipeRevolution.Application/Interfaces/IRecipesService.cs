using RecipeRevolution.Models;


namespace RecipeRevolution.Application.Interfaces
{
    public interface IRecipesService
    {
        IEnumerable<RecipeDto> GetAll();
    }
}
