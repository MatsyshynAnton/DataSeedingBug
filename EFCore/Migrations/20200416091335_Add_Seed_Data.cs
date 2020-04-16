using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EFCore.Migrations
{
    public partial class Add_Seed_Data : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Age", "Created", "FirstName", "LastName" },
                values: new object[] { 1L, 27, new DateTime(2020, 4, 16, 12, 13, 34, 841, DateTimeKind.Local).AddTicks(4524), "John", "Gold" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Age", "Created", "FirstName", "LastName" },
                values: new object[] { 2L, 16, new DateTime(2020, 4, 16, 12, 13, 34, 845, DateTimeKind.Local).AddTicks(126), "Ronald", "Weasley" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Age", "Created", "FirstName", "LastName" },
                values: new object[] { 3L, 18, new DateTime(2020, 4, 16, 12, 13, 34, 845, DateTimeKind.Local).AddTicks(199), "Sherlock ", "Holmes" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1L);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2L);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3L);
        }
    }
}
