using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KFCMenuAPI.Model
{
    public class Ingredient
    {
        public int IngredientId { get; set; }

        public string Name { get; set; }

        public List<MenuItem> MenuItems { get; set; }

        public Inventory Inventory { get; set; }
    }
}
