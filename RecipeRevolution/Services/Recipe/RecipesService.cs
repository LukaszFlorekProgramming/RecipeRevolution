using AutoMapper;
using RecipeRevolution.Application.Interfaces;
using RecipeRevolution.Models;
using RecipeRevolution.Persistance;

namespace RecipeRevolution.Services.Recipe
{
    public class RecipesService : IRecipesService
    {
        private readonly RecipeRevolutionDbContext _dbcontext;
        private readonly IMapper _mapper;
        public RecipesService(RecipeRevolutionDbContext dbContext, IMapper mapper)
        {
            _dbcontext = dbContext;
            _mapper = mapper;

        }
        public IEnumerable<RecipeDto> GetAll()
        {
            var recipes = _dbcontext
                .Recipes
                .ToList();
            var recipesDtos = _mapper.Map<List<RecipeDto>>(recipes);

            return recipesDtos;
        }
    }
}
