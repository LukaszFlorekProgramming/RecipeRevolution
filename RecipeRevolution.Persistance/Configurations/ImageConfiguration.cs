using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RecipeRevolution.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeRevolution.Persistance.Configurations
{
    public class ImageConfiguration : IEntityTypeConfiguration<Image>
    {
        public void Configure(EntityTypeBuilder<Image> builder)
        {
            builder.HasKey(x => x.ImageId);
            builder.Property(x => x.FileName)
                .IsRequired()
                .HasMaxLength(300);
            builder.Property(x => x.Data)
                .IsRequired();
            builder.Property(x => x.ContentType)
                .IsRequired();
        }
    }
}
