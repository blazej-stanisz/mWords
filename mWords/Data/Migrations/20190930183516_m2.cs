using Microsoft.EntityFrameworkCore.Migrations;

namespace mWords.Data.Migrations
{
    public partial class m2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Pronunciation",
                schema: "mw",
                table: "WordsDictionary",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Pronunciation",
                schema: "mw",
                table: "WordsDictionary");
        }
    }
}
