using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RecipeRevolution.Domain.Entities;

namespace RecipeRevolution.Persistance.Configurations
{
    public class RecipeConfiguration : IEntityTypeConfiguration<Recipe>
    {
        public void Configure(EntityTypeBuilder<Recipe> builder)
        {
            builder.HasKey(x => x.RecipeId);
            builder.Property(x => x.Name)
                .IsRequired()
                .HasMaxLength(60);
            builder.Property(x => x.Description)
                .IsRequired()
                .HasMaxLength(150);
            builder.Property(x => x.Instructions)
                .IsRequired()
                .HasMaxLength(450);
            builder.Property(x => x.PreparationTime)
                .IsRequired();
            builder.Property(x => x.DifficultyLevel)
                .IsRequired()
                .HasMaxLength(10);
            builder.Property(x => x.DifficultyLevel)
                .IsRequired();
            builder.Property(x => x.CategoryId)
                .IsRequired();

            builder.HasOne(r => r.CreatedBy)
               .WithMany()
               .HasForeignKey(r => r.CreatedById)
               .IsRequired();
        }
    }
}
