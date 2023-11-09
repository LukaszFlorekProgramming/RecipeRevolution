using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using RecipeRevolution.Application.Interfaces;
using RecipeRevolution.Domain.Entities;
using RecipeRevolution.Domain.Models;
using RecipeRevolution.Persistance;
using RecipeRevolution.Validator;
using System.Runtime.Intrinsics.Arm;

namespace RecipeRevolution.Controllers
{
    [Route("api/account")]
    public class AccountController : ControllerBase
    {
        private readonly IAccountService _accountService;
        private readonly RecipeRevolutionDbContext _context;
        public AccountController(IAccountService accountService, RecipeRevolutionDbContext context)
        {
            _accountService = accountService;
            _context = context;
        }
        [HttpPost("register")]
        public ActionResult RegisterUser([FromBody] RegisterUserDto registerUserDto)
        {
            var validationResult = new RegisterUserDtoValidator(_context).Validate(registerUserDto);
            if (!validationResult.IsValid)
            {
                return BadRequest(validationResult.Errors);
            }

            _accountService.RegisterUser(registerUserDto);
            return Ok();
        }
        [HttpPost("login")]
        public ActionResult Login([FromBody]LoginDto dto)
        {
            string token = _accountService.GenerateJwt(dto);
            return Ok(token);
        }
    }
}