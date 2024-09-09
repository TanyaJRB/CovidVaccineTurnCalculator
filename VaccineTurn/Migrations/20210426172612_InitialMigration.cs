using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace VaccineTurn.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PopulationGroups",
                columns: table => new
                {
                    PopulationGroupsId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AgeGroup = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NumberPeople = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PopulationGroups", x => x.PopulationGroupsId);
                });

            migrationBuilder.CreateTable(
                name: "Targets",
                columns: table => new
                {
                    TargetsId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TargetDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TargetFirstDoses = table.Column<int>(type: "int", nullable: false),
                    DaysRemaining = table.Column<int>(type: "int", nullable: false),
                    TargetWeeklyRate = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Targets", x => x.TargetsId);
                });

            migrationBuilder.CreateTable(
                name: "TotalVaccinations",
                columns: table => new
                {
                    TotalVaccinationsId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VaccType = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TargetFirstDoses = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TotalVaccinations", x => x.TotalVaccinationsId);
                });

            migrationBuilder.CreateTable(
                name: "DailyRate",
                columns: table => new
                {
                    DailyRateId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CurrentRate = table.Column<int>(type: "int", nullable: false),
                    PopulationGroupsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DailyRate", x => x.DailyRateId);
                    table.ForeignKey(
                        name: "FK_DailyRate_PopulationGroups_PopulationGroupsId",
                        column: x => x.PopulationGroupsId,
                        principalTable: "PopulationGroups",
                        principalColumn: "PopulationGroupsId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DailyRate_PopulationGroupsId",
                table: "DailyRate",
                column: "PopulationGroupsId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DailyRate");

            migrationBuilder.DropTable(
                name: "Targets");

            migrationBuilder.DropTable(
                name: "TotalVaccinations");

            migrationBuilder.DropTable(
                name: "PopulationGroups");
        }
    }
}
