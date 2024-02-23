using RecipeRevolution.Domain.Models;
using RecipeRevolution.Domain.Models.Comment;

namespace RecipeRevolution.Application.Interfaces
{
    public interface ICommentService
    {
        CommentDto GetById(int id);
        IEnumerable<CommentDto> GetAll();
        IEnumerable<CommentUserDto> GetUserComments(string id);
        IEnumerable<DisplayCommentDto> GetRecipeComments(int id);
        int Create(CreateCommentDto commentDto);
        bool Delete(int id);
        bool Update(UpdateCommentDto updateCommentDto, int id);
    }
}
