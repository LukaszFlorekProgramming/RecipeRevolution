using RecipeRevolutionBlazor.Models;
using RecipeRevolutionBlazor.Services.Users;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;

namespace RecipeRevolutionBlazor.Services.Recipes
{
    public class RecipeService : IRecipeService
    {
        private readonly HttpClient _httpClient;
        private readonly AuthTokenService _authTokenService;
        public RecipeService(HttpClient httpClient, AuthTokenService authTokenService)
        {
            _httpClient = httpClient ?? throw new ArgumentNullException(nameof(httpClient));
            _authTokenService = authTokenService ?? throw new ArgumentNullException(nameof(authTokenService));
        }

        public async Task Create(CreateRecipeDto recipeDto)
        {
            SetAuthorizationHeader();
            var apiUrl = "api/recipe";
            await _httpClient.PostAsJsonAsync(apiUrl, recipeDto);
        }

        public async Task Delete(int id)
        {
            var apiUrl = $"api/recipe/{id}";
            await _httpClient.DeleteAsync(apiUrl);
        }

        public async Task<RecipeDto> GetById(int id)
        {
            var apiUrl = $"api/recipe/{id}";
            return await _httpClient.GetFromJsonAsync<RecipeDto>(apiUrl);
        }

        public async Task<List<RecipeDto>> GetRecipes()
        {
            var apiUrl = "api/recipes";
            return await _httpClient.GetFromJsonAsync<List<RecipeDto>>(apiUrl);
        }

        public async Task<IEnumerable<MyRecipeDto>> GetUserRecipes(int id)
        {
            var apiUrl = "api/recipe/user";
            return await _httpClient.GetFromJsonAsync<IEnumerable<MyRecipeDto>>(apiUrl);
        }

        public async Task Update(UpdateRecipeDto recipeDto, int id)
        {
            var apiUrl = $"api/recipe/{id}";
            await _httpClient.PutAsJsonAsync(apiUrl, recipeDto);
        }

        private void SetAuthorizationHeader()
        {
            var authToken = _authTokenService.Token;

            if (!string.IsNullOrEmpty(authToken))
            {
                _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", authToken);
            }
            else
            {
                Console.WriteLine("Brak dostępnego tokenu.");
            }
        }
    }
}
