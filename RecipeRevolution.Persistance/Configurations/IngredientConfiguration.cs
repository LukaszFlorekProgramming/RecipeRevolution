using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RecipeRevolution.Domain.Entities;

namespace RecipeRevolution.Persistance.Configurations
{
    public class IngredientConfiguration : IEntityTypeConfiguration<Ingredient>
    {
        public void Configure(EntityTypeBuilder<Ingredient> builder)
        {
            builder.HasKey(x => x.IngredientId);
            builder.Property(x => x.Name)
                .IsRequired()
                .HasMaxLength(50);
            builder.Property(x => x.Quantity)
               .IsRequired();
            builder.Property(x => x.Quantity)
               .IsRequired()
               .HasMaxLength(14);
        }
    }
}
