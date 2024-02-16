using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using RecipeRevolution.Application.Interfaces;
using RecipeRevolution.Domain.Entities;
using RecipeRevolution.Domain.Models;
using System.Security.Claims;

namespace RecipeRevolution.Controllers
{
    [ApiController]
    [Route("api/comment")]
    [Authorize]
    public class CommentController : Controller
    {
        private readonly ICommentService _commentService;
        public CommentController(ICommentService commentService)
        {
            _commentService = commentService;
        }
        [HttpGet("{id}")]
        [AllowAnonymous]
        public ActionResult<Comment> Get([FromRoute] int id)
        {
            var comment = _commentService.GetById(id);

            if (comment == null)
            {
                return NotFound();
            }

            return Ok(comment);
        }
        [HttpGet]
        public ActionResult<IEnumerable<CommentDto>> GetAll()
        {
            var comments = _commentService.GetAll();
            return Ok(comments);
        }

        [HttpGet("user")]
        public ActionResult<IEnumerable<CommentDto>> GetUserComments()
        {
            var UserId = User.FindFirst(c => c.Type == ClaimTypes.NameIdentifier).Value;
            var comments = _commentService.GetUserComments(UserId);
            return Ok(comments);
        }

        [HttpGet("recipe")]
        [AllowAnonymous]
        public ActionResult<IEnumerable<CommentDto>> GetRecipeComments(int id)
        {
            var comments = _commentService.GetRecipeComments(id);
            return Ok(comments);
        }

        [HttpPost]
        public ActionResult CreateComment([FromBody] CreateCommentDto commentDto)
        {
            commentDto.CreatedById = User.FindFirst(c => c.Type == ClaimTypes.NameIdentifier).Value;
            commentDto.CreatedAt = DateTime.UtcNow;
            var id = _commentService.Create(commentDto);
            commentDto.CommentId = id;
            return Created($"/api/comment/{id}", commentDto);
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteComment([FromRoute] int id)
        {
            var isDeleted = _commentService.Delete(id);
            if (isDeleted)
            {
                return NoContent();
            }
            return NotFound();
        }
        [HttpPut("{id}")]
        public ActionResult UpdateComment([FromBody] UpdateCommentDto updateCommentDto, [FromRoute] int id)
        {
            updateCommentDto.CreatedAt = DateTime.UtcNow;
            var isUpdated = _commentService.Update(updateCommentDto, id);
            if (!isUpdated)
            {
                return NotFound();
            }
            return Ok();
        }
    }
}
