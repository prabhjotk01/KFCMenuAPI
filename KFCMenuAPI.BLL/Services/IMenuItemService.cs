using KFCMenuAPI.BLL.DTOs;

namespace KFCMenuAPI.BLL.Services
{
    public interface IMenuItemService
    {
        Task<List<MenuItemDTO>> GetAllAsync();
        Task<MenuItemDTO> GetByIdAsync(int id);
        Task<MenuItemDTO> GetWithIngredientsAsync(int id);
        Task AddAsync(MenuItemDTO menuItemDTO);
        Task UpdateAsync(MenuItemDTO menuItemDTO);
        Task DeleteAsync(int id);
    }
}