using Microsoft.EntityFrameworkCore.Migrations;

namespace mWords.Migrations
{
    public partial class EntryAssignmentadded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "EntryAssignments",
                schema: "mw",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DictionaryEntryId = table.Column<int>(nullable: false),
                    ApplicationUserId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EntryAssignments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EntryAssignments_AspNetUsers_ApplicationUserId",
                        column: x => x.ApplicationUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EntryAssignments_DictionaryEntries_DictionaryEntryId",
                        column: x => x.DictionaryEntryId,
                        principalSchema: "mw",
                        principalTable: "DictionaryEntries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_EntryAssignments_ApplicationUserId",
                schema: "mw",
                table: "EntryAssignments",
                column: "ApplicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_EntryAssignments_DictionaryEntryId",
                schema: "mw",
                table: "EntryAssignments",
                column: "DictionaryEntryId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EntryAssignments",
                schema: "mw");
        }
    }
}
