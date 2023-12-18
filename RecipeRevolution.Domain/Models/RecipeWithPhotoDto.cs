using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeRevolution.Domain.Models
{
    public class RecipeWithPhotoDto
    {
        public int RecipeId { get; set; }
        public string Name { get; set; }
        public byte[] Data { get; set; }
    }
}
