using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace currency_api.Migrations
{
    public partial class UserModelFixesAndSeed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LockoutEnd",
                table: "Users"
              );

            migrationBuilder.AddColumn<DateTime>(
                name: "LockoutEnd",
                table: "Users",
                nullable: true
               );

            migrationBuilder.AlterColumn<int>(
                name: "AccessFailedCount",
                table: "Users",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AddColumn<string>(
                name: "PasswordHash",
                table: "Users",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Currencies",
                keyColumn: "Id",
                keyValue: 1L,
                column: "CreatedAt",
                value: new DateTime(2020, 3, 25, 19, 54, 39, 955, DateTimeKind.Utc).AddTicks(5071));

            migrationBuilder.UpdateData(
                table: "Currencies",
                keyColumn: "Id",
                keyValue: 2L,
                column: "CreatedAt",
                value: new DateTime(2020, 3, 25, 19, 54, 39, 955, DateTimeKind.Utc).AddTicks(5131));

            migrationBuilder.UpdateData(
                table: "Currencies",
                keyColumn: "Id",
                keyValue: 3L,
                column: "CreatedAt",
                value: new DateTime(2020, 3, 25, 19, 54, 39, 955, DateTimeKind.Utc).AddTicks(5133));

            migrationBuilder.UpdateData(
                table: "Currencies",
                keyColumn: "Id",
                keyValue: 4L,
                column: "CreatedAt",
                value: new DateTime(2020, 3, 25, 19, 54, 39, 955, DateTimeKind.Utc).AddTicks(5135));

            migrationBuilder.UpdateData(
                table: "Currencies",
                keyColumn: "Id",
                keyValue: 5L,
                column: "CreatedAt",
                value: new DateTime(2020, 3, 25, 19, 54, 39, 955, DateTimeKind.Utc).AddTicks(5136));

            migrationBuilder.UpdateData(
                table: "Currencies",
                keyColumn: "Id",
                keyValue: 6L,
                column: "CreatedAt",
                value: new DateTime(2020, 3, 25, 19, 54, 39, 955, DateTimeKind.Utc).AddTicks(5138));

            migrationBuilder.UpdateData(
                table: "CurrencyRates",
                keyColumn: "Id",
                keyValue: 1L,
                column: "CreatedAt",
                value: new DateTime(2020, 3, 25, 19, 54, 39, 955, DateTimeKind.Utc).AddTicks(6848));

            migrationBuilder.UpdateData(
                table: "CurrencyRates",
                keyColumn: "Id",
                keyValue: 2L,
                column: "CreatedAt",
                value: new DateTime(2020, 3, 25, 19, 54, 39, 955, DateTimeKind.Utc).AddTicks(6919));

            migrationBuilder.UpdateData(
                table: "CurrencyRates",
                keyColumn: "Id",
                keyValue: 3L,
                column: "CreatedAt",
                value: new DateTime(2020, 3, 25, 19, 54, 39, 955, DateTimeKind.Utc).AddTicks(6921));

            migrationBuilder.UpdateData(
                table: "CurrencyRates",
                keyColumn: "Id",
                keyValue: 4L,
                column: "CreatedAt",
                value: new DateTime(2020, 3, 25, 19, 54, 39, 955, DateTimeKind.Utc).AddTicks(6923));

            migrationBuilder.UpdateData(
                table: "CurrencyRates",
                keyColumn: "Id",
                keyValue: 5L,
                column: "CreatedAt",
                value: new DateTime(2020, 3, 25, 19, 54, 39, 955, DateTimeKind.Utc).AddTicks(6924));

            migrationBuilder.UpdateData(
                table: "CurrencyRates",
                keyColumn: "Id",
                keyValue: 6L,
                column: "CreatedAt",
                value: new DateTime(2020, 3, 25, 19, 54, 39, 955, DateTimeKind.Utc).AddTicks(6926));

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "AccessFailedCount", "CreatedAt", "CreatedByUser", "Email", "IsActive", "IsDeleted", "LockoutEnabled", "LockoutEnd", "PasswordHash", "UpdatedAt", "UpdatedByUser", "UserName" },
                values: new object[,]
                {
                    { 1L, 0, new DateTime(2020, 3, 25, 19, 54, 39, 953, DateTimeKind.Utc).AddTicks(9980), null, "user@currencies.cur", true, false, false, null, "xxx", null, null, "admin" },
                    { 2L, 0, new DateTime(2020, 3, 25, 19, 54, 39, 954, DateTimeKind.Utc).AddTicks(1223), null, "user@currencies.cur", true, false, false, null, "xxx", null, null, "user" }
                });
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

            migrationBuilder.DropColumn(
                name: "PasswordHash",
                table: "Users");

            migrationBuilder.AlterColumn<bool>(
                name: "LockoutEnd",
                table: "Users",
                type: "bit",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldNullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "AccessFailedCount",
                table: "Users",
                type: "bit",
                nullable: false,
                oldClrType: typeof(int));

            migrationBuilder.UpdateData(
                table: "Currencies",
                keyColumn: "Id",
                keyValue: 1L,
                column: "CreatedAt",
                value: new DateTime(2020, 3, 25, 19, 44, 58, 189, DateTimeKind.Utc).AddTicks(7648));

            migrationBuilder.UpdateData(
                table: "Currencies",
                keyColumn: "Id",
                keyValue: 2L,
                column: "CreatedAt",
                value: new DateTime(2020, 3, 25, 19, 44, 58, 189, DateTimeKind.Utc).AddTicks(9103));

            migrationBuilder.UpdateData(
                table: "Currencies",
                keyColumn: "Id",
                keyValue: 3L,
                column: "CreatedAt",
                value: new DateTime(2020, 3, 25, 19, 44, 58, 189, DateTimeKind.Utc).AddTicks(9147));

            migrationBuilder.UpdateData(
                table: "Currencies",
                keyColumn: "Id",
                keyValue: 4L,
                column: "CreatedAt",
                value: new DateTime(2020, 3, 25, 19, 44, 58, 189, DateTimeKind.Utc).AddTicks(9149));

            migrationBuilder.UpdateData(
                table: "Currencies",
                keyColumn: "Id",
                keyValue: 5L,
                column: "CreatedAt",
                value: new DateTime(2020, 3, 25, 19, 44, 58, 189, DateTimeKind.Utc).AddTicks(9150));

            migrationBuilder.UpdateData(
                table: "Currencies",
                keyColumn: "Id",
                keyValue: 6L,
                column: "CreatedAt",
                value: new DateTime(2020, 3, 25, 19, 44, 58, 189, DateTimeKind.Utc).AddTicks(9152));

            migrationBuilder.UpdateData(
                table: "CurrencyRates",
                keyColumn: "Id",
                keyValue: 1L,
                column: "CreatedAt",
                value: new DateTime(2020, 3, 25, 19, 44, 58, 191, DateTimeKind.Utc).AddTicks(4832));

            migrationBuilder.UpdateData(
                table: "CurrencyRates",
                keyColumn: "Id",
                keyValue: 2L,
                column: "CreatedAt",
                value: new DateTime(2020, 3, 25, 19, 44, 58, 191, DateTimeKind.Utc).AddTicks(4901));

            migrationBuilder.UpdateData(
                table: "CurrencyRates",
                keyColumn: "Id",
                keyValue: 3L,
                column: "CreatedAt",
                value: new DateTime(2020, 3, 25, 19, 44, 58, 191, DateTimeKind.Utc).AddTicks(4905));

            migrationBuilder.UpdateData(
                table: "CurrencyRates",
                keyColumn: "Id",
                keyValue: 4L,
                column: "CreatedAt",
                value: new DateTime(2020, 3, 25, 19, 44, 58, 191, DateTimeKind.Utc).AddTicks(4907));

            migrationBuilder.UpdateData(
                table: "CurrencyRates",
                keyColumn: "Id",
                keyValue: 5L,
                column: "CreatedAt",
                value: new DateTime(2020, 3, 25, 19, 44, 58, 191, DateTimeKind.Utc).AddTicks(4909));

            migrationBuilder.UpdateData(
                table: "CurrencyRates",
                keyColumn: "Id",
                keyValue: 6L,
                column: "CreatedAt",
                value: new DateTime(2020, 3, 25, 19, 44, 58, 191, DateTimeKind.Utc).AddTicks(4911));
        }
    }
}
