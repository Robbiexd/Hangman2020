using Microsoft.EntityFrameworkCore.Migrations;

namespace Hangman2020.Migrations
{
    public partial class Final : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "user1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "c5ae606d-29b4-4b96-a341-c54a58cf55f8", "AQAAAAEAACcQAAAAENpmRk4YL4Qp+ETbxzycjUHvb90J0dt7ANmMP4rCYLKgP7QalNbhEzCwdAX3DEA+Vg==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "user2",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "9f0ffc78-623f-4abb-b332-36cfa7281174", "AQAAAAEAACcQAAAAEDxExnzhZSlh8BPfXESJdyhC1lUov+Hd3l86OonzLDL6765QojF8WHakSJ2ZnwO0Kw==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "user3",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "fdf0fcf0-0c60-42d3-ab8c-ffd4359f7742", "AQAAAAEAACcQAAAAEKSDd5a7FQqS3OKbzywEn8WVtuc5Go0STSpI7kcqLX2OQDPmh1nmLDIkUr+ZbNSqmA==" });

            migrationBuilder.UpdateData(
                table: "Words",
                keyColumn: "Id",
                keyValue: 2,
                column: "Text",
                value: "DependencyInjection");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "user1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "fc88a440-d3fa-4bec-8306-8eb98089da92", "AQAAAAEAACcQAAAAEG2mJ8SfG7DbcPmodjT0uExxPnyIKXrwFXvdxbcrTZTpZfIRSBwyUir4iK8fFkOIwg==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "user2",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "3dbeb2f4-49bd-4e1b-bd42-d5ea1d494ec3", "AQAAAAEAACcQAAAAECpOSmgMUiUHp/V+RWorI4FDuFINNzpILJsYQKDSrkJFmf+LAu8zfX5scUjKHek3gQ==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "user3",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "0f6662a8-0976-4fdb-9c04-67f76a97863f", "AQAAAAEAACcQAAAAEDhjNmoDW4wwPRzplOpHeHa65fY4F+p0Qk3lBEOaq/YXqjqjXZnPbGYPpEkzP7hASg==" });

            migrationBuilder.UpdateData(
                table: "Words",
                keyColumn: "Id",
                keyValue: 2,
                column: "Text",
                value: "Dependency Injection");
        }
    }
}
