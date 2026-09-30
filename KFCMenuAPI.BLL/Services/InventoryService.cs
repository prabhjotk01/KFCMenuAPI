using KFCMenuAPI.BLL.DTOs;
using KFCMenuAPI.DAL.Repositories;
using KFCMenuAPI.Model;

namespace KFCMenuAPI.BLL.Services
{
    public class InventoryService : IInventoryService
    {
        private readonly IInventoryRepository _repository;

        public InventoryService(IInventoryRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<InventoryDTO>> GetAllAsync()
        {
            var inventories = await _repository.GetAllAsync();

            return inventories.Select(i => new InventoryDTO
            {
                InventoryId = i.InventoryId,
                IngredientId = i.IngredientId,
                Quantity = i.Quantity,
                ReorderLevel = i.ReorderLevel
            }).ToList();
        }

        public async Task<InventoryDTO> GetByIdAsync(int id)
        {
            var inventory = await _repository.GetByIdAsync(id);

            if (inventory == null)
            {
                return null;
            }

            return new InventoryDTO
            {
                InventoryId = inventory.InventoryId,
                IngredientId = inventory.IngredientId,
                Quantity = inventory.Quantity,
                ReorderLevel = inventory.ReorderLevel
            };
        }

        public async Task AddAsync(InventoryDTO inventoryDTO)
        {
            var inventory = new Inventory
            {
                IngredientId = inventoryDTO.IngredientId,
                Quantity = inventoryDTO.Quantity,
                ReorderLevel = inventoryDTO.ReorderLevel
            };

            await _repository.AddAsync(inventory);
        }

        public async Task UpdateAsync(InventoryDTO inventoryDTO)
        {
            var inventory = new Inventory
            {
                InventoryId = inventoryDTO.InventoryId,
                IngredientId = inventoryDTO.IngredientId,
                Quantity = inventoryDTO.Quantity,
                ReorderLevel = inventoryDTO.ReorderLevel
            };

            await _repository.UpdateAsync(inventory);
        }

        public async Task DeleteAsync(int id)
        {
            await _repository.DeleteAsync(id);
        }
    }
}