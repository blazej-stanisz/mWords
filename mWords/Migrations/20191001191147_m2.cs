using Microsoft.EntityFrameworkCore.Migrations;

namespace mWords.Migrations
{
    public partial class m2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "DictionarySetId",
                schema: "mw",
                table: "DictionaryEntries",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "DictionarySets",
                schema: "mw",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 1000, nullable: false),
                    Description = table.Column<string>(maxLength: 1000, nullable: false),
                    Level = table.Column<string>(maxLength: 1000, nullable: false),
                    CoverColorHex = table.Column<string>(maxLength: 1000, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DictionarySets", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DictionaryEntries_DictionarySetId",
                schema: "mw",
                table: "DictionaryEntries",
                column: "DictionarySetId");

            migrationBuilder.CreateIndex(
                name: "IX_DictionarySets_Name",
                schema: "mw",
                table: "DictionarySets",
                column: "Name",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_DictionaryEntries_DictionarySets_DictionarySetId",
                schema: "mw",
                table: "DictionaryEntries",
                column: "DictionarySetId",
                principalSchema: "mw",
                principalTable: "DictionarySets",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DictionaryEntries_DictionarySets_DictionarySetId",
                schema: "mw",
                table: "DictionaryEntries");

            migrationBuilder.DropTable(
                name: "DictionarySets",
                schema: "mw");

            migrationBuilder.DropIndex(
                name: "IX_DictionaryEntries_DictionarySetId",
                schema: "mw",
                table: "DictionaryEntries");

            migrationBuilder.DropColumn(
                name: "DictionarySetId",
                schema: "mw",
                table: "DictionaryEntries");
        }
    }
}
