using Microsoft.EntityFrameworkCore;
using RecipeRevolution.Application.Interfaces;
using RecipeRevolution.Domain.Entities;
using RecipeRevolution.Persistance.Migrations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeRevolution.Persistance
{
    public class RecipeRevolutionDbContext : DbContext, IRecipeRevolutionDbContext
    {
        public RecipeRevolutionDbContext(DbContextOptions<RecipeRevolutionDbContext> options) : base(options)
        {
            
        }

        public DbSet<Recipe> Recipes { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Ingredient> Ingredients { get; set;}
        public DbSet<NutritionalValues> NutritionalValues { get; set;}
        public DbSet<Image> Images { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.SeedData();
        }
    }
}
