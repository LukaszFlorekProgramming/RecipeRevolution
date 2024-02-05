using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using RecipeRevolutionBlazorApp.Models;
using RecipeRevolutionBlazorApp.Models.Category;
using RecipeRevolutionBlazorApp.Models.Recipe;
using RecipeRevolutionBlazorApp.Models.User;
using RecipeRevolutionBlazorApp.Services.Token;
using System.Net.Http.Headers;
using System.Net.Http.Json;

namespace RecipeRevolutionBlazorApp.Services.Recipes
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

        public async Task<RecipeDto> CreateRecipe(CreateRecipeDto recipeDto)
        {
            var apiUrl = "api/recipe";
            var response = await _httpClient.PostAsJsonAsync(apiUrl, recipeDto);
            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadFromJsonAsync<RecipeDto>();
            }
            throw new InvalidOperationException("Nie udało się utworzyć eventu");
        }

        public async Task<bool> DeleteRecipe(int recipeId)
        {
            var apiUrl = $"api/recipe/{recipeId}";
            var response = await _httpClient.DeleteAsync(apiUrl);
            return response.IsSuccessStatusCode;
        }

        public async Task<IEnumerable<CategoryDto>> GetAllCategory()
        {
            var apiUrl = "api/recipe/categories";
            return await _httpClient.GetFromJsonAsync<IEnumerable<CategoryDto>>(apiUrl);
        }

        public async Task<List<RecipeDto>> GetRecipes()
        {
            var apiUrl = "api/recipe";
            return await _httpClient.GetFromJsonAsync<List<RecipeDto>>(apiUrl);
        }

        public async Task<RecipeDto> GetRecipe(int recipeId)
        {
            var apiUrl = $"api/recipe/{recipeId}";
            return await _httpClient.GetFromJsonAsync<RecipeDto>(apiUrl);
        }

        public async Task<List<RecipeDto>> GetUserRecipes()
        {
            var apiUrl = "api/recipe/user";
            return await _httpClient.GetFromJsonAsync<List<RecipeDto>>(apiUrl);
        }

        public async Task<bool> UpdateRecipe(int recipeId, UpdateRecipeDto updateRecipeDto)
        {
            var apiUrl = $"api/recipe/{recipeId}";
            var response = await _httpClient.PutAsJsonAsync(apiUrl, updateRecipeDto);
            return response.IsSuccessStatusCode;
        }

        public async Task<PagedResult<NameAndIMGRecipeDto>> GetAllWithPhoto(RecipeQuery query)
        {
            var endpoint = $"api/recipe/image?PageSize={query.PageSize}&PageNumber={query.PageNumber}";

            if (!string.IsNullOrEmpty(query.SearchPhrase))
            {
                endpoint += $"&searchPhrase={query.SearchPhrase}";
            }
            else
            {
                endpoint += "&searchPhrase=all";
            }

            return await _httpClient.GetFromJsonAsync<PagedResult<NameAndIMGRecipeDto>>(endpoint);
        }
        public async Task<bool> UploadProfilePictureAsync(Stream fileStream, string fileName,int id)
        {
            try
            {
                var content = new MultipartFormDataContent();
                var fileContent = new StreamContent(fileStream);
                fileContent.Headers.ContentDisposition = new ContentDispositionHeaderValue("form-data")
                {
                    Name = "file",
                    FileName = fileName
                };

                content.Add(fileContent);

                var response = await _httpClient.PostAsync($"api/recipe/{id}/upload-image", content);

                return response.IsSuccessStatusCode;
            }
            catch (Exception ex)
            {
                // Log the exception or handle it as necessary
                Console.WriteLine($"Error uploading profile picture: {ex.Message}");
                return false;
            }
        }

        public async Task<IEnumerable<NameAndIMGRecipeDto>> GetRecipesByCategory(string name)
        {
            var apiUrl = $"/api/recipe/category?name={name}";
            return await _httpClient.GetFromJsonAsync<IEnumerable<NameAndIMGRecipeDto>>(apiUrl);
        }
    }
}
