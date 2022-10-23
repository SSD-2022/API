using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApp.Migrations
{
    public partial class medicalhistory : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MedicalHistory",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    EmailAdd = table.Column<string>(nullable: true),
                    Depression = table.Column<bool>(nullable: false),
                    HeartDisease = table.Column<bool>(nullable: false),
                    Stroke = table.Column<bool>(nullable: false),
                    HypertensiveDisorders = table.Column<bool>(nullable: false),
                    RespiratoryDisease = table.Column<bool>(nullable: false),
                    Hepatie = table.Column<bool>(nullable: false),
                    ConnectiveTissue = table.Column<bool>(nullable: false),
                    Musculoskeletal = table.Column<bool>(nullable: false),
                    EndocrineMetabolic = table.Column<bool>(nullable: false),
                    HematopoieticLymahane = table.Column<bool>(nullable: false),
                    RenalGenitaurinan = table.Column<bool>(nullable: false),
                    Allergies = table.Column<bool>(nullable: false),
                    AlcholAbuse = table.Column<bool>(nullable: false),
                    DrugAbuse = table.Column<bool>(nullable: false),
                    Smoking = table.Column<bool>(nullable: false),
                    Cancer = table.Column<bool>(nullable: false),
                    Insomnia = table.Column<bool>(nullable: false),
                    SleepApnea = table.Column<bool>(nullable: false),
                    Gastrointestinal = table.Column<bool>(nullable: false),
                    MajorSurgery = table.Column<bool>(nullable: false),
                    OtherInfo = table.Column<string>(nullable: true),
                    UpdatedDate = table.Column<DateTimeOffset>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MedicalHistory", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MedicalHistory");
        }
    }
}
