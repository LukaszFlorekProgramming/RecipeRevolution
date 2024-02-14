using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using RecipeRevolution.Application.Interfaces;
using RecipeRevolution.Domain.Entities;
using RecipeRevolution.Persistance.Migrations;
using System.Reflection;

namespace RecipeRevolution.Persistance
{
    public class RecipeRevolutionDbContext : IdentityDbContext<User>, IRecipeRevolutionDbContext
    {
        public RecipeRevolutionDbContext(DbContextOptions<RecipeRevolutionDbContext> options) : base(options){ }

        public DbSet<Recipe> Recipes { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Ingredient> Ingredients { get; set;}
        public DbSet<NutritionalValues> NutritionalValues { get; set;}
        public DbSet<Image> Images { get; set; }
        public DbSet<Comment> Comments { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            //modelBuilder.SeedData();
        }
    }
}
