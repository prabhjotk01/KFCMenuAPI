using System.ComponentModel.DataAnnotations;

namespace KFCMenuAPI.BLL.DTOs
{
    public class MenuItemDTO
    {
        public int MenuItemId { get; set; }

        [Required]
        public string Name { get; set; }

        [Range(0.01, 1000)]
        public decimal Price { get; set; }

        [Required]
        public string Description { get; set; }

        [Range(1, int.MaxValue)]
        public int CategoryId { get; set; }

        public List<IngredientDTO> Ingredients { get; set; }
        public List<int> IngredientIds { get; set; }
    }
}