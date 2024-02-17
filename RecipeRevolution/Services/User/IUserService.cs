using RecipeRevolution.Domain.Models;

namespace RecipeRevolution.Services.User
{
    public interface IUserService
    {
        Task UpdateUserAsync(Domain.Entities.User user, UpdateUserDto updateUserDto);
        Task<Domain.Entities.User> FindUserByIdAsync(string id);
        Task<UpdateUserDto> GetUserByIdAsync(string id);
        Task<UserProfileDto> GetUserProfileByIdAsync(string userId);
        Task<bool> IsUserProfileCompleteAsync(string userId);
    }
}
