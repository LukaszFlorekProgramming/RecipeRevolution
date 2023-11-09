using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using RecipeRevolution.Application.Interfaces;
using RecipeRevolution.Authorization;
using RecipeRevolution.Domain.Entities;
using RecipeRevolution.Domain.Models;
using RecipeRevolution.Models;
using RecipeRevolution.Persistance;
using System.Security.Claims;

namespace RecipeRevolution.Services
{
    public class RecipeService : IRecipeService
    {
        private readonly RecipeRevolutionDbContext _dbcontext;
        private readonly IMapper _mapper;
        private readonly IAuthorizationService _authorizationService;
        private readonly IUserContextService _userContextService;
        public RecipeService(RecipeRevolutionDbContext dbContext, IMapper mapper, IAuthorizationService authorizationService, IUserContextService userContextService)
        {
            _dbcontext = dbContext;
            _mapper = mapper;
            _authorizationService = authorizationService;
            _userContextService = userContextService;
        }
        public RecipeDto GetById(int id)
        {
            var recipe = _dbcontext
                .Recipes
                .FirstOrDefault(r => r.RecipeId == id);
            if(recipe == null) return null;
            var result = _mapper.Map<RecipeDto>(recipe);
            return result;
        }
        public IEnumerable<RecipeDto> GetAll()
        {
            var recipes = _dbcontext
                .Recipes
                .ToList();
            var recipesDtos = _mapper.Map<List<RecipeDto>>(recipes);

            return recipesDtos;
        }
        public int Create(CreateRecipeDto recipeDto)
        {
            var recipe = _mapper.Map<Recipe>(recipeDto);
            recipe.CreatedById = _userContextService.GetUserId;
            _dbcontext.Recipes.Add(recipe);
            _dbcontext.SaveChanges();
            return recipe.RecipeId;
        }

        public bool Delete(int id)
        {
            var recipe = _dbcontext
                .Recipes
                .FirstOrDefault(r => r.RecipeId == id);
            if(recipe is null) return false;

            var authorizationResult = _authorizationService.AuthorizeAsync(_userContextService.User, recipe, new ResourceOperationRequirement(ResourseOperation.Update)).Result;

            if (!authorizationResult.Succeeded)
            {
                return false;
            }
            _dbcontext.Recipes.Remove(recipe);
            _dbcontext.SaveChanges();
            return true;
        }

        public bool Update(UpdateRecipeDto recipeDto, int id)
        {
            var recipe = _dbcontext
               .Recipes
               .FirstOrDefault(r => r.RecipeId == id);
            if(recipe is null) return false;

            var authorizationResult = _authorizationService.AuthorizeAsync(_userContextService.User, recipe, new ResourceOperationRequirement(ResourseOperation.Update)).Result;

            if (!authorizationResult.Succeeded)
            { 
                return false;
            }
            

            recipe.Name = recipeDto.Name;
            recipe.Description = recipeDto.Description;
            recipe.Instructions = recipeDto.Instructions;
            recipe.PreparationTime = recipeDto.PreparationTime;
            recipe.DifficultyLevel = recipeDto.DifficultyLevel;
            recipe.Portions = recipeDto.Portions;
            recipe.CategoryId = recipeDto.CategoryId;

            _dbcontext.SaveChanges();
            return true;

        }
    }
}
