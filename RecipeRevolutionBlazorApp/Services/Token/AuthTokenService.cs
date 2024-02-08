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
        public async Task SetexpiresIn(int token)
        {
            await _localStorage.SetItemAsync("expiresIn", token);
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



        public async Task<bool> IsTokenValid()
        {
            var token = await GetToken();
            if (string.IsNullOrEmpty(token))
            {
                return false;
            }
            var expiresIn = await _localStorage.GetItemAsync<int>("expiresIn");
            var expirationDate = DateTime.UtcNow.AddSeconds(expiresIn);
            return expirationDate > DateTime.UtcNow;
        }

    }
}
