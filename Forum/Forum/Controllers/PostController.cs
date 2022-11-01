using Forum.Models.PostModels;
using Forum.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Forum.Controllers
{
    [Route("api/posts")]
    [ApiController]
    [Authorize]
    public class PostController : ControllerBase
    {
        private readonly IPostService _service;

        public PostController(IPostService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ShortPostDto>>> GetAll()
        {
          var posts = await _service.GetAll();

            return Ok(posts);
        }

        [HttpPost]
        public async Task<ActionResult> CreatePost(CreateUpdatePostDto dto)
        {
            int id = await _service.CreatePost(dto);

            return Created($"/api/posts/{id}", null);
        }
    }
}
