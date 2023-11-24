using Microsoft.EntityFrameworkCore;
using RecipeRevolution.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace RecipeRevolution.Persistance.Migrations
{
    public static class Seed
    {
        public static void SeedData(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>(c =>
            {
                c.HasData(new Category()
                {
                    CategoryId = 1,
                    Name = "Śniadania"
                },
                new Category()
                {
                    CategoryId = 2,
                    Name = "Przekąski"
                },
                new Category()
                {
                    CategoryId = 3,
                    Name = "Zupy i dania zupowe"
                },
                new Category()
                {
                    CategoryId = 4,
                    Name = "Sałatki"
                },
                new Category()
                {
                    CategoryId = 5,
                    Name = "Dania główne"
                },
                new Category()
                {
                    CategoryId = 6,
                    Name = "Desery"
                },
                new Category()
                {
                    CategoryId = 7,
                    Name = "Dania wegetariańskie"
                },
                new Category()
                {
                    CategoryId = 8,
                    Name = "Dania wegańskie"
                },
                new Category()
                {   CategoryId = 9,
                    Name = "Dania kuchni świata"
                },

                new Category()
                {   CategoryId = 10, 
                    Name = "Dania na grillu"
                },
                new Category()
                {
                    CategoryId = 11,
                    Name = "Pieczenie i cukiernictwo"
                });
            });
            modelBuilder.Entity<Recipe>(c =>
            {
                c.HasData(new Recipe()
                {
                    RecipeId = 1,
                    Name = "Cynamonowe naleśniki",
                    Description = "Najlepsze naleśniki na świecie",
                    Instructions = "Mleko, mąkę, cukier, cukier waniliowy, jajka, cynamon oraz oliwę ubijamy na jednolitą masę... ubijamy ją ok. 15 minut.\r\nSmażymy naleśniki porcjami.",
                    PreparationTime = 20,
                    DifficultyLevel = "Łatwy",
                    Portions = 6,
                    CategoryId = 11,
                }, new Recipe()
                {
                    RecipeId = 2,
                    Name = "Naleśniki z truskawkami",
                    Description = "Naleśniki z truskawkami to danie, które doskonale sprawdzi się jako śniadanie, obiad, deser lub podwieczorek.",
                    Instructions = "Ciasto naleśnikowe: roztrzepujemy jajko w miseczce. Dolewamy mleko i wodę gazowaną",
                    PreparationTime = 30,
                    DifficultyLevel = "Łatwy",
                    Portions = 4,
                    CategoryId = 11,
                }, new Recipe()
                {
                    RecipeId = 3,
                    Name = "SERNIK TRADYCYJNY",
                    Description = "Miękkie masło ubić na puszysto, stopniowo dodawać po jednym żółtku na przemian z łyżką cukru pudru, cały czas dokładnie ubijając składniki.",
                    Instructions = "Miękkie masło ubić na puszysto, stopniowo dodawać po jednym żółtku na przemian z łyżką cukru pudru, cały czas dokładnie ubijając składniki.",
                    PreparationTime = 40,
                    DifficultyLevel = "Łatwy",
                    Portions = 6,
                    CategoryId = 6,
                }
                , new Recipe()
                {
                    RecipeId = 4,
                    Name = "SAŁATKA MEKSYKAŃSKA Z MANGO I AWOKADO",
                    Description = "Z czerwoną fasolą, kukurydzą i czerwoną cebulą",
                    Instructions = "Mango i awokado obrać, pokroić w kosteczkę i włożyć do salaterki lub szklanej miski. Polać sokiem wyciśniętym z całej limonki.\r\nDodać drobno posiekaną czerwoną cebulę, pokrojoną w kosteczkę czerwoną paprykę, odcedzoną na sitku kukurydzę i czerwoną fasolę.\r\nDodać listki kolendry, syrop klonowy, oliwę oraz chili. Wymieszać i podawać.",
                    PreparationTime = 35,
                    DifficultyLevel = "Łatwy",
                    Portions = 4,
                    CategoryId = 4,
                }
                , new Recipe()
                {
                    RecipeId = 5,
                    Name = "SAŁATKA Z BULGUREM",
                    Description = "Z dodatkiem ogórka, papryki, pomidorków koktajlowych, granatu i sera sałatkowego",
                    Instructions = "Sałatka z kaszą bulgur, z pomidorkami, ogórkiem, granatem i dużą ilością zieleniny: mięty, natki i szczypiorku. Z dodatkiem sera sałatkowego lub fety.",
                    PreparationTime = 12,
                    DifficultyLevel = "Łatwy",
                    Portions = 5,
                    CategoryId = 6,
                });
            });
            modelBuilder.Entity<NutritionalValues>(c =>
            {
                c.HasData(new NutritionalValues()
                {
                    NutritionalValuesId = 1,
                    Calories = 500,
                    Protein = 10,
                    Carbohydrates = 60,
                    Fat = 14,
                    RecipeId = 1
                },
                new NutritionalValues()
                {
                    NutritionalValuesId = 2,
                    Calories = 400,
                    Protein = 12,
                    Carbohydrates = 50,
                    Fat = 18,
                    RecipeId = 2
                });
            });
            modelBuilder.Entity<Ingredient>(c =>
            {
                c.HasData(new Ingredient()
                {
                    IngredientId = 1,
                    Name= "mąka",
                    Quantity = 300,
                    Unit = "gram",
                    RecipeId = 1
                },
                new Ingredient()
                {
                    IngredientId = 2,
                    Name = "mleko",
                    Quantity = 275,
                    Unit = "mililitry",
                    RecipeId = 1
                });
            });
            modelBuilder.Entity<Role>(r =>
            {
                r.HasData(new Role()
                {
                    Id = 1,
                    Name = "User"
                },
                new Role()
                {
                    Id = 2,
                    Name = "Manager"
                },
                new Role()
                {
                    Id= 3,
                    Name = "Admin"
                });
            });
        }

    }
}
