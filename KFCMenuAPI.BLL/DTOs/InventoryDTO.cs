using System.ComponentModel.DataAnnotations;

namespace KFCMenuAPI.BLL.DTOs
{
    public class InventoryDTO
    {
        public int InventoryId { get; set; }

        [Range(1, int.MaxValue)]
        public int IngredientId { get; set; }

        [Range(0, int.MaxValue)]
        public int Quantity { get; set; }

        [Range(0, int.MaxValue)]
        public int ReorderLevel { get; set; }
    }
}