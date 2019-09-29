using Microsoft.EntityFrameworkCore.Migrations;

namespace mWords.Data.Migrations
{
    public partial class m1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "mw");

            migrationBuilder.CreateTable(
                name: "WordsDictionary",
                schema: "mw",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    English = table.Column<string>(nullable: true),
                    Polish = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WordsDictionary", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "WordsDictionary",
                schema: "mw");
        }
    }
}
