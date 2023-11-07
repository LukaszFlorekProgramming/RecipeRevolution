using Microsoft.EntityFrameworkCore;
using RecipeRevolution.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeRevolution.Application.Interfaces
{
    public interface IRecipeRevolutionDbContext
    {
        public DbSet<Recipe> Recipes { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Ingredient> Ingredients { get; set; }
        public DbSet<NutritionalValues> NutritionalValues { get; set; }
        public DbSet<Image> Images { get; set; }
    }
}
