using Microsoft.EntityFrameworkCore.Migrations;

namespace Demo1.Data.Migrations
{
    public partial class DeletedSeedData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2d75a795-bf21-41c5-b480-eb95c5d41499");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f0e26d17-6c9c-44d0-a4da-d5eb289de8e9");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "f0e26d17-6c9c-44d0-a4da-d5eb289de8e9", "2e409de6-3e7e-4ea1-899b-0bf0b7042bd6", "HR", null });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "2d75a795-bf21-41c5-b480-eb95c5d41499", "b9197053-eadf-47bb-a7f4-476cf3c65bd2", "Employee", null });
        }
    }
}
