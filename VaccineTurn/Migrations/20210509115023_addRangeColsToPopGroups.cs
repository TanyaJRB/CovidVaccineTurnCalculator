using Microsoft.EntityFrameworkCore.Migrations;

namespace VaccineTurn.Migrations
{
    public partial class addRangeColsToPopGroups : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AgeGroup",
                table: "PopulationGroups");

            migrationBuilder.AddColumn<int>(
                name: "AgeGroupMax",
                table: "PopulationGroups",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "AgeGroupMin",
                table: "PopulationGroups",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AgeGroupMax",
                table: "PopulationGroups");

            migrationBuilder.DropColumn(
                name: "AgeGroupMin",
                table: "PopulationGroups");

            migrationBuilder.AddColumn<string>(
                name: "AgeGroup",
                table: "PopulationGroups",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
