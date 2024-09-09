using Microsoft.EntityFrameworkCore.Migrations;

namespace VaccineTurn.Migrations
{
    public partial class RemoveForeignKeyDailyRatePopGroup : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DailyRate_PopulationGroups_PopulationGroupsId",
                table: "DailyRate");

            migrationBuilder.DropIndex(
                name: "IX_DailyRate_PopulationGroupsId",
                table: "DailyRate");

            migrationBuilder.DropColumn(
                name: "PopulationGroupsId",
                table: "DailyRate");

            migrationBuilder.AddColumn<bool>(
                name: "CurrentPopGroup",
                table: "PopulationGroups",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CurrentPopGroup",
                table: "PopulationGroups");

            migrationBuilder.AddColumn<int>(
                name: "PopulationGroupsId",
                table: "DailyRate",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_DailyRate_PopulationGroupsId",
                table: "DailyRate",
                column: "PopulationGroupsId");

            migrationBuilder.AddForeignKey(
                name: "FK_DailyRate_PopulationGroups_PopulationGroupsId",
                table: "DailyRate",
                column: "PopulationGroupsId",
                principalTable: "PopulationGroups",
                principalColumn: "PopulationGroupsId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
