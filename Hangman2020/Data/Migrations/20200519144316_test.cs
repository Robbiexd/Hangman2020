using Microsoft.EntityFrameworkCore.Migrations;

namespace Hangman2020.Data.Migrations
{
    public partial class test : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "IdentityRole<string>");

            migrationBuilder.DropColumn(
                name: "UsedId",
                table: "GuessedWords");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "AspNetUsers");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "user1",
                columns: new[] { "ConcurrencyStamp", "EmailConfirmed", "NormalizedUserName", "PasswordHash", "UserName" },
                values: new object[] { "4f1e9373-1746-4cad-bcda-089ede04cc28", true, "PLAYER1@PSLIB.CZ", "AQAAAAEAACcQAAAAELuuEytAk9FkD8D0+vhW/rgcbyWwl+yQwTNcoaKsPI19bSHwPJgizUYehhC+SUdO+Q==", "player1@pslib.cz" });

            migrationBuilder.InsertData(
                table: "Words",
                columns: new[] { "Id", "CategoryId", "Text" },
                values: new object[,]
                {
                    { 5, 1, "react" },
                    { 6, 2, "xamarin" },
                    { 7, 2, "c#" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Words",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Words",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Words",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.AddColumn<int>(
                name: "UsedId",
                table: "GuessedWords",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "IdentityRole<string>",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IdentityRole<string>", x => x.Id);
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "user1",
                columns: new[] { "ConcurrencyStamp", "Discriminator", "EmailConfirmed", "NormalizedUserName", "PasswordHash", "UserName" },
                values: new object[] { "85f2097e-6aba-4f5f-afac-8a0dfd27167c", "User", false, "PLAYER1", "AQAAAAEAACcQAAAAEC15nD5MWoThPz8mcvF/N1/6+ChXypQyIkiiQDlxeXpvSNlApymppxjsBw/EC0reiQ==", "player1" });

            migrationBuilder.InsertData(
                table: "IdentityRole<string>",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "user1", "78db2a37-b27d-4011-92aa-702c607563aa", "Player1", "PLAYER1" });
        }
    }
}
