using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DreamJournal.Migrations
{
    public partial class DateUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Dreams");

            migrationBuilder.AddColumn<DateTime>(
                name: "Date",
                table: "Dreams",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Dreams",
                keyColumn: "DreamId",
                keyValue: 1,
                columns: new[] { "Date", "Title", "UserName" },
                values: new object[] { new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Example", "Frederick Ernest" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Date",
                table: "Dreams");

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "Dreams",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "Dreams",
                keyColumn: "DreamId",
                keyValue: 1,
                columns: new[] { "Title", "UserName" },
                values: new object[] { "Polar Bear in Thailand", null });
        }
    }
}
