using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ShopOnlineCafe.Server.Migrations
{
    /// <inheritdoc />
    public partial class UpdateOrdeIsDone : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsDone",
                table: "Orders",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsDone",
                table: "Orders");
        }
    }
}
