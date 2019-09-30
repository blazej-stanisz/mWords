using Microsoft.EntityFrameworkCore.Migrations;

namespace mWords.Data.Migrations
{
    public partial class m5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_WordsDictionary_English",
                schema: "mw",
                table: "WordsDictionary");

            migrationBuilder.AlterColumn<string>(
                name: "Polish",
                schema: "mw",
                table: "WordsDictionary",
                maxLength: 1000,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(1000)",
                oldMaxLength: 1000,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "English",
                schema: "mw",
                table: "WordsDictionary",
                maxLength: 1000,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(1000)",
                oldMaxLength: 1000,
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_WordsDictionary_English",
                schema: "mw",
                table: "WordsDictionary",
                column: "English",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_WordsDictionary_English",
                schema: "mw",
                table: "WordsDictionary");

            migrationBuilder.AlterColumn<string>(
                name: "Polish",
                schema: "mw",
                table: "WordsDictionary",
                type: "nvarchar(1000)",
                maxLength: 1000,
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 1000);

            migrationBuilder.AlterColumn<string>(
                name: "English",
                schema: "mw",
                table: "WordsDictionary",
                type: "nvarchar(1000)",
                maxLength: 1000,
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 1000);

            migrationBuilder.CreateIndex(
                name: "IX_WordsDictionary_English",
                schema: "mw",
                table: "WordsDictionary",
                column: "English",
                unique: true,
                filter: "[English] IS NOT NULL");
        }
    }
}
