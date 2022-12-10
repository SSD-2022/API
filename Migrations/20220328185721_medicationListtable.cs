using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApp.Migrations
{
    public partial class medicationListtable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Dosage",
                table: "RegisterUsers",
                maxLength: 64,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MedDescp",
                table: "RegisterUsers",
                maxLength: 264,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MedName",
                table: "RegisterUsers",
                maxLength: 140,
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Dosage",
                table: "RegisterUsers");

            migrationBuilder.DropColumn(
                name: "MedDescp",
                table: "RegisterUsers");

            migrationBuilder.DropColumn(
                name: "MedName",
                table: "RegisterUsers");
        }
    }
}
