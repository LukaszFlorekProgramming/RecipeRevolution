﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using RecipeRevolution.Persistance;

#nullable disable

namespace RecipeRevolution.Persistance.Migrations
{
    [DbContext(typeof(RecipeRevolutionDbContext))]
    [Migration("20231108155728_AddUserAndRoleEntities")]
    partial class AddUserAndRoleEntities
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.13")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("RecipeRevolution.Domain.Entities.Category", b =>
                {
                    b.Property<int>("CategoryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CategoryId"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CategoryId");

                    b.ToTable("Categories");

                    b.HasData(
                        new
                        {
                            CategoryId = 1,
                            Name = "Śniadania"
                        },
                        new
                        {
                            CategoryId = 2,
                            Name = "Przekąski"
                        },
                        new
                        {
                            CategoryId = 3,
                            Name = "Zupy i dania zupowe"
                        },
                        new
                        {
                            CategoryId = 4,
                            Name = "Sałatki"
                        },
                        new
                        {
                            CategoryId = 5,
                            Name = "Dania główne"
                        },
                        new
                        {
                            CategoryId = 6,
                            Name = "Desery"
                        },
                        new
                        {
                            CategoryId = 7,
                            Name = "Dania wegetariańskie"
                        },
                        new
                        {
                            CategoryId = 8,
                            Name = "Dania wegańskie"
                        },
                        new
                        {
                            CategoryId = 9,
                            Name = "Dania kuchni świata"
                        },
                        new
                        {
                            CategoryId = 10,
                            Name = "Dania na grillu"
                        },
                        new
                        {
                            CategoryId = 11,
                            Name = "Pieczenie i cukiernictwo"
                        });
                });

            modelBuilder.Entity("RecipeRevolution.Domain.Entities.Image", b =>
                {
                    b.Property<int>("ImageId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ImageId"));

                    b.Property<int>("RecipeId")
                        .HasColumnType("int");

                    b.Property<string>("Url")
                        .IsRequired()
                        .HasMaxLength(300)
                        .HasColumnType("nvarchar(300)");

                    b.HasKey("ImageId");

                    b.HasIndex("RecipeId");

                    b.ToTable("Images");
                });

            modelBuilder.Entity("RecipeRevolution.Domain.Entities.Ingredient", b =>
                {
                    b.Property<int>("IngredientId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IngredientId"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<double>("Quantity")
                        .HasMaxLength(14)
                        .HasColumnType("float");

                    b.Property<int>("RecipeId")
                        .HasColumnType("int");

                    b.Property<string>("Unit")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IngredientId");

                    b.HasIndex("RecipeId");

                    b.ToTable("Ingredients");

                    b.HasData(
                        new
                        {
                            IngredientId = 1,
                            Name = "mąka",
                            Quantity = 300.0,
                            RecipeId = 1,
                            Unit = "gram"
                        },
                        new
                        {
                            IngredientId = 2,
                            Name = "mleko",
                            Quantity = 275.0,
                            RecipeId = 1,
                            Unit = "mililitry"
                        });
                });

            modelBuilder.Entity("RecipeRevolution.Domain.Entities.NutritionalValues", b =>
                {
                    b.Property<int>("NutritionalValuesId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("NutritionalValuesId"));

                    b.Property<double>("Calories")
                        .HasColumnType("float");

                    b.Property<double>("Carbohydrates")
                        .HasColumnType("float");

                    b.Property<double>("Fat")
                        .HasColumnType("float");

                    b.Property<double>("Protein")
                        .HasColumnType("float");

                    b.Property<int>("RecipeId")
                        .HasColumnType("int");

                    b.HasKey("NutritionalValuesId");

                    b.HasIndex("RecipeId")
                        .IsUnique();

                    b.ToTable("NutritionalValues");

                    b.HasData(
                        new
                        {
                            NutritionalValuesId = 1,
                            Calories = 500.0,
                            Carbohydrates = 60.0,
                            Fat = 14.0,
                            Protein = 10.0,
                            RecipeId = 1
                        },
                        new
                        {
                            NutritionalValuesId = 2,
                            Calories = 400.0,
                            Carbohydrates = 50.0,
                            Fat = 18.0,
                            Protein = 12.0,
                            RecipeId = 2
                        });
                });

            modelBuilder.Entity("RecipeRevolution.Domain.Entities.Recipe", b =>
                {
                    b.Property<int>("RecipeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("RecipeId"));

                    b.Property<int>("CategoryId")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.Property<string>("DifficultyLevel")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.Property<string>("Instructions")
                        .IsRequired()
                        .HasMaxLength(450)
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(60)
                        .HasColumnType("nvarchar(60)");

                    b.Property<short>("Portions")
                        .HasColumnType("smallint");

                    b.Property<int>("PreparationTime")
                        .HasColumnType("int");

                    b.HasKey("RecipeId");

                    b.HasIndex("CategoryId");

                    b.ToTable("Recipes");

                    b.HasData(
                        new
                        {
                            RecipeId = 1,
                            CategoryId = 11,
                            Description = "Najlepsze naleśniki na świecie",
                            DifficultyLevel = "Łatwy",
                            Instructions = "Mleko, mąkę, cukier, cukier waniliowy, jajka, cynamon oraz oliwę ubijamy na jednolitą masę... ubijamy ją ok. 15 minut.\r\nSmażymy naleśniki porcjami.",
                            Name = "Cynamonowe naleśniki",
                            Portions = (short)6,
                            PreparationTime = 20
                        },
                        new
                        {
                            RecipeId = 2,
                            CategoryId = 11,
                            Description = "Naleśniki z truskawkami to danie, które doskonale sprawdzi się jako śniadanie, obiad, deser lub podwieczorek.",
                            DifficultyLevel = "Łatwy",
                            Instructions = "Ciasto naleśnikowe: roztrzepujemy jajko w miseczce. Dolewamy mleko i wodę gazowaną",
                            Name = "Naleśniki z truskawkami",
                            Portions = (short)4,
                            PreparationTime = 30
                        });
                });

            modelBuilder.Entity("RecipeRevolution.Domain.Entities.Role", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(15)
                        .HasColumnType("nvarchar(15)");

                    b.HasKey("Id");

                    b.ToTable("Roles");
                });

            modelBuilder.Entity("RecipeRevolution.Domain.Entities.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime?>("DateOfBirth")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(58)
                        .HasColumnType("nvarchar(58)");

                    b.Property<string>("Nationality")
                        .IsRequired()
                        .HasMaxLength(40)
                        .HasColumnType("nvarchar(40)");

                    b.Property<string>("PasswordHash")
                        .IsRequired()
                        .HasMaxLength(60)
                        .HasColumnType("nvarchar(60)");

                    b.Property<int>("RoleId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("RecipeRevolution.Domain.Entities.Image", b =>
                {
                    b.HasOne("RecipeRevolution.Domain.Entities.Recipe", "Recipe")
                        .WithMany("Images")
                        .HasForeignKey("RecipeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Recipe");
                });

            modelBuilder.Entity("RecipeRevolution.Domain.Entities.Ingredient", b =>
                {
                    b.HasOne("RecipeRevolution.Domain.Entities.Recipe", "Recipe")
                        .WithMany("Ingredients")
                        .HasForeignKey("RecipeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Recipe");
                });

            modelBuilder.Entity("RecipeRevolution.Domain.Entities.NutritionalValues", b =>
                {
                    b.HasOne("RecipeRevolution.Domain.Entities.Recipe", "Recipe")
                        .WithOne("NutritionalValues")
                        .HasForeignKey("RecipeRevolution.Domain.Entities.NutritionalValues", "RecipeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Recipe");
                });

            modelBuilder.Entity("RecipeRevolution.Domain.Entities.Recipe", b =>
                {
                    b.HasOne("RecipeRevolution.Domain.Entities.Category", "Category")
                        .WithMany("Recipes")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");
                });

            modelBuilder.Entity("RecipeRevolution.Domain.Entities.User", b =>
                {
                    b.HasOne("RecipeRevolution.Domain.Entities.Role", "Role")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Role");
                });

            modelBuilder.Entity("RecipeRevolution.Domain.Entities.Category", b =>
                {
                    b.Navigation("Recipes");
                });

            modelBuilder.Entity("RecipeRevolution.Domain.Entities.Recipe", b =>
                {
                    b.Navigation("Images");

                    b.Navigation("Ingredients");

                    b.Navigation("NutritionalValues")
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
