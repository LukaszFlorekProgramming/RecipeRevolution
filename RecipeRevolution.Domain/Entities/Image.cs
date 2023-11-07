using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeRevolution.Domain.Entities
{
    public class Image
    {
        public int ImageId { get; set; }
        public string Url { get; set; }

        public int RecipeId { get; set; }
        public Recipe Recipe { get; set; }
    }
}
