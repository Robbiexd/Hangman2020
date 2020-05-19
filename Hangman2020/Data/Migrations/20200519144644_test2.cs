using Microsoft.EntityFrameworkCore.Migrations;

namespace Hangman2020.Data.Migrations
{
    public partial class test2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "AspNetUsers",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "user1",
                columns: new[] { "ConcurrencyStamp", "Discriminator", "PasswordHash" },
                values: new object[] { "e8d19e01-dcfd-4d10-b05b-e0498036bab6", "User", "AQAAAAEAACcQAAAAEOqUqaC3ZbsIepHIycY5aBcmAt5ihJN19ZpJ/MtOwT+AVTfkQRHdMxMP970icdmifQ==" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "AspNetUsers");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "user1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "4f1e9373-1746-4cad-bcda-089ede04cc28", "AQAAAAEAACcQAAAAELuuEytAk9FkD8D0+vhW/rgcbyWwl+yQwTNcoaKsPI19bSHwPJgizUYehhC+SUdO+Q==" });
        }
    }
}
