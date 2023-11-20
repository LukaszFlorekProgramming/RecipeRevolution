using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RecipeRevolution.Application.Interfaces;
using RecipeRevolution.Models;

namespace RecipeRevolution.Controllers
{
    [Route("api/recipes")]
    [ApiController]
    public class RecipesController : ControllerBase
    {
        private readonly IRecipesService _recipeService;
        public RecipesController(IRecipesService recipeService)
        {
            _recipeService = recipeService;
        }
        [HttpGet]
        public ActionResult<IEnumerable<RecipeDto>> GetAll()
        {
            var recipes = _recipeService.GetAll();
            return Ok(recipes);
        }
    }
}
