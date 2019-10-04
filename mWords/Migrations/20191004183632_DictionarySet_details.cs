using Microsoft.EntityFrameworkCore.Migrations;

namespace mWords.Migrations
{
    public partial class DictionarySet_details : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_DictionarySets_Name",
                schema: "mw",
                table: "DictionarySets");

            migrationBuilder.AddColumn<string>(
                name: "LanguagesPair",
                schema: "mw",
                table: "DictionarySets",
                maxLength: 1000,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "LevelDescription",
                schema: "mw",
                table: "DictionarySets",
                maxLength: 1000,
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LanguagesPair",
                schema: "mw",
                table: "DictionarySets");

            migrationBuilder.DropColumn(
                name: "LevelDescription",
                schema: "mw",
                table: "DictionarySets");

            migrationBuilder.CreateIndex(
                name: "IX_DictionarySets_Name",
                schema: "mw",
                table: "DictionarySets",
                column: "Name",
                unique: true);
        }
    }
}
