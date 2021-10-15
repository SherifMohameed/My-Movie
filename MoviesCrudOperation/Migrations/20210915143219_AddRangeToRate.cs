using Microsoft.EntityFrameworkCore.Migrations;

namespace MoviesCrudOperation.Migrations
{
    public partial class AddRangeToRate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Movies_Geners_GenerId",
                table: "Movies");

            migrationBuilder.DropIndex(
                name: "IX_Movies_GenerId",
                table: "Movies");

            migrationBuilder.AddColumn<int>(
                name: "MovieId",
                table: "Geners",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Geners_MovieId",
                table: "Geners",
                column: "MovieId");

            migrationBuilder.AddForeignKey(
                name: "FK_Geners_Movies_MovieId",
                table: "Geners",
                column: "MovieId",
                principalTable: "Movies",
                principalColumn: "MovieId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Geners_Movies_MovieId",
                table: "Geners");

            migrationBuilder.DropIndex(
                name: "IX_Geners_MovieId",
                table: "Geners");

            migrationBuilder.DropColumn(
                name: "MovieId",
                table: "Geners");

            migrationBuilder.CreateIndex(
                name: "IX_Movies_GenerId",
                table: "Movies",
                column: "GenerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Movies_Geners_GenerId",
                table: "Movies",
                column: "GenerId",
                principalTable: "Geners",
                principalColumn: "GenerId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
