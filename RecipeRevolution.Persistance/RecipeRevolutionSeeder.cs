using Microsoft.EntityFrameworkCore;
using RecipeRevolution.Domain.Entities;

namespace RecipeRevolution.Persistance
{
    public class RecipeRevolutionSeeder
    {
        private readonly RecipeRevolutionDbContext _dbContext;
        public RecipeRevolutionSeeder(RecipeRevolutionDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void SeedMigration()
        {
            if (_dbContext.Database.CanConnect())
            {
                var pendingMigration = _dbContext.Database.GetPendingMigrations();
                if (pendingMigration != null && pendingMigration.Any())
                {
                    _dbContext.Database.Migrate();
                }   
                SeedCategories();
                
            }
        }
        private void SeedCategories()
        {
            if (!_dbContext.Categories.Any()) 
            {
                
                _dbContext.Categories.Add(new Category { Name = "Śniadania" });
                _dbContext.Categories.Add(new Category { Name = "Przekąski" });
                _dbContext.Categories.Add(new Category { Name = "Zupy i dania zupowe" });
                _dbContext.Categories.Add(new Category { Name = "Sałatki" });
                _dbContext.Categories.Add(new Category { Name = "Dania główne" });
                _dbContext.Categories.Add(new Category { Name = "Desery" });
                _dbContext.Categories.Add(new Category { Name = "Dania wegetariańskie" });
                _dbContext.Categories.Add(new Category { Name = "Dania wegańskie" });
                _dbContext.Categories.Add(new Category { Name = "Dania kuchni świata" });
                _dbContext.Categories.Add(new Category { Name = "Dania na grillu" });
                _dbContext.Categories.Add(new Category { Name = "Pieczenie i cukiernictwo" });


                _dbContext.SaveChanges();
            }
        }
    }
}
