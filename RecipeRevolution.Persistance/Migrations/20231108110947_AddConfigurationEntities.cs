using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RecipeRevolution.Persistance.Migrations
{
    /// <inheritdoc />
    public partial class AddConfigurationEntities : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Recipes",
                type: "nvarchar(60)",
                maxLength: 60,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Instructions",
                table: "Recipes",
                type: "nvarchar(450)",
                maxLength: 450,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "DifficultyLevel",
                table: "Recipes",
                type: "nvarchar(10)",
                maxLength: 10,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Recipes",
                type: "nvarchar(150)",
                maxLength: 150,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Ingredients",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Url",
                table: "Images",
                type: "nvarchar(300)",
                maxLength: 300,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.UpdateData(
                table: "Recipes",
                keyColumn: "RecipeId",
                keyValue: 1,
                column: "Instructions",
                value: "Mleko, mąkę, cukier, cukier waniliowy, jajka, cynamon oraz oliwę ubijamy na jednolitą masę... ubijamy ją ok. 15 minut.\r\nSmażymy naleśniki porcjami.");

            migrationBuilder.UpdateData(
                table: "Recipes",
                keyColumn: "RecipeId",
                keyValue: 2,
                columns: new[] { "Description", "Instructions" },
                values: new object[] { "Naleśniki z truskawkami to danie, które doskonale sprawdzi się jako śniadanie, obiad, deser lub podwieczorek.", "Ciasto naleśnikowe: roztrzepujemy jajko w miseczce. Dolewamy mleko i wodę gazowaną" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Recipes",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(60)",
                oldMaxLength: 60);

            migrationBuilder.AlterColumn<string>(
                name: "Instructions",
                table: "Recipes",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldMaxLength: 450);

            migrationBuilder.AlterColumn<string>(
                name: "DifficultyLevel",
                table: "Recipes",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(10)",
                oldMaxLength: 10);

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Recipes",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(150)",
                oldMaxLength: 150);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Ingredients",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<string>(
                name: "Url",
                table: "Images",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(300)",
                oldMaxLength: 300);

            migrationBuilder.UpdateData(
                table: "Recipes",
                keyColumn: "RecipeId",
                keyValue: 1,
                column: "Instructions",
                value: "Mleko, mąkę, cukier, cukier waniliowy, jajkq, cynamon oraz oliwę ubijamy na jednolitą masę... ubijamy ją ok. 15 minut.\r\nSmażymy naleśniki porcjami.\r\nPodajemy na gorąco bądź zimno z owocami ... wedle uznania.");

            migrationBuilder.UpdateData(
                table: "Recipes",
                keyColumn: "RecipeId",
                keyValue: 2,
                columns: new[] { "Description", "Instructions" },
                values: new object[] { "Naleśniki z truskawkami to danie, które doskonale sprawdzi się jako śniadanie, obiad, deser lub podwieczorek. Domownicy będą nimi zachwyceni, zwłaszcza dzieci. Podajemy sprawdzony przepis na naleśniki z truskawkami i bitą śmietaną. ", "Ciasto naleśnikowe: roztrzepujemy jajko w miseczce. Dolewamy mleko i wodę gazowaną. Dosypujemy przesianą mąkę i szczyptę soli, a na koniec dodajemy olej. Dokładnie mieszamy rózgą lub za pomocą miksera, aż znikną wszystkie grudki. Gdy ciasto na naleśniki z truskawkami będzie już miało odpowiednią konsystencję, odstawiamy je na około 20–30 minut." });
        }
    }
}
