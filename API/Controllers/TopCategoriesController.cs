using Application.Interfaces.Services;
    using Domain.Entities;
    using Microsoft.AspNetCore.Mvc;

    namespace API.Controllers
    {
        [Route("api/[controller]")]
        [ApiController]
        public class TopCategoriesController : ControllerBase
        {
            private readonly ITopCategoryService _service;

            public TopCategoriesController(ITopCategoryService service)
            {
                _service = service;
            }

            // GET: api/TopCategories
            [HttpGet]
            public async Task<IActionResult> GetAll()
            {
                var categories = await _service.GetAllAsync();
                return Ok(categories);
            }

            // GET: api/TopCategories/5
            [HttpGet("{id}")]
            public async Task<IActionResult> GetById(int id)
            {
                var category = await _service.GetByIdAsync(id);

                if (category == null)
                    return NotFound();

                return Ok(category);
            }

            // POST: api/TopCategories
            [HttpPost]
            public async Task<IActionResult> Add(TopCategory category)
            {
                var result = await _service.AddAsync(category);

                return Ok(result);
            }

        // PUT: api/TopCategories
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, TopCategory category)
        {
            if (id != category.Id)
                return BadRequest("ID mismatch");

            var result = await _service.UpdateAsync(category);

            if (!result)
                return NotFound();

            return Ok("Category updated successfully");
        }

        // DELETE: api/TopCategories/5
        [HttpDelete("{id}")]
            public async Task<IActionResult> Delete(int id)
            {
                var result = await _service.DeleteAsync(id);

                if (!result)
                    return NotFound();

                return Ok("Category deleted successfully");
            }
        }
    }


