using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApp.Migrations
{
    public partial class medicationList : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.CreateTable(
                name: "MedicationList",
                columns: table => new
                {
                    EmailAdd = table.Column<string>(nullable: false),
                    MedName = table.Column<string>(maxLength: 140, nullable: true),
                    MedDescp = table.Column<string>(maxLength: 264, nullable: true),
                    Dosage = table.Column<string>(maxLength: 64, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MedicationList", x => x.EmailAdd);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MedicationList");

            migrationBuilder.AddColumn<string>(
                name: "Dosage",
                table: "RegisterUsers",
                type: "nvarchar(64)",
                maxLength: 64,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MedDescp",
                table: "RegisterUsers",
                type: "nvarchar(264)",
                maxLength: 264,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MedName",
                table: "RegisterUsers",
                type: "nvarchar(140)",
                maxLength: 140,
                nullable: true);
        }
    }
}
