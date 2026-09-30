using KFCMenuAPI.BLL.DTOs;
using KFCMenuAPI.BLL.Services;
using Microsoft.AspNetCore.Mvc;

namespace KFCMenuAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _service;

        public CategoryController(ICategoryService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var categories = await _service.GetAllAsync();

            return Ok(categories);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var category = await _service.GetByIdAsync(id);

            if (category == null)
            {
                return NotFound();
            }

            return Ok(category);
        }

        [HttpPost]
        public async Task<IActionResult> Add(CategoryDTO categoryDTO)
        {
            await _service.AddAsync(categoryDTO);

            return Ok(categoryDTO);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, CategoryDTO categoryDTO)
        {
            if (id != categoryDTO.CategoryId)
            {
                return BadRequest();
            }

            await _service.UpdateAsync(categoryDTO);

            return Ok(categoryDTO);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _service.DeleteAsync(id);

            return Ok();
        }
    }
}