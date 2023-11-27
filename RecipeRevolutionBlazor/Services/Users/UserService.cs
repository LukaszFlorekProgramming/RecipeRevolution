using RecipeRevolutionBlazor.Models;
using System.Net.Http.Json;

namespace RecipeRevolutionBlazor.Services.Users
{
    public class UserService : IUserService
    {
        private readonly HttpClient _httpClient;
        public UserService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<bool> RegisterUser(RegisterUserDto registerUserDto)
        {
                var response = await _httpClient.PostAsJsonAsync("api/account/register", registerUserDto);

                if (response.IsSuccessStatusCode)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            
        }

        public async Task<string> LoginUser(LoginDto loginDto)
        {
            try
            {
                var response = await _httpClient.PostAsJsonAsync("api/account/login", loginDto);

                if (response.IsSuccessStatusCode)
                {
                    var token = await response.Content.ReadAsStringAsync();
                    // Handle the successful login, e.g., store the token or navigate to another page.
                    Console.WriteLine($"Token received: {token}");
                    return token;
                }
                else
                {
                    // Możesz obsłużyć błędy rejestracji tutaj, na przykład wyświetlić komunikat użytkownikowi
                    Console.WriteLine("Login failed");
                    return string.Empty;
                }
            }
            catch (HttpRequestException ex)
            {
                // Obsłuż błędy związane z żądaniem HTTP
                Console.WriteLine($"Error: {ex.Message}");
                return string.Empty;
            }
        }

    }
}
