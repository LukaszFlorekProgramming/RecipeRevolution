using RecipeRevolutionBlazorApp.Models.Image;
using RecipeRevolutionBlazorApp.Services.Token;
using System.Net.Http.Headers;
using System.Net.Http.Json;

namespace RecipeRevolutionBlazorApp.Services.Images
{
    public class ImageService : IImageService
    {
        private readonly HttpClient _httpClient;
        private readonly AuthTokenService _authTokenService;
        public ImageService(HttpClient httpClient, AuthTokenService authTokenService)
        {
            _httpClient = httpClient ?? throw new ArgumentNullException(nameof(httpClient));
            _authTokenService = authTokenService ?? throw new ArgumentNullException(nameof(authTokenService));
        }

        public async Task Create(ImageDto imageDto)
        {
            SetAuthorizationHeader();
            var apiUrl = "api/image";
            await _httpClient.PostAsJsonAsync(apiUrl, imageDto);
        }

        public async Task<ImageDto> GetById(int id)
        {
            var apiUrl = $"api/image/{id}";
            return await _httpClient.GetFromJsonAsync<ImageDto>(apiUrl);
        }

        public async Task<ImageDto> GetByRecipeId(int id)
        {
            var apiUrl = $"api/image/recipeId/{id}";
            return await _httpClient.GetFromJsonAsync<ImageDto>(apiUrl);
        }

        private async void SetAuthorizationHeader()
        {
            var authToken = await _authTokenService.GetToken();

            if (!string.IsNullOrEmpty(authToken))
            {
                _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", authToken);
            }
            else
            {
                throw new InvalidOperationException("Brak dostępnego tokenu.");
            }
        }
    }
}
