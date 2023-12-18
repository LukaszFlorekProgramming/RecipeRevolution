using System;

namespace RecipeRevolutionBlazor.Models
{
    public class RecipeWithPhotoDto
    {
        public int RecipeId { get; set; }
        public string Name { get; set; }
        public byte[] Data { get; set; }
    }
}
