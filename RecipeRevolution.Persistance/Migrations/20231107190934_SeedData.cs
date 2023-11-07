using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace RecipeRevolution.Persistance.Migrations
{
    /// <inheritdoc />
    public partial class SeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "CategoryId", "Name" },
                values: new object[,]
                {
                    { 1, "Śniadania" },
                    { 2, "Przekąski" },
                    { 3, "Zupy i dania zupowe" },
                    { 4, "Sałatki" },
                    { 5, "Dania główne" },
                    { 6, "Desery" },
                    { 7, "Dania wegetariańskie" },
                    { 8, "Dania wegańskie" },
                    { 9, "Dania kuchni świata" },
                    { 10, "Dania na grillu" },
                    { 11, "Pieczenie i cukiernictwo" }
                });

            migrationBuilder.InsertData(
                table: "Recipes",
                columns: new[] { "RecipeId", "CategoryId", "Description", "DifficultyLevel", "Instructions", "Name", "Portions", "PreparationTime" },
                values: new object[,]
                {
                    { 1, 11, "Najlepsze naleśniki na świecie", "Łatwy", "Mleko, mąkę, cukier, cukier waniliowy, jajkq, cynamon oraz oliwę ubijamy na jednolitą masę... ubijamy ją ok. 15 minut.\r\nSmażymy naleśniki porcjami.\r\nPodajemy na gorąco bądź zimno z owocami ... wedle uznania.", "Cynamonowe naleśniki", (short)6, 20 },
                    { 2, 11, "Naleśniki z truskawkami to danie, które doskonale sprawdzi się jako śniadanie, obiad, deser lub podwieczorek. Domownicy będą nimi zachwyceni, zwłaszcza dzieci. Podajemy sprawdzony przepis na naleśniki z truskawkami i bitą śmietaną. ", "Łatwy", "Ciasto naleśnikowe: roztrzepujemy jajko w miseczce. Dolewamy mleko i wodę gazowaną. Dosypujemy przesianą mąkę i szczyptę soli, a na koniec dodajemy olej. Dokładnie mieszamy rózgą lub za pomocą miksera, aż znikną wszystkie grudki. Gdy ciasto na naleśniki z truskawkami będzie już miało odpowiednią konsystencję, odstawiamy je na około 20–30 minut.", "Naleśniki z truskawkami", (short)4, 30 }
                });

            migrationBuilder.InsertData(
                table: "Ingredients",
                columns: new[] { "IngredientId", "Name", "Quantity", "RecipeId", "Unit" },
                values: new object[,]
                {
                    { 1, "mąka", 300.0, 1, "gram" },
                    { 2, "mleko", 275.0, 1, "mililitry" }
                });

            migrationBuilder.InsertData(
                table: "NutritionalValues",
                columns: new[] { "NutritionalValuesId", "Calories", "Carbohydrates", "Fat", "Protein", "RecipeId" },
                values: new object[,]
                {
                    { 1, 500.0, 60.0, 14.0, 10.0, 1 },
                    { 2, 400.0, 50.0, 18.0, 12.0, 2 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "NutritionalValues",
                keyColumn: "NutritionalValuesId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "NutritionalValues",
                keyColumn: "NutritionalValuesId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Recipes",
                keyColumn: "RecipeId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Recipes",
                keyColumn: "RecipeId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 11);
        }
    }
}
