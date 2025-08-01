using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace app.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CashWithdrawals",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    TripId = table.Column<Guid>(type: "TEXT", nullable: false),
                    CustomerId = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    Amount = table.Column<decimal>(type: "TEXT", precision: 18, scale: 2, nullable: false),
                    Currency = table.Column<string>(type: "TEXT", maxLength: 3, nullable: false),
                    DateTime = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Location = table.Column<string>(type: "TEXT", maxLength: 500, nullable: false),
                    ATMDeviceOwner = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    ATMDeviceId = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    Fee = table.Column<decimal>(type: "TEXT", precision: 18, scale: 2, nullable: false),
                    Status = table.Column<int>(type: "INTEGER", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "TEXT", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "TEXT", nullable: false),
                    LocalAmount = table.Column<decimal>(type: "TEXT", precision: 18, scale: 2, nullable: true),
                    LocalCurrency = table.Column<string>(type: "TEXT", maxLength: 3, nullable: true),
                    ExchangeRate = table.Column<decimal>(type: "TEXT", precision: 18, scale: 6, nullable: true),
                    TransactionReference = table.Column<string>(type: "TEXT", maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CashWithdrawals", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Spendings",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    TripId = table.Column<Guid>(type: "TEXT", nullable: false),
                    CustomerId = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    Amount = table.Column<decimal>(type: "TEXT", precision: 18, scale: 2, nullable: false),
                    Currency = table.Column<string>(type: "TEXT", maxLength: 3, nullable: false),
                    DateTime = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Location = table.Column<string>(type: "TEXT", maxLength: 500, nullable: false),
                    MCC = table.Column<string>(type: "TEXT", maxLength: 10, nullable: false),
                    MerchantName = table.Column<string>(type: "TEXT", maxLength: 200, nullable: false),
                    Description = table.Column<string>(type: "TEXT", maxLength: 1000, nullable: false),
                    PaymentMethod = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    Status = table.Column<int>(type: "INTEGER", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "TEXT", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "TEXT", nullable: false),
                    ReceiptUrl = table.Column<string>(type: "TEXT", maxLength: 1000, nullable: true),
                    LocalAmount = table.Column<decimal>(type: "TEXT", precision: 18, scale: 2, nullable: true),
                    LocalCurrency = table.Column<string>(type: "TEXT", maxLength: 3, nullable: true),
                    ExchangeRate = table.Column<decimal>(type: "TEXT", precision: 18, scale: 6, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Spendings", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CashWithdrawals_CustomerId",
                table: "CashWithdrawals",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_CashWithdrawals_DateTime",
                table: "CashWithdrawals",
                column: "DateTime");

            migrationBuilder.CreateIndex(
                name: "IX_CashWithdrawals_TripId",
                table: "CashWithdrawals",
                column: "TripId");

            migrationBuilder.CreateIndex(
                name: "IX_Spendings_CustomerId",
                table: "Spendings",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_Spendings_DateTime",
                table: "Spendings",
                column: "DateTime");

            migrationBuilder.CreateIndex(
                name: "IX_Spendings_TripId",
                table: "Spendings",
                column: "TripId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CashWithdrawals");

            migrationBuilder.DropTable(
                name: "Spendings");
        }
    }
}
