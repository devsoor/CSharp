using Microsoft.EntityFrameworkCore.Migrations;

namespace WeddingPlanner.Migrations
{
    public partial class SecondMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Action",
                table: "Weddings",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Weddings",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Action",
                table: "Weddings");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "Weddings");
        }
    }
}
