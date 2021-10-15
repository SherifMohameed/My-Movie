using Microsoft.EntityFrameworkCore.Migrations;

namespace MoviesCrudOperation.Migrations
{
    public partial class CorrectNameYear : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Yera",
                table: "Movies",
                newName: "Year");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Year",
                table: "Movies",
                newName: "Yera");
        }
    }
}
