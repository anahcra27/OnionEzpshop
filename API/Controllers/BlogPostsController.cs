
using Application.Interfaces.Services;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlogPostController : ControllerBase
    {
        private readonly IBlogPostService _service;

        public BlogPostController(IBlogPostService service)
        {
            _service = service;
        }

        // GET: api/BlogPost
        // Everyone can view blog posts
        [AllowAnonymous]
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var posts = await _service.GetAllAsync();
            return Ok(posts);
        }

        // GET: api/BlogPost/1
        // Everyone can view a particular blog post
        [AllowAnonymous]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var post = await _service.GetByIdAsync(id);

            if (post == null)
                return NotFound();

            return Ok(post);
        }

        // POST: api/BlogPost
        // Only Admin can add blog posts
        [Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task<IActionResult> Add(BlogPost blogPost)
        {
            var result = await _service.AddAsync(blogPost);
            return Ok(result);
        }

        // PUT: api/BlogPost/1
        // Only Admin can update blog posts
        [Authorize(Roles = "Admin")]
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, BlogPost blogPost)
        {
            if (id != blogPost.Id)
                return BadRequest("ID mismatch.");

            var result = await _service.UpdateAsync(blogPost);

            if (!result)
                return NotFound();

            return Ok("Blog post updated successfully.");
        }

        // DELETE: api/BlogPost/1
        // Only Admin can delete blog posts
        [Authorize(Roles = "Admin")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _service.DeleteAsync(id);

            if (!result)
                return NotFound();

            return Ok("Blog post deleted successfully.");
        }
    }
}
