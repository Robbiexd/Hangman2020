using Microsoft.EntityFrameworkCore.Migrations;

namespace Hangman2020.Data.Migrations
{
    public partial class MoreUsers : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Id",
                table: "GuessedWords");

            migrationBuilder.AddColumn<int>(
                name: "GuessedWordCount",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "user1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "acdaa5e5-907f-4925-ab84-de50074a69b5", "AQAAAAEAACcQAAAAEMkTbQWODmPFWGhH1NP8fnahK8zyioI5F8kRID7RsBkNbSEVXL4KiowWBsH52lqInQ==" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Discriminator", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName", "GuessedWordCount" },
                values: new object[,]
                {
                    { "user2", 0, "20fd1160-9ff1-4a81-beb3-15a9a76e26ef", "User", "player2@pslib.cz", true, true, null, "PLAYER2@PSLIB.CZ", "PLAYER2@PSLIB.CZ", "AQAAAAEAACcQAAAAECN/VD4X4ivYUecTdSwiIlf/ExYTBiPOZzZVP16QwBfApDsE+fA74NogCuyUS9FA/g==", null, false, "", false, "player2@pslib.cz", 0 },
                    { "user3", 0, "5893da62-7bc6-4952-a87c-f482ae8e5054", "User", "player3@pslib.cz", true, true, null, "PLAYER3@PSLIB.CZ", "PLAYER3@PSLIB.CZ", "AQAAAAEAACcQAAAAEALnjf1AjVMGY4eldnYLi/aYQxwTC3Ei0PUFnNLcZ9KigSfeUnvbJBUVW4WDPpEQ3w==", null, false, "", false, "player3@pslib.cz", 0 }
                });

            migrationBuilder.UpdateData(
                table: "Words",
                keyColumn: "Id",
                keyValue: 7,
                column: "Text",
                value: "python");

            migrationBuilder.InsertData(
                table: "Words",
                columns: new[] { "Id", "CategoryId", "Text" },
                values: new object[,]
                {
                    { 8, 2, "algoritmy" },
                    { 9, 2, "Java" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "user2");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "user3");

            migrationBuilder.DeleteData(
                table: "Words",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Words",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DropColumn(
                name: "GuessedWordCount",
                table: "AspNetUsers");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "GuessedWords",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "user1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "f3b772c3-b723-4968-8662-aa5cbfa28705", "AQAAAAEAACcQAAAAEBMs0l7WttotOERAS8wCBlmXdlysSqQVEJvRCZ8PH4/nT1PUyr/Y5Q66DTvB2Yeoyg==" });

            migrationBuilder.UpdateData(
                table: "Words",
                keyColumn: "Id",
                keyValue: 7,
                column: "Text",
                value: "c#");
        }
    }
}
