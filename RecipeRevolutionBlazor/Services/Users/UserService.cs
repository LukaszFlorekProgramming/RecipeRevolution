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
            try
            {
                var response = await _httpClient.PostAsJsonAsync("api/account/register", registerUserDto);

                if (response.IsSuccessStatusCode)
                {
                    // Możesz dodać logikę obsługi udanej rejestracji tutaj
                    return true;
                }
                else
                {
                    // Możesz obsłużyć błędy rejestracji tutaj, na przykład wyświetlić komunikat użytkownikowi
                    return false;
                }
            }
            catch (HttpRequestException)
            {
                // Obsłuż błędy związane z żądaniem HTTP
                return false;
            }
        }

    }
}
