using RecipeRevolutionBlazor.Models;

namespace RecipeRevolutionBlazor.Services.Users
{
    public interface IUserService
    {
        Task<bool> RegisterUser(RegisterUserDto registerUserDto);
    }
}
