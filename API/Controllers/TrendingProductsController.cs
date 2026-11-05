
using Application.Interfaces.Services;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TrendingProductsController : ControllerBase
    {
        private readonly ITrendingProductService _service;

        public TrendingProductsController(
            ITrendingProductService service)
        {
            _service = service;
        }

        // GET: api/TrendingProducts
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var products = await _service.GetAllAsync();
            return Ok(products);
        }

        // GET: api/TrendingProducts/1
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var product = await _service.GetByIdAsync(id);

            if (product == null)
                return NotFound();

            return Ok(product);
        }

        // POST: api/TrendingProducts
        [HttpPost]
        public async Task<IActionResult> Add(TrendingProduct product)
        {
            var result = await _service.AddAsync(product);

            return Ok(result);
        }

        // PUT: api/TrendingProducts
        [HttpPut]
        public async Task<IActionResult> Update(TrendingProduct product)
        {
            var result = await _service.UpdateAsync(product);

            if (!result)
                return NotFound();

            return Ok("Trending product updated successfully");
        }

        // DELETE: api/TrendingProducts/1
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _service.DeleteAsync(id);

            if (!result)
                return NotFound();

            return Ok("Trending product deleted successfully");
        }
    }
}
