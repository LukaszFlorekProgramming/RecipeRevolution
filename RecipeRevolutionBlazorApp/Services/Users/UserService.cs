using RecipeRevolutionBlazorApp.Models.User;
using RecipeRevolutionBlazorApp.Services.Token;
using System.Net.Http.Headers;
using System.Net.Http.Json;

namespace RecipeRevolutionBlazorApp.Services.Users
{
    public class UserService : IUserService
    {
        private readonly HttpClient _httpClient;
        private readonly AuthTokenService _authTokenService;

        public UserService(HttpClient httpClient, AuthTokenService authTokenService)
        {
            _httpClient = httpClient;
            _authTokenService = authTokenService;
        }
        public async Task<bool> RegisterUser(RegisterUserDto registerUserDto)
        {
            var response = await _httpClient.PostAsJsonAsync("/register", registerUserDto);

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
                var response = await _httpClient.PostAsJsonAsync("/login", loginDto);

                if (response.IsSuccessStatusCode)
                {
                    var token = await response.Content.ReadAsStringAsync();
                    Console.WriteLine($"Token received: {token}");
                    return token;
                }
                else
                {
                    Console.WriteLine("Login failed");
                    return string.Empty;
                }
            }
            catch (HttpRequestException ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                return string.Empty;
            }
        }
        public async Task<bool> SendPasswordResetLink(ResetPasswordDto resetPasswordDto)
        {
            var response = await _httpClient.PostAsJsonAsync($"/forgotPassword", resetPasswordDto);
            if (response.IsSuccessStatusCode)
            {
                return true;
            }
            else if (response.StatusCode == System.Net.HttpStatusCode.NotFound)
            {
                throw new Exception("Account not found.");
            }
            else
            {
                throw new Exception("Error checking account activation.");
            }
        }

        public async Task<bool> ConfirmResetPassword(ConfirmResetPasswordDto confirmResetPasswordDto)
        {
            var response = await _httpClient.PostAsJsonAsync($"/resetPassword", confirmResetPasswordDto);
            if (response.IsSuccessStatusCode)
            {
                return true;
            }
            else if (response.StatusCode == System.Net.HttpStatusCode.NotFound)
            {
                throw new Exception("Account not found.");
            }
            else
            {
                throw new Exception("Error checking account activation.");
            }
        }

        public async Task<UpdateUserDto> GetUserAsync()
        {
            try
            {
                var response = await _httpClient.GetAsync($"api/user");
                if (response.IsSuccessStatusCode)
                {
                    var userDto = await response.Content.ReadFromJsonAsync<UpdateUserDto>();
                    return userDto;
                }

                throw new Exception("Failed to retrieve user. Status code: " + response.StatusCode);
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public async Task<bool> CheckAccountActivation(string email)
        {
            var response = await _httpClient.GetAsync($"api/user/CheckActivation?email={email}");
            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadFromJsonAsync<bool>();//.ReadAsAsync<bool>();
            }
            else if (response.StatusCode == System.Net.HttpStatusCode.NotFound)
            {
                throw new Exception("Account not found.");
            }
            else
            {
                throw new Exception("Error checking account activation.");
            }
        }
        public async Task<bool> UpdateUserAsync(UpdateUserDto updateUserDto)
        {
            try
            {
                var response = await _httpClient.PutAsJsonAsync($"api/user", updateUserDto);
                return response.IsSuccessStatusCode;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public async Task<UserProfile> GetUserProfile()
        {
            var token = await _authTokenService.GetToken();
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

            var response = await _httpClient.GetAsync("api/user/profile");
            if (response.IsSuccessStatusCode)
            {
                var userProfile = await response.Content.ReadFromJsonAsync<UserProfile>();
                return userProfile;
            }

            return null;
        }
    }
}
