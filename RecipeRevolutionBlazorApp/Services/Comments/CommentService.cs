using RecipeRevolutionBlazorApp.Models.Comment;
using RecipeRevolutionBlazorApp.Services.Token;
using System.Net.Http.Json;

namespace RecipeRevolutionBlazorApp.Services.Comments
{
    public class CommentService : ICommentService
    {
        private readonly HttpClient _httpClient;
        private readonly AuthTokenService _authTokenService;
        public CommentService(HttpClient httpClient, AuthTokenService authTokenService)
        {
            _httpClient = httpClient ?? throw new ArgumentNullException(nameof(httpClient));
            _authTokenService = authTokenService ?? throw new ArgumentNullException(nameof(authTokenService));
        }
        public async Task<CommentDto> GetComment(int commentId)
        {
            var apiUrl = $"api/comment/{commentId}";
            return await _httpClient.GetFromJsonAsync<CommentDto>(apiUrl);
        }

        public async Task<CommentDto> CreateComment(CommentDto commentDto)
        {
            var apiUrl = "api/comment";
            var response = await _httpClient.PostAsJsonAsync(apiUrl, commentDto);
            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadFromJsonAsync<CommentDto>();
            }
            throw new InvalidOperationException("Nie udało się utworzyć komentarza");
        }

        public async Task<bool> DeleteComment(int commentId)
        {
            var apiUrl = $"api/comment/{commentId}";
            var response = await _httpClient.DeleteAsync(apiUrl);
            return response.IsSuccessStatusCode;
        }

        public async Task<List<CommentDto>> GetComments()
        {
            var apiUrl = "api/comment";
            return await _httpClient.GetFromJsonAsync<List<CommentDto>>(apiUrl);
        }

        public async Task<List<DisplayCommentDto>> GetRecipeComments(int id)
        {
            var apiUrl = $"api/comment/recipe?id={id}";
            return await _httpClient.GetFromJsonAsync<List<DisplayCommentDto>>(apiUrl);
        }

        public async Task<List<CommentUserDto>> GetUserComments()
        {
            var apiUrl = "api/comment/user";
            return await _httpClient.GetFromJsonAsync<List<CommentUserDto>>(apiUrl);
        }

        public async Task<bool> UpdateComment(UpdateCommentDto updateCommentDto, int commentId)
        {
            var apiUrl = $"api/comment/{commentId}";
            var response = await _httpClient.PutAsJsonAsync(apiUrl, updateCommentDto);
            return response.IsSuccessStatusCode;
        }
    }
}
