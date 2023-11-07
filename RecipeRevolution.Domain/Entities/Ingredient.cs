using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeRevolution.Domain.Entities
{
    public class Ingredient
    {
        public int IngredientId { get; set; }
        public string Name { get; set; }
        public double Quantity { get; set; }
        public string Unit { get; set; }

        public int RecipeId { get; set; }
        public Recipe Recipe { get; set; }
    }
}
