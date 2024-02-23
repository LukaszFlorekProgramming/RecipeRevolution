﻿using Microsoft.Extensions.DependencyInjection;
using RecipeRevolution.Application.Interfaces;
using RecipeRevolution.Infrastructure.Services;

namespace RecipeRevolution.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services)
        {
            services.AddTransient<IDateTimeService, DateTimeService>();
            return services;
        }
    }
}
