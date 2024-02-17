using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using RecipeRevolution.Domain.Entities;
using RecipeRevolution.Domain.Models;
using RecipeRevolution.Services.User;
using System.Security.Claims;

namespace RecipeRevolution.Controllers
{
    [ApiController]
    [Route("api/user")]
    [Authorize]
    public class UsersController : Controller
    {
        private readonly IUserService _userService;
        private readonly UserManager<User> _userManager;

        public UsersController( IUserService userService, UserManager<User> userManager)
        {
            _userService = userService;
            _userManager = userManager;
        }

        [HttpGet]
        public async Task<ActionResult<UpdateUserDto>> GetUser()
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            if (string.IsNullOrEmpty(userId))
            {
                return Unauthorized();
            }
            var userDto = await _userService.GetUserByIdAsync(userId);
            if (userDto == null)
            {
                return NotFound();
            }

            return Ok(userDto);
        }

        [HttpGet("profile")]
        public async Task<ActionResult<UserProfileDto>> GetUserProfile()
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            if (string.IsNullOrEmpty(userId))
            {
                return Unauthorized();
            }

            var userProfile = await _userService.GetUserProfileByIdAsync(userId);
            if (userProfile == null)
            {
                return NotFound();
            }

            return Ok(userProfile);
        }
        [HttpPut]
        public async Task<IActionResult> UpdateUser([FromBody] UpdateUserDto userUpdateDto)
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            if (string.IsNullOrEmpty(userId))
            {
                return Unauthorized();
            }
            var user = await _userService.FindUserByIdAsync(userId);
            if (user == null)
            {
                return NotFound();
            }
            if (!string.IsNullOrWhiteSpace(user.FirstName) && !string.IsNullOrWhiteSpace(user.LastName))
            {
                user.IsProfileComplete = true;
            }
            else
            {
                user.IsProfileComplete = false;
            }

            await _userService.UpdateUserAsync(user, userUpdateDto);

            return NoContent();
        }
        [AllowAnonymous]
        [HttpGet("CheckActivation")]
        public IActionResult CheckAccountActivation(string email)
        {
            var account = _userManager.Users.FirstOrDefault(x => x.Email == email);

            if (account != null)
            {
                return Ok(account.EmailConfirmed);
            }
            return NotFound("Account not found.");
        }
        [HttpGet("IsProfileComplete")]
        public async Task<IActionResult> IsProfileComplete()
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            if (string.IsNullOrEmpty(userId))
            {
                return Unauthorized();
            }

            var isComplete = await _userService.IsUserProfileCompleteAsync(userId);

            return Ok(isComplete);
        }
    }
}
