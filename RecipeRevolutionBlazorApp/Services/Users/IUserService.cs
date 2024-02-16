using RecipeRevolutionBlazorApp.Models.User;

namespace RecipeRevolutionBlazorApp.Services.Users
{
    public interface IUserService
    {
        Task<string> LoginUser(LoginDto loginDto);
        Task<bool> RegisterUser(RegisterUserDto registerUserDto);
        Task<bool> SendPasswordResetLink(ResetPasswordDto resetPasswordDto);
        Task<bool> ConfirmResetPassword(ConfirmResetPasswordDto confirmResetPasswordDto);
        Task<UpdateUserDto> GetUserAsync();
        Task<bool> CheckAccountActivation(string email);
        Task<bool> UpdateUserAsync(UpdateUserDto updateUserDto);
        Task<UserProfile> GetUserProfile();
    }
}
