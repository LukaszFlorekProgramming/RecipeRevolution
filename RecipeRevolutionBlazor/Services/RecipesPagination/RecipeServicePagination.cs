using RecipeRevolution.Domain.Models;
using RecipeRevolutionBlazor.Models;
using System.Net.Http.Json;

namespace RecipeRevolutionBlazor.Services.RecipesPagination
{
    public class RecipeServicePagination : IRecipeServicePagination
    {
        private readonly HttpClient _httpClient;
        public RecipeServicePagination(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<PagedResult<RecipeDto>> GetAll(RecipeQuery query)
        {
            var endpoint = $"api/recipe?searchPhrase={query.SearchPhrase}&PageSize={query.PageSize}&PageNumber={query.PageNumber}";
            return await _httpClient.GetFromJsonAsync<PagedResult<RecipeDto>>(endpoint);
        }
    }
}
