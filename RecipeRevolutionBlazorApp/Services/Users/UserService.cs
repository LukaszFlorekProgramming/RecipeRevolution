using RecipeRevolutionBlazorApp.Models.User;
using RecipeRevolutionBlazorApp.Services.Token;
using System.Net;
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
        public async Task<RegistrationResult> RegisterUser(RegisterUserDto registerUserDto)
        {
            var response = await _httpClient.PostAsJsonAsync("/register", registerUserDto);

            if (response.IsSuccessStatusCode)
            {
                return new RegistrationResult { Success = true };
            }
            else if (response.StatusCode == System.Net.HttpStatusCode.BadRequest)
            {
                var errorResponse = await response.Content.ReadFromJsonAsync<ValidationErrorResponse>();
                if (errorResponse != null && errorResponse.Errors != null)
                {
                    var errorMessages = errorResponse.Errors
                        .SelectMany(err => err.Value)
                        .ToList();

                    return new RegistrationResult
                    {
                        Success = false,
                        Errors = errorMessages
                    };
                }
                else
                {
                    return new RegistrationResult
                    {
                        Success = false,
                        Errors = new List<string> { "Unknown validation error occurred." }
                    };
                }
            }
            else
            {
                return new RegistrationResult
                {
                    Success = false,
                    Errors = new List<string> { $"Unexpected error occurred. Status code: {response.StatusCode}" }
                };
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
            else if (response.StatusCode == HttpStatusCode.Unauthorized || response.StatusCode == HttpStatusCode.Forbidden)
            {
                var isRefreshed = await RefreshToken();
                if (isRefreshed)
                {
                    token = await _authTokenService.GetToken();
                    _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                    response = await _httpClient.GetAsync("api/user/profile");

                    if (response.IsSuccessStatusCode)
                    {
                        var userProfile = await response.Content.ReadFromJsonAsync<UserProfile>();
                        return userProfile;
                    }
                }
            }


            return null;
        }

        private async Task<bool> RefreshToken()
        {
            var refreshToken = await _authTokenService.GetRefreshToken();
            var refreshResponse = await _httpClient.PostAsJsonAsync("refresh", new { refreshToken = refreshToken });

            if (refreshResponse.IsSuccessStatusCode)
            {
                var newTokens = await refreshResponse.Content.ReadFromJsonAsync<TokenResponse>();
                await _authTokenService.SetToken(newTokens.AccessToken);
                await _authTokenService.SetRefreshToken(newTokens.RefreshToken);
                await _authTokenService.SetExpiresIn(newTokens.ExpiresIn);
                var currentTime = DateTime.UtcNow;
                await _authTokenService.SetIssuedAt(currentTime);
                return true;
            }

            return false;
        }

        public async Task<bool> IsUserProfileComplete()
        {
            var apiUrl = $"api/user/IsProfileComplete";
            var isProfileComplete = await _httpClient.GetFromJsonAsync<bool>(apiUrl);
            return isProfileComplete;
        }

        public class TokenResponse
        {
            public string TokenType { get; set; }
            public string AccessToken { get; set; }
            public int ExpiresIn { get; set; }
            public string RefreshToken { get; set; }
        }

        public class ValidationErrorResponse
        {
            public string Type { get; set; }
            public string Title { get; set; }
            public int Status { get; set; }
            public Dictionary<string, string[]> Errors { get; set; }
        }
    }
}
