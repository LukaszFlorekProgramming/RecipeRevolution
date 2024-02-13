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
        public async Task<int> GetExpiresIn()
        {
            return await _localStorage.GetItemAsync<int>("expiresIn");
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

            return true;
        }

        public async Task SetIssuedAt(DateTime issuedAt)
        {
            await _localStorage.SetItemAsync("issuedAt", issuedAt);
        }

        public async Task ClearAllTokens()
        {
            await ClearToken();
            await ClearRefreshToken();
            await ClearExpiresIn();
            await _localStorage.RemoveItemAsync("issuedAt");
        }

    }
}
