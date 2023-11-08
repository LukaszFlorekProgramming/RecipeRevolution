﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RecipeRevolution.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeRevolution.Persistance.Configurations
{
    public class NutritionalValuesConfiguration : IEntityTypeConfiguration<NutritionalValues>
    {
        public void Configure(EntityTypeBuilder<NutritionalValues> builder)
        {
            builder.HasKey(x => x.NutritionalValuesId);
            builder.Property(x => x.Calories)
                .IsRequired();
            builder.Property(x => x.Protein)
                .IsRequired();
            builder.Property(x => x.Fat)
                .IsRequired();
            builder.Property(x => x.Carbohydrates)
                .IsRequired();
        }
    }
}
