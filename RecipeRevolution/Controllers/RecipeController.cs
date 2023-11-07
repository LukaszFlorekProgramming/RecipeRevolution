using Microsoft.AspNetCore.Mvc;
using RecipeRevolution.Domain.Entities;
using RecipeRevolution.Persistance;

namespace RecipeRevolution.Controllers
{
    [Route("api/recipe")]
    public class RecipeController : ControllerBase
    {
        private readonly RecipeRevolutionDbContext _dbcontext;

        public RecipeController(RecipeRevolutionDbContext dbContext)
        {
            _dbcontext = dbContext;
        }
        [HttpGet]
        public ActionResult<IEnumerable<Recipe>> GetAll() 
        {
            var recipes = _dbcontext.Recipes.ToList();
            return Ok(recipes);
        }
    }
}
