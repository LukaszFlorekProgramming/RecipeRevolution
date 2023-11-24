using RecipeRevolution.Domain.Models;
using RecipeRevolutionBlazor.Models;

namespace RecipeRevolutionBlazor.Services.RecipesPagination
{
    public interface IRecipeServicePagination
    {
        Task<PagedResult<RecipeDto>> GetAll(RecipeQuery query);
    }
}
