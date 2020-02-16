using Microsoft.EntityFrameworkCore.Migrations;

namespace WeddingPlanner.Migrations
{
    public partial class EigthMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Action",
                table: "Users");

            migrationBuilder.AddColumn<string>(
                name: "Action",
                table: "Weddings",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Action",
                table: "Weddings");

            migrationBuilder.AddColumn<string>(
                name: "Action",
                table: "Users",
                nullable: true);
        }
    }
}
