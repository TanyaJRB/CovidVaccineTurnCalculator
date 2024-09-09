using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace VaccineTurn.Migrations
{
    public partial class addAnnouncementDateColPopGroups : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "DateOfAnnouncement",
                table: "PopulationGroups",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DateOfAnnouncement",
                table: "PopulationGroups");
        }
    }
}
