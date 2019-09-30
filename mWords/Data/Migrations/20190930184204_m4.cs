using Microsoft.EntityFrameworkCore.Migrations;

namespace mWords.Data.Migrations
{
    public partial class m4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_WordsDictionary_English",
                schema: "mw",
                table: "WordsDictionary",
                column: "English",
                unique: true,
                filter: "[English] IS NOT NULL");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_WordsDictionary_English",
                schema: "mw",
                table: "WordsDictionary");
        }
    }
}
