using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace VaccineTurn.Migrations
{
    public partial class newTableFirstDosesByDate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "FirstDosesByDate",
                columns: table => new
                {
                    FirstDosesByDateId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CurrentDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TotalFirstDoses = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FirstDosesByDate", x => x.FirstDosesByDateId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FirstDosesByDate");
        }
    }
}
