using AutoMapper;
using Microsoft.EntityFrameworkCore;
using RecipeRevolution.Application.Interfaces;
using RecipeRevolution.Domain.Models;
using RecipeRevolution.Models;
using RecipeRevolution.Persistance;
using RecipeRevolution.Domain.Entities;
using RecipeRevolution.Services.Blob;

namespace RecipeRevolution.Services
{
    public class RecipeService : IRecipeService
    {
        private readonly RecipeRevolutionDbContext _dbcontext;
        private readonly IMapper _mapper;
        private readonly IBlobService _blobService;
        public RecipeService(RecipeRevolutionDbContext dbContext, IMapper mapper, IBlobService blobService)
        {
            _dbcontext = dbContext;
            _mapper = mapper;
            _blobService = blobService;
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
        public PagedResult<RecipeDto> GetAll(RecipeQuery query)
        {
            var baseQuery = _dbcontext.Recipes.AsQueryable();

            if (query.SearchPhrase != "all")
            {
                baseQuery = baseQuery
                    .Where(r => r.Name.ToLower().Contains(query.SearchPhrase.ToLower()) ||
                                r.Description.ToLower().Contains(query.SearchPhrase.ToLower()));
            }
            else
            {
                baseQuery = baseQuery.Where(r => true);
            }

            var recipes = baseQuery
                .Skip(query.PageSize * (query.PageNumber - 1))
                .Take(query.PageSize)
                .ToList();

            var totalItemsCount = baseQuery.Count();

            var recipesDtos = _mapper.Map<List<RecipeDto>>(recipes);

            var result = new PagedResult<RecipeDto>(recipesDtos, totalItemsCount, query.PageSize, query.PageNumber);

            return result;
        }
        public IEnumerable<MyRecipeDto> GetUserRecipes(string id)
        {
            var recipes = _dbcontext
                .Recipes.Where(x => x.CreatedById == id)
                .ToList();
            var recipesDtos = _mapper.Map<List<MyRecipeDto>>(recipes);

            return recipesDtos;
        }
        public IEnumerable<RecipeWithPhotoDto> GetRecipesByCategory(string name)
        {
            var recipes = _dbcontext.Recipes.Include(x => x.Images).Where(x => x.Category.Name == name).ToList();

            var recipesDtos = _mapper.Map<List<RecipeWithPhotoDto>>(recipes);

            return recipesDtos;
        }
        public int Create(CreateRecipeDto recipeDto)
        {
            var recipe = _mapper.Map<Domain.Entities.Recipe>(recipeDto);
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

        public IEnumerable<CategoryDto> GetAllCategory()
        {
            var categories = _dbcontext.Categories.ToList();
            var categoriesDtos = _mapper.Map<List<CategoryDto>>(categories);
            return categoriesDtos;
        }
        

        public PagedResult<RecipeWithPhotoDto> GetAllWithPhoto(RecipeQuery query)
        {
            var baseQuery = _dbcontext.Recipes.Include(x => x.Images).AsQueryable();

            if (query.SearchPhrase != "all")
            {
                baseQuery = baseQuery
                    .Where(r => r.Name.ToLower().Contains(query.SearchPhrase.ToLower()) ||
                                r.Description.ToLower().Contains(query.SearchPhrase.ToLower()));
            }
            else
            {
                baseQuery = baseQuery.Where(r => true);
            }

            var recipes = baseQuery
                .Skip(query.PageSize * (query.PageNumber - 1))
                .Take(query.PageSize)
                .ToList();

            var totalItemsCount = baseQuery.Count();

            var recipesDtos = _mapper.Map<List<RecipeWithPhotoDto>>(recipes);

            var result = new PagedResult<RecipeWithPhotoDto>(recipesDtos, totalItemsCount, query.PageSize, query.PageNumber);

            return result;
        }

        public async Task<string> AddRecipePhoto(int recipeId, IFormFile photo)
        {
            var recipe = _dbcontext.Recipes.FirstOrDefault(r => r.RecipeId == recipeId);
            if (recipe == null)
            {
                throw new InvalidOperationException("Recipe not found");
            }

            var fileName = $"{Guid.NewGuid()}-{photo.FileName}";
            var filePath = await _blobService.UploadFileAsync(photo.OpenReadStream(), fileName);

            if (!string.IsNullOrWhiteSpace(filePath))
            {
                recipe.MainImage = filePath;
                _dbcontext.SaveChanges();
                return filePath; 
            }
            else
            {
                throw new InvalidOperationException("Error uploading the photo to Azure Blob Storage.");
            }
        }
    }
}
