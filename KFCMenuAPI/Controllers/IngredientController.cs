using KFCMenuAPI.BLL.DTOs;
using KFCMenuAPI.BLL.Services;
using Microsoft.AspNetCore.Mvc;

namespace KFCMenuAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IngredientController : ControllerBase
    {
        private readonly IIngredientService _service;

        public IngredientController(IIngredientService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var ingredients = await _service.GetAllAsync();

            return Ok(ingredients);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var ingredient = await _service.GetByIdAsync(id);

            if (ingredient == null)
            {
                return NotFound();
            }

            return Ok(ingredient);
        }

        [HttpPost]
        public async Task<IActionResult> Add(IngredientDTO ingredientDTO)
        {
            await _service.AddAsync(ingredientDTO);

            return Ok(ingredientDTO);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, IngredientDTO ingredientDTO)
        {
            if (id != ingredientDTO.IngredientId)
            {
                return BadRequest();
            }

            await _service.UpdateAsync(ingredientDTO);

            return Ok(ingredientDTO);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _service.DeleteAsync(id);

            return Ok();
        }
    }
}