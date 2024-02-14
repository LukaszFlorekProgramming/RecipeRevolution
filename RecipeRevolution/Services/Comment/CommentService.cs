using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RecipeRevolution.Application.Interfaces;
using RecipeRevolution.Domain.Models;
using RecipeRevolution.Persistance;

namespace RecipeRevolution.Services.Comment
{
    public class CommentService : ICommentService
    {
        private readonly RecipeRevolutionDbContext _dbcontext;
        private readonly IMapper _mapper;
        public CommentService(RecipeRevolutionDbContext dbContext, IMapper mapper)
        {
            _dbcontext = dbContext;
            _mapper = mapper;
        }
        public int Create(CreateCommentDto commentDto)
        {
            var comment = _mapper.Map<Domain.Entities.Comment>(commentDto);
            _dbcontext.Comments.Add(comment);
            _dbcontext.SaveChanges();
            return comment.CommentId;
        }

        public bool Delete(int id)
        {
            var comment = _dbcontext
               .Comments
               .FirstOrDefault(r => r.CommentId == id);
            if (comment is null) return false;

            _dbcontext.Comments.Remove(comment);
            _dbcontext.SaveChanges();
            return true;
        }

        public bool Update(UpdateCommentDto updateCommentDto, int id)
        {
            var comment = _dbcontext
               .Comments
               .FirstOrDefault(r => r.CommentId == id);
            if (comment is null) return false;

            comment.Text = updateCommentDto.Text;
            comment.CreatedAt = updateCommentDto.CreatedAt;

            _dbcontext.SaveChanges();
            return true;
        }

        public IEnumerable<CommentDto> GetAll()
        {
            var comments = _dbcontext
                .Comments
                .ToList();
            var commentsDtos = _mapper.Map<List<CommentDto>>(comments);

            return commentsDtos;
        }

        public CommentDto GetById(int id)
        {
            var comment = _dbcontext
                .Comments
                .FirstOrDefault(r => r.CommentId == id);
            if (comment == null) return null;
            var result = _mapper.Map<CommentDto>(comment);
            return result;
        }

        public IEnumerable<DisplayCommentDto> GetRecipeComments([FromQuery]int id)
        {
            var comments = _dbcontext
               .Comments.Where(x => x.RecipeId == id)
               .Include(c => c.CreatedBy)
               .Select(c => new DisplayCommentDto
               {
                   Text = c.Text,
                   CreatedAt = c.CreatedAt,
                   FirstName = c.CreatedBy.FirstName,
                   LastName = c.CreatedBy.LastName
               })
               .ToList();
            var commentsDtos = _mapper.Map<List<DisplayCommentDto>>(comments);

            return commentsDtos;
        }

        public IEnumerable<CommentDto> GetUserComments(string id)
        {
            var comments = _dbcontext
                .Comments.Where(x => x.CreatedById == id)
                .ToList();
            var commentsDtos = _mapper.Map<List<CommentDto>>(comments);

            return commentsDtos;
        }

    }
}
