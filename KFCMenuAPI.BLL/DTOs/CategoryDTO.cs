using System.ComponentModel.DataAnnotations;

namespace KFCMenuAPI.BLL.DTOs
{
    public class CategoryDTO
    {
        public int CategoryId { get; set; }

        [Required]
        public string Name { get; set; }
    }
}