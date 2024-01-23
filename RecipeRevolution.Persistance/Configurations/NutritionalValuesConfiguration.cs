using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RecipeRevolution.Domain.Entities;

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
