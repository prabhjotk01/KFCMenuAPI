using KFCMenuAPI.BLL.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KFCMenuAPI.BLL.Services
{
    public interface IInventoryService
    {
        Task<List<InventoryDTO>> GetAllAsync();
        Task<InventoryDTO> GetByIdAsync(int id);
        Task AddAsync(InventoryDTO inventoryDTO);
        Task UpdateAsync(InventoryDTO inventoryDTO);
        Task DeleteAsync(int id);
    }
}
