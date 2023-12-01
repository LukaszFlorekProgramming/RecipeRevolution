using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RecipeRevolution.Application.Interfaces;
using RecipeRevolution.Domain.Entities;
using RecipeRevolution.Domain.Models;

namespace RecipeRevolution.Controllers
{
    [Route("api/image")]
    [ApiController]
    [Authorize]
    public class ImageController : ControllerBase
    {
        private readonly IImageService _imageService;

        public ImageController(IImageService imageService)
        {
            _imageService = imageService;
        }
        [HttpGet("{id}")]
        [AllowAnonymous]
        public ActionResult<Image> Get([FromRoute] int id)
        {
            var image = _imageService.GetById(id);

            if (image == null)
            {
                return NotFound();
            }
            return Ok();
        }
        [HttpPost]
        public ActionResult CreateImage([FromBody] ImageDto imageDto)
        {
            var id = _imageService.Create(imageDto);

            return Created($"/api/image/{id}",null);
        }

    }
}
