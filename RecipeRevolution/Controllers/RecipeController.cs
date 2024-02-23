using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RecipeRevolution.Application.Interfaces;
using RecipeRevolution.Domain.Entities;
using RecipeRevolution.Domain.Models;
using RecipeRevolution.Domain.Models.Recipe;
using RecipeRevolution.Models;
using RecipeRevolution.Services.Blob;
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
        private readonly IBlobService _blobService;

        public RecipeController(IRecipeService recipeService, IBlobService blobService)
        {
            _recipeService = recipeService;
            _blobService = blobService;
        }
        [HttpPost("{recipeId}/upload-image")]
        public async Task<IActionResult> UploadRecipeImage(int recipeId, IFormFile file)
        {
            if (!User.Identity.IsAuthenticated)
            {
                return Unauthorized();
            }

            if (file == null || file.Length == 0)
            {
                return BadRequest("No file provided or the file is empty.");
            }

            try
            {
                var imageUrl = await _recipeService.AddRecipePhoto(recipeId, file);
                return Ok(new { ImageUrl = imageUrl });
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest(ex.Message);
            }
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
        [HttpGet("photo")]
        [AllowAnonymous]
        public ActionResult<IEnumerable<RecipeWithPhotoDto>> GetAllWithPhoto([FromQuery] RecipeQuery query)
        {
            var validation = new RecipeQueryValidator().Validate(query);
            if (!validation.IsValid)
            {
                return BadRequest(validation.Errors);
            }
            var recipes = _recipeService.GetAllWithPhoto(query);
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
            var userId = User.FindFirst(c => c.Type == ClaimTypes.NameIdentifier).Value;

            var recipes = _recipeService.GetUserRecipes(userId);

            return Ok(recipes);
        }
        [HttpGet("category")]
        [AllowAnonymous]
        public ActionResult<IEnumerable<RecipeWithPhotoDto>> GetRecipesByCategory([FromQuery] string name)
        {
            var recipes = _recipeService.GetRecipesByCategory(name);

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
            recipeDto.CreatedById = User.FindFirst(c => c.Type == ClaimTypes.NameIdentifier).Value;
            var id = _recipeService.Create(recipeDto);
            recipeDto.RecipeId = id;
            return Created($"/api/recipe/{id}", recipeDto);
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
        [HttpGet("image")]
        [AllowAnonymous]
        public ActionResult<IEnumerable<RecipeWithPhotoDto>> GetNameAndIMGRecipe([FromQuery] RecipeQuery query)
        {
            var validation = new RecipeQueryValidator().Validate(query);
            if (!validation.IsValid)
            {
                return BadRequest(validation.Errors);
            }
            var recipes = _recipeService.GetNameAndIMGRecipe(query);
            return Ok(recipes);
        }



    }
}
