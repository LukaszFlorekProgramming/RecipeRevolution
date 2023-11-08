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
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.FirstName)
                .IsRequired()
                .HasMaxLength(30);
            builder.Property(x => x.LastName)
                .IsRequired()
                .HasMaxLength(40);
            builder.Property(x => x.Nationality)
                .IsRequired()
                .HasMaxLength(40);
            builder.Property(x => x.LastName)
                .IsRequired()
                .HasMaxLength(58);
            builder.Property(x => x.PasswordHash)
                .IsRequired()
                .HasMaxLength(60);


        }
    }
}
