using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ShopOnlineCafe.Server.Migrations
{
    /// <inheritdoc />
    public partial class UpdateOrderKod : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Kod",
                table: "Orders",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Kod",
                table: "Orders");
        }
    }
}
