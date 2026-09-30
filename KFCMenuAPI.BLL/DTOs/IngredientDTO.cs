using System.ComponentModel.DataAnnotations;

namespace KFCMenuAPI.BLL.DTOs
{
    public class IngredientDTO
    {
        public int IngredientId { get; set; }

        [Required]
        public string Name { get; set; }
    }
}