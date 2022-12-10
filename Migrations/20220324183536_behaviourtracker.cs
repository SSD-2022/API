using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApp.Migrations
{
    public partial class behaviourtracker : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BehaviourTracker",
                columns: table => new
                {
                    EmailAdd = table.Column<string>(nullable: false),
                    Agression = table.Column<int>(nullable: false),
                    Agitation = table.Column<int>(nullable: false),
                    Apathy = table.Column<int>(nullable: false),
                    EatingProblems = table.Column<int>(nullable: false),
                    ExcessiveCollecting = table.Column<int>(nullable: false),
                    ExcessiveOrganizing = table.Column<int>(nullable: false),
                    ImaginingThings = table.Column<int>(nullable: false),
                    Impulsiveness = table.Column<int>(nullable: false),
                    Incontinence = table.Column<int>(nullable: false),
                    Repetition = table.Column<int>(nullable: false),
                    ResistancetoCare = table.Column<int>(nullable: false),
                    Restlessness = table.Column<int>(nullable: false),
                    SafetyConcerns = table.Column<int>(nullable: false),
                    Sleeping = table.Column<int>(nullable: false),
                    Suspicion = table.Column<int>(nullable: false),
                    Wandering = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BehaviourTracker", x => x.EmailAdd);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BehaviourTracker");
        }
    }
}
