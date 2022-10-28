using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MovieRecommender2022.Data.Migrations
{
    public partial class KeywordsAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Keyword_Movies_MovieId",
                table: "Keyword");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Keyword",
                table: "Keyword");

            migrationBuilder.RenameTable(
                name: "Keyword",
                newName: "Keywords");

            migrationBuilder.RenameIndex(
                name: "IX_Keyword_MovieId",
                table: "Keywords",
                newName: "IX_Keywords_MovieId");

            migrationBuilder.AlterColumn<string>(
                name: "Title",
                table: "Movies",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Value",
                table: "Keywords",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Keywords",
                table: "Keywords",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Keywords_Movies_MovieId",
                table: "Keywords",
                column: "MovieId",
                principalTable: "Movies",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Keywords_Movies_MovieId",
                table: "Keywords");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Keywords",
                table: "Keywords");

            migrationBuilder.RenameTable(
                name: "Keywords",
                newName: "Keyword");

            migrationBuilder.RenameIndex(
                name: "IX_Keywords_MovieId",
                table: "Keyword",
                newName: "IX_Keyword_MovieId");

            migrationBuilder.AlterColumn<string>(
                name: "Title",
                table: "Movies",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(20)",
                oldMaxLength: 20);

            migrationBuilder.AlterColumn<string>(
                name: "Value",
                table: "Keyword",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Keyword",
                table: "Keyword",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Keyword_Movies_MovieId",
                table: "Keyword",
                column: "MovieId",
                principalTable: "Movies",
                principalColumn: "Id");
        }
    }
}
