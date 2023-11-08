using Microsoft.AspNetCore.Identity;
using RecipeRevolution.Application.Interfaces;
using RecipeRevolution.Domain.Entities;
using RecipeRevolution.Domain.Models;
using RecipeRevolution.Persistance;

namespace RecipeRevolution.Services
{
    public class AccountService : IAccountService
    {
        private readonly RecipeRevolutionDbContext _context;
        private readonly IPasswordHasher<User> _passwordHasher;
        public AccountService(RecipeRevolutionDbContext context, IPasswordHasher<User> passwordHasher)
        {
            _context = context;
            _passwordHasher = passwordHasher;
        }
        public void RegisterUser(RegisterUserDto registerUserDto)
        {
            var newUser = new User()
            {
                FirstName = registerUserDto.FirstName,
                LastName = registerUserDto.LastName,
                PasswordHash = registerUserDto.Password,
                Email = registerUserDto.Email,
                DateOfBirth = registerUserDto.DateOfBirth,
                Nationality = registerUserDto.Nationality,
                RoleId = registerUserDto.RoleId
            };

            var hashedPassword = _passwordHasher.HashPassword(newUser, registerUserDto.Password);
            newUser.PasswordHash = hashedPassword;
            _context.Users.Add(newUser);
            _context.SaveChanges();
        }
    }
}
