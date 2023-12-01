using RecipeRevolutionBlazor.Models;

namespace RecipeRevolutionBlazor.Services.Images
{
    public interface IImageService
    {
         Task<ImageDto> GetById(int id);
         Task Create(ImageDto imageDto);
    }
}
