using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace currency_api.Migrations
{
    public partial class changeSeededUserRoles : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {

            migrationBuilder.UpdateData(
                table: "UserRoleRelations",
                keyColumn: "Id",
                keyValue: 3L,
                columns: new[] { "CreatedAt", "UserId" },
                values: new object[] { new DateTime(2020, 3, 29, 19, 51, 8, 999, DateTimeKind.Utc).AddTicks(9426), 1L });

            migrationBuilder.UpdateData(
                table: "UserRoleRelations",
                keyColumn: "Id",
                keyValue: 4L,
                columns: new[] { "CreatedAt", "UserId" },
                values: new object[] { new DateTime(2020, 3, 29, 19, 51, 8, 999, DateTimeKind.Utc).AddTicks(9428), 1L });

            migrationBuilder.UpdateData(
                table: "UserRoleRelations",
                keyColumn: "Id",
                keyValue: 5L,
                columns: new[] { "CreatedAt", "UserId" },
                values: new object[] { new DateTime(2020, 3, 29, 19, 51, 8, 999, DateTimeKind.Utc).AddTicks(9429), 1L });

                      


        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
         
        }
    }
}
