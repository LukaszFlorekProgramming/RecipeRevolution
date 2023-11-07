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
                    Instructions = "Mleko, mąkę, cukier, cukier waniliowy, jajkq, cynamon oraz oliwę ubijamy na jednolitą masę... ubijamy ją ok. 15 minut.\r\nSmażymy naleśniki porcjami.\r\nPodajemy na gorąco bądź zimno z owocami ... wedle uznania.",
                    PreparationTime = 20,
                    DifficultyLevel = "Łatwy",
                    Portions = 6,
                    CategoryId = 11,
                }, new Recipe()
                {
                    RecipeId = 2,
                    Name = "Naleśniki z truskawkami",
                    Description = "Naleśniki z truskawkami to danie, które doskonale sprawdzi się jako śniadanie, obiad, deser lub podwieczorek. Domownicy będą nimi zachwyceni, zwłaszcza dzieci. Podajemy sprawdzony przepis na naleśniki z truskawkami i bitą śmietaną. ",
                    Instructions = "Ciasto naleśnikowe: roztrzepujemy jajko w miseczce. Dolewamy mleko i wodę gazowaną. Dosypujemy przesianą mąkę i szczyptę soli, a na koniec dodajemy olej. Dokładnie mieszamy rózgą lub za pomocą miksera, aż znikną wszystkie grudki. Gdy ciasto na naleśniki z truskawkami będzie już miało odpowiednią konsystencję, odstawiamy je na około 20–30 minut.",
                    PreparationTime = 30,
                    DifficultyLevel = "Łatwy",
                    Portions = 4,
                    CategoryId = 11,
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
        }

    }
}
