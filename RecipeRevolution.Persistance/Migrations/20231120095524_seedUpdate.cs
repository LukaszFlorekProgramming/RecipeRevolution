using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace RecipeRevolution.Persistance.Migrations
{
    /// <inheritdoc />
    public partial class seedUpdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Recipes",
                columns: new[] { "RecipeId", "CategoryId", "CreatedById", "Description", "DifficultyLevel", "Instructions", "Name", "Portions", "PreparationTime" },
                values: new object[,]
                {
                    { 3, 6, null, "Miękkie masło ubić na puszysto, stopniowo dodawać po jednym żółtku na przemian z łyżką cukru pudru, cały czas dokładnie ubijając składniki.", "Łatwy", "Miękkie masło ubić na puszysto, stopniowo dodawać po jednym żółtku na przemian z łyżką cukru pudru, cały czas dokładnie ubijając składniki.", "SERNIK TRADYCYJNY", (short)6, 40 },
                    { 4, 4, null, "Z czerwoną fasolą, kukurydzą i czerwoną cebulą", "Łatwy", "Mango i awokado obrać, pokroić w kosteczkę i włożyć do salaterki lub szklanej miski. Polać sokiem wyciśniętym z całej limonki.\r\nDodać drobno posiekaną czerwoną cebulę, pokrojoną w kosteczkę czerwoną paprykę, odcedzoną na sitku kukurydzę i czerwoną fasolę.\r\nDodać listki kolendry, syrop klonowy, oliwę oraz chili. Wymieszać i podawać.", "SAŁATKA MEKSYKAŃSKA Z MANGO I AWOKADO", (short)4, 35 },
                    { 5, 6, null, "Z dodatkiem ogórka, papryki, pomidorków koktajlowych, granatu i sera sałatkowego", "Łatwy", "Sałatka z kaszą bulgur, z pomidorkami, ogórkiem, granatem i dużą ilością zieleniny: mięty, natki i szczypiorku. Z dodatkiem sera sałatkowego lub fety.", "SAŁATKA Z BULGUREM", (short)5, 12 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Recipes",
                keyColumn: "RecipeId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Recipes",
                keyColumn: "RecipeId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Recipes",
                keyColumn: "RecipeId",
                keyValue: 5);
        }
    }
}
