using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeRevolution.Domain.Models
{
    public class CreateRecipeDto
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Instructions { get; set; }
        public int PreparationTime { get; set; }
        public string DifficultyLevel { get; set; }
        public short Portions { get; set; }

        public int CategoryId { get; set; }
    }
}
