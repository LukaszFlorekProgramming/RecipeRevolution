using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using RecipeRevolution.Application.Interfaces;
using RecipeRevolution.Domain.Models;
using RecipeRevolution.Models;
using RecipeRevolution.Persistance;

namespace RecipeRevolution.Services
{
    public class RecipesService : IRecipesService
    {
        private readonly RecipeRevolutionDbContext _dbcontext;
        private readonly IMapper _mapper;
        private readonly IAuthorizationService _authorizationService;
        private readonly IUserContextService _userContextService;
        public RecipesService(RecipeRevolutionDbContext dbContext, IMapper mapper, IAuthorizationService authorizationService, IUserContextService userContextService)
        {
            _dbcontext = dbContext;
            _mapper = mapper;
            _authorizationService = authorizationService;
            _userContextService = userContextService;
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
