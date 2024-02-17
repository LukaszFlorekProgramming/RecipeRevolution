using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RecipeRevolution.Persistance.Migrations
{
    /// <inheritdoc />
    public partial class AddIsProfileComplete : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsProfileComplete",
                table: "AspNetUsers",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsProfileComplete",
                table: "AspNetUsers");
        }
    }
}
