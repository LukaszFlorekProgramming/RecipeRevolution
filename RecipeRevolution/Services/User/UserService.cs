using AutoMapper;
using RecipeRevolution.Domain.Models;
using RecipeRevolution.Persistance;

namespace RecipeRevolution.Services.User
{
    public class UserService : IUserService
    {
        private readonly RecipeRevolutionDbContext _context;
        private readonly IMapper _mapper;

        public UserService(RecipeRevolutionDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task UpdateUserAsync(Domain.Entities.User user, UpdateUserDto updateUserDto)
        {
            user.FirstName = updateUserDto.FirstName;
            user.LastName = updateUserDto.LastName;
            user.Gender = updateUserDto.Gender;
            user.DateOfBirth = updateUserDto.DateOfBirth;
            await _context.SaveChangesAsync();
        }
        public async Task<Domain.Entities.User> FindUserByIdAsync(string id)
        {
            return await _context.Users.FindAsync(id);
        }
        public async Task<UpdateUserDto> GetUserByIdAsync(string id)
        {
            var user = await _context.Users.FindAsync(id);
            if (user == null) return null;

            return _mapper.Map<UpdateUserDto>(user);
        }
        public async Task<UserProfileDto> GetUserProfileByIdAsync(string userId)
        {
            var user = await _context.Users.FindAsync(userId);
            if (user == null)
            {
                return null;
            }

            return new UserProfileDto
            {
                FirstName = user.FirstName,
                LastName = user.LastName
            };
        }
        public async Task<bool> IsUserProfileCompleteAsync(string userId)
        {
            var user = await _context.Users.FindAsync(userId);
            var isNameFieldsNotEmpty = !string.IsNullOrWhiteSpace(user.FirstName) && !string.IsNullOrWhiteSpace(user.LastName);
            return user.IsProfileComplete && isNameFieldsNotEmpty;
        }
    }
}
