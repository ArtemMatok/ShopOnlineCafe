using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ShopOnlineCafe.Server.Migrations
{
    /// <inheritdoc />
    public partial class FoodAddCategoryField : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Category",
                table: "Foods",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Category",
                table: "Foods");
        }
    }
}
