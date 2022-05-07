using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Banco.Data.Migrations
{
    public partial class usuarioAdm : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "99999",
                column: "ConcurrencyStamp",
                value: "d3218b66-cee5-4e9b-8678-e275e2b58496");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "99999",
                columns: new[] { "ConcurrencyStamp", "NormalizedUserName", "PasswordHash", "SecurityStamp", "UserName" },
                values: new object[] { "8ad2a959-a528-42f1-a47c-d62b8f149597", "ADMIN@ADMIN.COM", "AQAAAAEAACcQAAAAEIQgy/pQ8tNvwqyCEXKcResCI3zW9/gryP6auilogEa1gYwKbqGD9Mow2u0HkyLGbw==", "ea1e60df-c2c7-4f93-afca-c72ad619af9f", "admin@admin.com" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "99999",
                column: "ConcurrencyStamp",
                value: "deb3d1af-0bfc-46a9-94f6-65cd69bca056");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "99999",
                columns: new[] { "ConcurrencyStamp", "NormalizedUserName", "PasswordHash", "SecurityStamp", "UserName" },
                values: new object[] { "b17733e0-e040-4ebd-b874-129d0b51d7a3", "ADMIN", "AQAAAAEAACcQAAAAENk6EAkTHuCwE6AfB95XWnGCGa/G+9o5yekOphEThTqIJtPcLhR9WJVnObhF7e/ZBw==", "1f77c338-79d4-4717-a46d-ed5e5d15f32b", "admin" });
        }
    }
}
