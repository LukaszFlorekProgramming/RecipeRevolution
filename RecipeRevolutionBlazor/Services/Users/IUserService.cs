using RecipeRevolutionBlazor.Models;

namespace RecipeRevolutionBlazor.Services.Users
{
    public interface IUserService
    {
        Task<string> LoginUser(LoginDto loginDto);
        Task<bool> RegisterUser(RegisterUserDto registerUserDto);
    }
}
