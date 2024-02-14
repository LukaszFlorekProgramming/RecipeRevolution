using RecipeRevolution.Domain.Models;

namespace RecipeRevolution.Application.Interfaces
{
    public interface ICommentService
    {
        CommentDto GetById(int id);
        IEnumerable<CommentDto> GetAll();
        IEnumerable<CommentDto> GetUserComments(string id);
        IEnumerable<DisplayCommentDto> GetRecipeComments(int id);
        int Create(CreateCommentDto commentDto);
        bool Delete(int id);
        bool Update(UpdateCommentDto updateCommentDto, int id);
    }
}
