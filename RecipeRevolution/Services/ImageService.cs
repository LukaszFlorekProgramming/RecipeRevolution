using AutoMapper;
using RecipeRevolution.Application.Interfaces;
using RecipeRevolution.Domain.Entities;
using RecipeRevolution.Domain.Models;
using RecipeRevolution.Persistance;

namespace RecipeRevolution.Services
{
    public class ImageService : IImageService
    {
        private readonly RecipeRevolutionDbContext _dbcontext;
        private readonly IMapper _mapper;
        public ImageService(RecipeRevolutionDbContext dbContext, IMapper mapper)
        {
            _dbcontext = dbContext;
            _mapper = mapper;
        }

        public ImageDto GetById(int id)
        {
            var image = _dbcontext.Images.FirstOrDefault(x => x.ImageId == id);
            if (image == null) return null;
            var result = _mapper.Map<ImageDto>(image);
            return result;
        }

        public ImageDto GetByRecipeId(int id)
        {
            var image = _dbcontext.Images.FirstOrDefault(x => x.RecipeId == id);
            if (image == null) return null;
            var result = _mapper.Map<ImageDto>(image);
            return result;
        }
        public int Create(ImageDto imageDto)
        {
            var image = _mapper.Map<Image>(imageDto);
            _dbcontext.Images.Add(image);
            _dbcontext.SaveChanges();
            return image.ImageId;
        }

        public IEnumerable<ImageDto> GetAll()
        {
            var images = _dbcontext
                .Images
                .ToList();
            var recipesDtos = _mapper.Map<List<ImageDto>>(images);
            return recipesDtos;
        }
    }
}
