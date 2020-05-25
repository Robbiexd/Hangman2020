using Microsoft.EntityFrameworkCore.Migrations;

namespace Hangman2020.Data.Migrations
{
    public partial class GuessedWord : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GuessedWords_AspNetUsers_UserId",
                table: "GuessedWords");

            migrationBuilder.DropPrimaryKey(
                name: "PK_GuessedWords",
                table: "GuessedWords");

            migrationBuilder.DropIndex(
                name: "IX_GuessedWords_WordId",
                table: "GuessedWords");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "GuessedWords",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "GuessedWords",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_GuessedWords",
                table: "GuessedWords",
                columns: new[] { "WordId", "UserId" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "user1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "f3b772c3-b723-4968-8662-aa5cbfa28705", "AQAAAAEAACcQAAAAEBMs0l7WttotOERAS8wCBlmXdlysSqQVEJvRCZ8PH4/nT1PUyr/Y5Q66DTvB2Yeoyg==" });

            migrationBuilder.AddForeignKey(
                name: "FK_GuessedWords_AspNetUsers_UserId",
                table: "GuessedWords",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GuessedWords_AspNetUsers_UserId",
                table: "GuessedWords");

            migrationBuilder.DropPrimaryKey(
                name: "PK_GuessedWords",
                table: "GuessedWords");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "GuessedWords",
                type: "int",
                nullable: false,
                oldClrType: typeof(int))
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "GuessedWords",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AddPrimaryKey(
                name: "PK_GuessedWords",
                table: "GuessedWords",
                column: "Id");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "user1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "e8d19e01-dcfd-4d10-b05b-e0498036bab6", "AQAAAAEAACcQAAAAEOqUqaC3ZbsIepHIycY5aBcmAt5ihJN19ZpJ/MtOwT+AVTfkQRHdMxMP970icdmifQ==" });

            migrationBuilder.CreateIndex(
                name: "IX_GuessedWords_WordId",
                table: "GuessedWords",
                column: "WordId");

            migrationBuilder.AddForeignKey(
                name: "FK_GuessedWords_AspNetUsers_UserId",
                table: "GuessedWords",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
