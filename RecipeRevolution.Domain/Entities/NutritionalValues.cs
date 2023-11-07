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
        public double Calories { get; set; }
        public double Protein { get; set; }
        public double Carbohydrates { get; set; }
        public double Fat { get; set; }

        public int RecipeId { get; set; }
        public Recipe Recipe { get; set; }
    }
}
