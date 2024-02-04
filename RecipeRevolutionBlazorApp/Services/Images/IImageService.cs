using RecipeRevolutionBlazorApp.Models.Image;

namespace RecipeRevolutionBlazorApp.Services.Images
{
    public interface IImageService
    {
        Task<ImageDto> GetById(int id);
        Task<ImageDto> GetByRecipeId(int id);
        Task Create(ImageDto imageDto);
    }
}
