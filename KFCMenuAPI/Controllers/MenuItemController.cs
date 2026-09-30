using KFCMenuAPI.BLL.DTOs;
using KFCMenuAPI.BLL.Services;
using Microsoft.AspNetCore.Mvc;

namespace KFCMenuAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MenuItemController : ControllerBase
    {
        private readonly IMenuItemService _service;

        public MenuItemController(IMenuItemService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var menuItems = await _service.GetAllAsync();
                return Ok(menuItems);
            }
            catch (Exception)
            {
                return StatusCode(500, "An error occurred while getting menu items.");
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                var menuItem = await _service.GetByIdAsync(id);

                if (menuItem == null)
                {
                    return NotFound();
                }

                return Ok(menuItem);
            }
            catch (Exception)
            {
                return StatusCode(500, "An error occurred while getting the menu item.");
            }
        }

        [HttpGet("{id}/ingredients")]
        public async Task<IActionResult> GetWithIngredients(int id)
        {
            try
            {
                var menuItem = await _service.GetWithIngredientsAsync(id);

                if (menuItem == null)
                {
                    return NotFound();
                }

                return Ok(menuItem);
            }
            catch (Exception)
            {
                return StatusCode(500, "An error occurred while getting the menu item ingredients.");
            }
        }

        [HttpPost]
        public async Task<IActionResult> Add(MenuItemDTO menuItemDTO)
        {
            try
            {
                await _service.AddAsync(menuItemDTO);
                return Ok(menuItemDTO);
            }
            catch (Exception)
            {
                return StatusCode(500, "An error occurred while adding the menu item.");
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, MenuItemDTO menuItemDTO)
        {
            try
            {
                if (id != menuItemDTO.MenuItemId)
                {
                    return BadRequest();
                }

                await _service.UpdateAsync(menuItemDTO);
                return Ok(menuItemDTO);
            }
            catch (Exception)
            {
                return StatusCode(500, "An error occurred while updating the menu item.");
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await _service.DeleteAsync(id);
                return Ok();
            }
            catch (Exception)
            {
                return StatusCode(500, "An error occurred while deleting the menu item.");
            }
        }
    }
}