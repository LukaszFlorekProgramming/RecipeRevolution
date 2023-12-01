using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RecipeRevolution.Application.Interfaces;
using RecipeRevolution.Domain.Entities;
using RecipeRevolution.Domain.Models;
using RecipeRevolution.Models;
using RecipeRevolution.Validator;
using System.Security.Claims;

namespace RecipeRevolution.Controllers
{
    [Route("api/recipe")]
    [ApiController]
    [Authorize]
    public class RecipeController : ControllerBase
    {
        private readonly IRecipeService _recipeService;

        public RecipeController(IRecipeService recipeService)
        {
            _recipeService = recipeService;
        }
        [HttpGet]
        [AllowAnonymous]
        public ActionResult<IEnumerable<RecipeDto>> GetAll([FromQuery] RecipeQuery query)
        {
            var validation = new RecipeQueryValidator().Validate(query);
            if (!validation.IsValid)
            {
                return BadRequest(validation.Errors);
            }
            var recipes = _recipeService.GetAll(query);
            return Ok(recipes);
        }
        [HttpGet("{id}")]
        [AllowAnonymous]
        public ActionResult<Recipe> Get([FromRoute] int id)
        {
            var recipe = _recipeService.GetById(id);

            if (recipe == null)
            {
                return NotFound();
            }

            return Ok(recipe);
        }
        [HttpGet("user")]
        public ActionResult<IEnumerable<MyRecipeDto>> GetUserRecipes()
        {
            var userId = int.Parse(User.FindFirst(c => c.Type == ClaimTypes.NameIdentifier).Value);

            var recipes = _recipeService.GetUserRecipes(userId);

            return Ok(recipes);
        }
        [Route("categories")]
        [HttpGet]
        [AllowAnonymous]
        public ActionResult<IEnumerable<RecipeDto>> GetAllCategories()
        {
            var categories = _recipeService.GetAllCategory();
            return Ok(categories);
        }
        [HttpPost]
        public ActionResult CreateRecipe([FromBody] CreateRecipeDto recipeDto)
        {
            var userId = int.Parse(User.FindFirst(c => c.Type == ClaimTypes.NameIdentifier).Value);
            var id = _recipeService.Create(recipeDto);

            return Created($"/api/recipe/{id}", null);
        }
        [HttpDelete("{id}")]
        public ActionResult Delete([FromRoute] int id)
        {
            var isDeleted = _recipeService.Delete(id);
            if (isDeleted)
            {
                return NoContent();
            }
            return NotFound();
        }
        [HttpPut("{id}")]
        public ActionResult Update([FromBody] UpdateRecipeDto updateRecipeDto, [FromRoute] int id)
        {
            var isUpdated = _recipeService.Update(updateRecipeDto, id);
            if (!isUpdated)
            {
                return NotFound();
            }
            return Ok();
        }



    }
}
