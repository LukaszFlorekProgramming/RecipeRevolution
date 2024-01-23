using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using RecipeRevolution.Application.Interfaces;

namespace RecipeRevolution.Persistance
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddPersistance(this IServiceCollection services)
        {
            services.TryAddTransient<RecipeRevolutionSeeder>();
            services.AddScoped<IRecipeRevolutionDbContext, RecipeRevolutionDbContext>();
            return services;
        }
    }
}
