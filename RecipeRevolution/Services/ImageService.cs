using AutoMapper;
using Microsoft.AspNetCore.Authorization;
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
        private readonly IAuthorizationService _authorizationService;
        private readonly IUserContextService _userContextService;
        public ImageService(RecipeRevolutionDbContext dbContext, IMapper mapper, IAuthorizationService authorizationService, IUserContextService userContextService)
        {
            _dbcontext = dbContext;
            _mapper = mapper;
            _authorizationService = authorizationService;
            _userContextService = userContextService;
        }

        public ImageDto GetById(int id)
        {
            var image = _dbcontext.Images.FirstOrDefault(x => x.ImageId == id);
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
    }
}
