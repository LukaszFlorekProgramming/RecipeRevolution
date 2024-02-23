using RecipeRevolution.Domain.Models.Image;

namespace RecipeRevolution.Application.Interfaces
{
    public interface IImageService
    {
        public ImageDto GetById(int id);
        ImageDto GetByRecipeId(int id);
        public int Create(ImageDto imageDto);
        IEnumerable<ImageDto> GetAll();
    }
}
