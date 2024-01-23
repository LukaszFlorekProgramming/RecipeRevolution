using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RecipeRevolution.Persistance.Migrations
{
    /// <inheritdoc />
    public partial class addMainImageRecipe : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "MainImage",
                table: "Recipes",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MainImage",
                table: "Recipes");
        }
    }
}
