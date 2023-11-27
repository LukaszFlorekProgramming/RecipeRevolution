using RecipeRevolutionBlazor.Models;
using RecipeRevolutionBlazor.Services.Users;
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
            var apiUrl = "api/recipe";
            await _httpClient.PostAsJsonAsync(apiUrl, recipeDto);
        }

        public async Task<List<RecipeDto>> GetRecipes()
        {
            SetAuthorizationHeader();

            var apiUrl = "api/recipes";
            return await _httpClient.GetFromJsonAsync<List<RecipeDto>>(apiUrl);
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
                // Tutaj możesz obsłużyć sytuację braku tokenu, np. zgłaszając błąd lub podejmując odpowiednie działania
            }
        }
    }
}
