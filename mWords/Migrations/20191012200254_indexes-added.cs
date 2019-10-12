using Microsoft.EntityFrameworkCore.Migrations;

namespace mWords.Migrations
{
    public partial class indexesadded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Translation",
                schema: "mw",
                table: "DictionaryEntries",
                maxLength: 1000,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_DictionarySets_Name",
                schema: "mw",
                table: "DictionarySets",
                column: "Name");

            migrationBuilder.CreateIndex(
                name: "IX_DictionaryEntries_Translation",
                schema: "mw",
                table: "DictionaryEntries",
                column: "Translation");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_DictionarySets_Name",
                schema: "mw",
                table: "DictionarySets");

            migrationBuilder.DropIndex(
                name: "IX_DictionaryEntries_Translation",
                schema: "mw",
                table: "DictionaryEntries");

            migrationBuilder.AlterColumn<string>(
                name: "Translation",
                schema: "mw",
                table: "DictionaryEntries",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 1000);
        }
    }
}
