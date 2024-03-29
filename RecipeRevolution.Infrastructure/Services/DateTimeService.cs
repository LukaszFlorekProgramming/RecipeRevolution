﻿using RecipeRevolution.Application.Interfaces;

namespace RecipeRevolution.Infrastructure.Services
{
    public class DateTimeService : IDateTimeService
    {
        public DateTime Now => DateTime.Now;
    }
}
