using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace currency_api.Migrations
{
    public partial class InitialCreateAndSeed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Currencies",
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
                    Code = table.Column<string>(fixedLength: true, maxLength: 3, nullable: false),
                    Description = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Currencies", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CurrencyRates",
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
                    BaseCurrencyId = table.Column<long>(nullable: false),
                    TargetCurrencyId = table.Column<long>(nullable: false),
                    Rate = table.Column<decimal>(nullable: false, type: "decimal(18, 10)")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CurrencyRates", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CurrencyRates_Currencies_BaseCurrencyId",
                        column: x => x.BaseCurrencyId,
                        principalTable: "Currencies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CurrencyRates_Currencies_TargetCurrencyId",
                        column: x => x.TargetCurrencyId,
                        principalTable: "Currencies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });



            migrationBuilder.CreateIndex(
                name: "IX_Currencies_Code",
                table: "Currencies",
                column: "Code",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_CurrencyRates_TargetCurrencyId",
                table: "CurrencyRates",
                column: "TargetCurrencyId");

            migrationBuilder.CreateIndex(
                name: "IX_CurrencyRates_BaseCurrencyId_TargetCurrencyId",
                table: "CurrencyRates",
                columns: new[] { "BaseCurrencyId", "TargetCurrencyId" },
                unique: true);

            migrationBuilder.InsertData(
                table: "Currencies",
                columns: new[] { "Id", "Code", "CreatedAt", "CreatedByUser", "Description", "IsActive", "IsDeleted", "UpdatedAt", "UpdatedByUser" },
                values: new object[,]
                {
                    { 1L, "EUR", new DateTime(2020, 3, 25, 15, 18, 57, 559, DateTimeKind.Utc).AddTicks(1978), null, "Euro", true, false, null, null },
                    { 2L, "USD", new DateTime(2020, 3, 25, 15, 18, 57, 559, DateTimeKind.Utc).AddTicks(3167), null, "US Dollar", true, false, null, null },
                    { 3L, "CHF", new DateTime(2020, 3, 25, 15, 18, 57, 559, DateTimeKind.Utc).AddTicks(3205), null, "Swiss Franc", true, false, null, null },
                    { 4L, "GBP", new DateTime(2020, 3, 25, 15, 18, 57, 559, DateTimeKind.Utc).AddTicks(3207), null, "British Pound", true, false, null, null },
                    { 5L, "JPY", new DateTime(2020, 3, 25, 15, 18, 57, 559, DateTimeKind.Utc).AddTicks(3306), null, "Japan Yen", true, false, null, null },
                    { 6L, "CAD", new DateTime(2020, 3, 25, 15, 18, 57, 559, DateTimeKind.Utc).AddTicks(3308), null, "Canadian Dollar", true, false, null, null }
                });

            migrationBuilder.InsertData(
                table: "CurrencyRates",
                columns: new[] { "Id", "BaseCurrencyId", "CreatedAt", "CreatedByUser", "IsActive", "IsDeleted", "Rate", "TargetCurrencyId", "UpdatedAt", "UpdatedByUser" },
                values: new object[,]
                {
                    { 1L, 1L, new DateTime(2020, 3, 25, 15, 18, 57, 560, DateTimeKind.Utc).AddTicks(7545), null, true, false, 1.3764m, 2L, null, null },
                    { 2L, 1L, new DateTime(2020, 3, 25, 15, 18, 57, 560, DateTimeKind.Utc).AddTicks(7618), null, true, false, 1.2079m, 3L, null, null },
                    { 5L, 3L, new DateTime(2020, 3, 25, 15, 18, 57, 560, DateTimeKind.Utc).AddTicks(7624), null, true, false, 1.1379m, 2L, null, null },
                    { 3L, 1L, new DateTime(2020, 3, 25, 15, 18, 57, 560, DateTimeKind.Utc).AddTicks(7621), null, true, false, 0.8731m, 4L, null, null },
                    { 4L, 2L, new DateTime(2020, 3, 25, 15, 18, 57, 560, DateTimeKind.Utc).AddTicks(7623), null, true, false, 76.7200m, 5L, null, null },
                    { 6L, 4L, new DateTime(2020, 3, 25, 15, 18, 57, 560, DateTimeKind.Utc).AddTicks(7626), null, true, false, 1.5648m, 6L, null, null }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CurrencyRates");

            migrationBuilder.DropTable(
                name: "Currencies");
        }
    }
}
