using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace currency_api.Migrations
{
    public partial class AddedUserModels : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "UserRoles",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedAt = table.Column<DateTime>(nullable: true),
                    CreatedByUser = table.Column<string>(nullable: true),
                    UpdatedAt = table.Column<DateTime>(nullable: true),
                    UpdatedByUser = table.Column<string>(nullable: true),
                    IsActive = table.Column<bool>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false),
                    UserName = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    LockoutEnd = table.Column<bool>(nullable: false),
                    LockoutEnabled = table.Column<bool>(nullable: false),
                    AccessFailedCount = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UserRoleRelations",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedAt = table.Column<DateTime>(nullable: true),
                    CreatedByUser = table.Column<string>(nullable: true),
                    UpdatedAt = table.Column<DateTime>(nullable: true),
                    UpdatedByUser = table.Column<string>(nullable: true),
                    IsActive = table.Column<bool>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false),
                    UserId = table.Column<long>(nullable: false),
                    RoleId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserRoleRelations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserRoleRelations_UserRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "UserRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserRoleRelations_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

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

            migrationBuilder.CreateIndex(
                name: "IX_UserRoleRelations_RoleId",
                table: "UserRoleRelations",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_UserRoleRelations_UserId_RoleId",
                table: "UserRoleRelations",
                columns: new[] { "UserId", "RoleId" },
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserRoleRelations");

            migrationBuilder.DropTable(
                name: "UserRoles");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.UpdateData(
                table: "Currencies",
                keyColumn: "Id",
                keyValue: 1L,
                column: "CreatedAt",
                value: new DateTime(2020, 3, 25, 15, 18, 57, 559, DateTimeKind.Utc).AddTicks(1978));

            migrationBuilder.UpdateData(
                table: "Currencies",
                keyColumn: "Id",
                keyValue: 2L,
                column: "CreatedAt",
                value: new DateTime(2020, 3, 25, 15, 18, 57, 559, DateTimeKind.Utc).AddTicks(3167));

            migrationBuilder.UpdateData(
                table: "Currencies",
                keyColumn: "Id",
                keyValue: 3L,
                column: "CreatedAt",
                value: new DateTime(2020, 3, 25, 15, 18, 57, 559, DateTimeKind.Utc).AddTicks(3205));

            migrationBuilder.UpdateData(
                table: "Currencies",
                keyColumn: "Id",
                keyValue: 4L,
                column: "CreatedAt",
                value: new DateTime(2020, 3, 25, 15, 18, 57, 559, DateTimeKind.Utc).AddTicks(3207));

            migrationBuilder.UpdateData(
                table: "Currencies",
                keyColumn: "Id",
                keyValue: 5L,
                column: "CreatedAt",
                value: new DateTime(2020, 3, 25, 15, 18, 57, 559, DateTimeKind.Utc).AddTicks(3306));

            migrationBuilder.UpdateData(
                table: "Currencies",
                keyColumn: "Id",
                keyValue: 6L,
                column: "CreatedAt",
                value: new DateTime(2020, 3, 25, 15, 18, 57, 559, DateTimeKind.Utc).AddTicks(3308));

            migrationBuilder.UpdateData(
                table: "CurrencyRates",
                keyColumn: "Id",
                keyValue: 1L,
                column: "CreatedAt",
                value: new DateTime(2020, 3, 25, 15, 18, 57, 560, DateTimeKind.Utc).AddTicks(7545));

            migrationBuilder.UpdateData(
                table: "CurrencyRates",
                keyColumn: "Id",
                keyValue: 2L,
                column: "CreatedAt",
                value: new DateTime(2020, 3, 25, 15, 18, 57, 560, DateTimeKind.Utc).AddTicks(7618));

            migrationBuilder.UpdateData(
                table: "CurrencyRates",
                keyColumn: "Id",
                keyValue: 3L,
                column: "CreatedAt",
                value: new DateTime(2020, 3, 25, 15, 18, 57, 560, DateTimeKind.Utc).AddTicks(7621));

            migrationBuilder.UpdateData(
                table: "CurrencyRates",
                keyColumn: "Id",
                keyValue: 4L,
                column: "CreatedAt",
                value: new DateTime(2020, 3, 25, 15, 18, 57, 560, DateTimeKind.Utc).AddTicks(7623));

            migrationBuilder.UpdateData(
                table: "CurrencyRates",
                keyColumn: "Id",
                keyValue: 5L,
                column: "CreatedAt",
                value: new DateTime(2020, 3, 25, 15, 18, 57, 560, DateTimeKind.Utc).AddTicks(7624));

            migrationBuilder.UpdateData(
                table: "CurrencyRates",
                keyColumn: "Id",
                keyValue: 6L,
                column: "CreatedAt",
                value: new DateTime(2020, 3, 25, 15, 18, 57, 560, DateTimeKind.Utc).AddTicks(7626));
        }
    }
}
