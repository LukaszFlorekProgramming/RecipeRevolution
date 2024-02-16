using RecipeRevolutionBlazorApp.Models.Comment;

namespace RecipeRevolutionBlazorApp.Services.Comments
{
    public interface ICommentService
    {
        Task<List<CommentDto>> GetComments();
        Task<List<CommentUserDto>> GetUserComments();
        Task<List<DisplayCommentDto>> GetRecipeComments(int id);
        Task<CommentDto> GetComment(int commentId);
        Task<CommentDto> CreateComment(CommentDto commentDto);
        Task<bool> UpdateComment(UpdateCommentDto updateCommentDto, int commentId);
        Task<bool> DeleteComment(int commentId);
    }
}
