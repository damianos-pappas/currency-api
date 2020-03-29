using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace currency_api.Migrations
{
    public partial class SeedUserPasswordsHashed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {


            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "CreatedAt", "PasswordHash" },
                values: new object[] { new DateTime(2020, 3, 29, 12, 55, 5, 217, DateTimeKind.Utc).AddTicks(4587), "fGt1vKQUR082ue1S9ZKG5w==" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2L,
                columns: new[] { "CreatedAt", "PasswordHash" },
                values: new object[] { new DateTime(2020, 3, 29, 12, 55, 5, 219, DateTimeKind.Utc).AddTicks(6860), "nsoIb8ZBL/MwmYsc7adypQ==" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
        }
    }
}
