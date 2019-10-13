using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace mWords.Migrations
{
    public partial class EntryAssignmentupdated : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "AttemptDate",
                schema: "mw",
                table: "EntryAssignments",
                nullable: false,
                defaultValueSql: "getdate()");

            migrationBuilder.AddColumn<byte>(
                name: "Pigeonhole",
                schema: "mw",
                table: "EntryAssignments",
                nullable: false,
                defaultValueSql: "1");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AttemptDate",
                schema: "mw",
                table: "EntryAssignments");

            migrationBuilder.DropColumn(
                name: "Pigeonhole",
                schema: "mw",
                table: "EntryAssignments");
        }
    }
}
