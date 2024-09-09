using Microsoft.EntityFrameworkCore.Migrations;

namespace VaccineTurn.Migrations
{
    public partial class colRenameTotalVaccs : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "TargetFirstDoses",
                table: "TotalVaccinations",
                newName: "TotalFirstDoses");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "TotalFirstDoses",
                table: "TotalVaccinations",
                newName: "TargetFirstDoses");
        }
    }
}
