using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CRUDApplication.Server.Migrations
{
    public partial class AddMovie : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "MovieId",
                table: "SuperHeroes",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Movies",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Movies", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Movies",
                columns: new[] { "Id", "Name" },
                values: new object[] { 1, "Avengers End Game" });

            migrationBuilder.InsertData(
                table: "Movies",
                columns: new[] { "Id", "Name" },
                values: new object[] { 2, "Batman" });

            migrationBuilder.UpdateData(
                table: "SuperHeroes",
                keyColumn: "Id",
                keyValue: 1,
                column: "MovieId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "SuperHeroes",
                keyColumn: "Id",
                keyValue: 2,
                column: "MovieId",
                value: 1);

            migrationBuilder.CreateIndex(
                name: "IX_SuperHeroes_MovieId",
                table: "SuperHeroes",
                column: "MovieId");

            migrationBuilder.AddForeignKey(
                name: "FK_SuperHeroes_Movies_MovieId",
                table: "SuperHeroes",
                column: "MovieId",
                principalTable: "Movies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SuperHeroes_Movies_MovieId",
                table: "SuperHeroes");

            migrationBuilder.DropTable(
                name: "Movies");

            migrationBuilder.DropIndex(
                name: "IX_SuperHeroes_MovieId",
                table: "SuperHeroes");

            migrationBuilder.DropColumn(
                name: "MovieId",
                table: "SuperHeroes");
        }
    }
}
