using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KFCMenuAPI.BLL.DTOs
{
    public class InventoryDTO
    {
        public int InventoryId { get; set; }

        public int IngredientId { get; set; }

        public int Quantity { get; set; }

        public int ReorderLevel { get; set; }
    }
}
