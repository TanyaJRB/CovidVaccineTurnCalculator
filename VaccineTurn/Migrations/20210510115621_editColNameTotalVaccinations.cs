using Microsoft.EntityFrameworkCore.Migrations;

namespace VaccineTurn.Migrations
{
    public partial class editColNameTotalVaccinations : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "TotalFirstDoses",
                table: "TotalVaccinations",
                newName: "TotalDoses");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "TotalDoses",
                table: "TotalVaccinations",
                newName: "TotalFirstDoses");
        }
    }
}
