using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RecipeRevolution.Domain.Entities;
using System.Reflection.Emit;

namespace RecipeRevolution.Persistance.Configurations
{
    public class CommentConfiguration : IEntityTypeConfiguration<Comment>
    {
        public void Configure(EntityTypeBuilder<Comment> builder)
        {
            builder.HasOne(c => c.Recipe)
                .WithMany(r => r.Comments)
                .HasForeignKey(c => c.RecipeId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.Property(x => x.Text)
                .IsRequired()
                .HasMaxLength(500);
            builder.Property(x => x.CreatedAt)
               .IsRequired();
            builder.Property(x => x.CreatedById)
                .IsRequired();
        }
    }
}
