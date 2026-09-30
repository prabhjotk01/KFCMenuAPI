using KFCMenuAPI.BLL.DTOs;
using KFCMenuAPI.BLL.Services;
using Microsoft.AspNetCore.Mvc;

namespace KFCMenuAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InventoryController : ControllerBase
    {
        private readonly IInventoryService _service;

        public InventoryController(IInventoryService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var inventories = await _service.GetAllAsync();

            return Ok(inventories);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var inventory = await _service.GetByIdAsync(id);

            if (inventory == null)
            {
                return NotFound();
            }

            return Ok(inventory);
        }

        [HttpPost]
        public async Task<IActionResult> Add(InventoryDTO inventoryDTO)
        {
            await _service.AddAsync(inventoryDTO);

            return Ok(inventoryDTO);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, InventoryDTO inventoryDTO)
        {
            if (id != inventoryDTO.InventoryId)
            {
                return BadRequest();
            }

            await _service.UpdateAsync(inventoryDTO);

            return Ok(inventoryDTO);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _service.DeleteAsync(id);

            return Ok();
        }
    }
}