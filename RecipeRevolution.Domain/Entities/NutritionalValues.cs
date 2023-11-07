using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeRevolution.Domain.Entities
{
    public class NutritionalValues
    {
        public int NutritionalValuesId { get; set; }
        public decimal Calories { get; set; }
        public decimal Protein { get; set; }
        public decimal Carbohydrates { get; set; }
        public decimal Fat { get; set; }

        public int RecipeId { get; set; }
        public Recipe Recipe { get; set; }
    }
}
