using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KFCMenuAPI.Model
{
    public class Inventory
    {
        public int InventoryId { get; set; }

        public int IngredientId { get; set; }

        public int Quantity { get; set; }

        public int ReorderLevel { get; set; }

        public Ingredient Ingredient { get; set; }
    }
}
