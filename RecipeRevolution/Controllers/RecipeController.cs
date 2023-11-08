using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using RecipeRevolution.Domain.Entities;
using RecipeRevolution.Models;
using RecipeRevolution.Persistance;

namespace RecipeRevolution.Controllers
{
    [Route("api/recipe")]
    public class RecipeController : ControllerBase
    {
        private readonly RecipeRevolutionDbContext _dbcontext;
        private readonly IMapper _mapper;

        public RecipeController(RecipeRevolutionDbContext dbContext, IMapper mapper)
        {
            _dbcontext = dbContext;
            _mapper = mapper;

        }
        [HttpGet]
        public ActionResult<IEnumerable<RecipeDto>> GetAll() 
        {
            var recipes = _dbcontext
                .Recipes
                .ToList();
            var recipesDtos = _mapper.Map<List<RecipeDto>>(recipes);
            return Ok(recipesDtos);
        }
        [HttpGet("{id}")]
        public ActionResult<Recipe> Get([FromRoute] int id)
        {
            var recipe = _dbcontext
                .Recipes
                .FirstOrDefault(r => r.RecipeId == id);

            if (recipe == null)
            { 
                return NotFound();
            }

            var recipeDto = _mapper.Map<RecipeDto>(recipe);
            return Ok(recipeDto);
        }

    }
}
