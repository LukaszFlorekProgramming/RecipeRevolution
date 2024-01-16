using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            }
        }
    }
}
