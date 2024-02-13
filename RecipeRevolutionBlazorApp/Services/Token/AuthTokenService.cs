using Blazored.LocalStorage;

namespace RecipeRevolutionBlazorApp.Services.Token
{
    public class AuthTokenService
    {
        private readonly ILocalStorageService _localStorage;
        public AuthTokenService(ILocalStorageService localStorage)
        {
            _localStorage = localStorage;
        }

        public async Task SetRefreshToken(string token)
        {
            await _localStorage.SetItemAsync("refreshToken", token);
        }
        public async Task SetExpiresIn(int expiresIn)
        {
            await _localStorage.SetItemAsync("expiresIn", expiresIn);
        }
        public async Task SetToken(string token)
        {
            await _localStorage.SetItemAsync("authToken", token);
        }
        public async Task SetTokenWithExpiry(string token, int expiresIn)
        {
            await SetToken(token);
            await SetExpiresIn(expiresIn);

            var issuedAt = DateTime.UtcNow;
            await SetIssuedAt(issuedAt);
        }
        public async Task SetIssuedAt(DateTime issuedAt)
        {
            await _localStorage.SetItemAsync("issuedAt", issuedAt.ToString("o"));
        }


        public async Task<string> GetToken()
        {
            return await _localStorage.GetItemAsStringAsync("authToken");
        }

        public async Task ClearToken()
        {
            await _localStorage.RemoveItemAsync("authToken");
        }
        public async Task<string> GetRefreshToken()
        {
            return await _localStorage.GetItemAsStringAsync("refreshToken");
        }
        public async Task ClearRefreshToken()
        {
            await _localStorage.RemoveItemAsync("refreshToken");
        }
        public async Task ClearExpiresIn()
        {
            await _localStorage.RemoveItemAsync("expiresIn");
        }

        public async Task<bool> IsTokenValid()
        {
            var token = await GetToken();
            if (string.IsNullOrEmpty(token))
            {
                return false;
            }

            var issuedAt = await _localStorage.GetItemAsync<DateTime>("issuedAt");
            var expiresIn = await _localStorage.GetItemAsync<int>("expiresIn");
            var expiresAt = issuedAt.AddSeconds(expiresIn);

            return DateTime.UtcNow < expiresAt;
        }
    }
}
