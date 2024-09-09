using Microsoft.EntityFrameworkCore.Migrations;

namespace VaccineTurn.Migrations
{
    public partial class updateTargets : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DaysRemaining",
                table: "Targets");

            migrationBuilder.CreateTable(
                name: "UserResultsDto",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Age = table.Column<int>(type: "int", nullable: false),
                    YourPopulationGroup = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CurrentPopulationGroup = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PeopleAhead = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CurrentDailyRate = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FirstDosesToDate = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EarliestVaccineDate = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserResultsDto", x => x.UserId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserResultsDto");

            migrationBuilder.AddColumn<int>(
                name: "DaysRemaining",
                table: "Targets",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
