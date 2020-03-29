using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace currency_api.Migrations
{
    public partial class SeedUserRolesData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "UserRoles",
                columns: new[] { "Id", "Description" },
                values: new object[,]
                {
                    { 4L, "admin-users" },
                    { 3L, "admin-rates" },
                    { 2L, "admin-currencies" },
                    { 1L, "user" }
                });

            migrationBuilder.InsertData(
                table: "UserRoleRelations",
                columns: new[] { "Id", "CreatedAt", "CreatedByUser", "IsActive", "IsDeleted", "RoleId", "UpdatedAt", "UpdatedByUser", "UserId" },
                values: new object[,]
                {
                    { 1L, new DateTime(2020, 3, 29, 12, 18, 45, 764, DateTimeKind.Utc).AddTicks(1287), null, true, false, 1L, null, null, 1L },
                    { 2L, new DateTime(2020, 3, 29, 12, 18, 45, 764, DateTimeKind.Utc).AddTicks(1335), null, true, false, 1L, null, null, 2L },
                    { 3L, new DateTime(2020, 3, 29, 12, 18, 45, 764, DateTimeKind.Utc).AddTicks(1337), null, true, false, 2L, null, null, 2L },
                    { 4L, new DateTime(2020, 3, 29, 12, 18, 45, 764, DateTimeKind.Utc).AddTicks(1339), null, true, false, 3L, null, null, 2L },
                    { 5L, new DateTime(2020, 3, 29, 12, 18, 45, 764, DateTimeKind.Utc).AddTicks(1340), null, true, false, 4L, null, null, 2L }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "UserRoleRelations",
                keyColumn: "Id",
                keyValue: 1L);

            migrationBuilder.DeleteData(
                table: "UserRoleRelations",
                keyColumn: "Id",
                keyValue: 2L);

            migrationBuilder.DeleteData(
                table: "UserRoleRelations",
                keyColumn: "Id",
                keyValue: 3L);

            migrationBuilder.DeleteData(
                table: "UserRoleRelations",
                keyColumn: "Id",
                keyValue: 4L);

            migrationBuilder.DeleteData(
                table: "UserRoleRelations",
                keyColumn: "Id",
                keyValue: 5L);

            migrationBuilder.DeleteData(
                table: "UserRoles",
                keyColumn: "Id",
                keyValue: 1L);

            migrationBuilder.DeleteData(
                table: "UserRoles",
                keyColumn: "Id",
                keyValue: 2L);

            migrationBuilder.DeleteData(
                table: "UserRoles",
                keyColumn: "Id",
                keyValue: 3L);

            migrationBuilder.DeleteData(
                table: "UserRoles",
                keyColumn: "Id",
                keyValue: 4L);
        }
    }
}
