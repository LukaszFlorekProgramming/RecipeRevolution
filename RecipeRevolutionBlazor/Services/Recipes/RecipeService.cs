using RecipeRevolutionBlazor.Models;
using System.Net.Http.Json;

namespace RecipeRevolutionBlazor.Services.Recipes
{
    public class RecipeService : IRecipeService
    {
        private readonly HttpClient _httpClient;
        public RecipeService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<List<RecipeDto>> GetRecipes()
        {
            var apiUrl = "api/recipes";
            return await _httpClient.GetFromJsonAsync<List<RecipeDto>>(apiUrl);
        }
    }
}
