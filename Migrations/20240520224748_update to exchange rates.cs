using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SmilyAccountant.Migrations
{
    /// <inheritdoc />
    public partial class updatetoexchangerates : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ExchangeRates_Currencies_CurrencyId",
                table: "ExchangeRates");

            migrationBuilder.RenameColumn(
                name: "CurrencyId",
                table: "ExchangeRates",
                newName: "ToCurrencyId");

            migrationBuilder.RenameIndex(
                name: "IX_ExchangeRates_CurrencyId",
                table: "ExchangeRates",
                newName: "IX_ExchangeRates_ToCurrencyId");

            migrationBuilder.AddColumn<Guid>(
                name: "FromCurrencyId",
                table: "ExchangeRates",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_ExchangeRates_FromCurrencyId",
                table: "ExchangeRates",
                column: "FromCurrencyId");

            migrationBuilder.AddForeignKey(
                name: "FK_ExchangeRates_Currencies_FromCurrencyId",
                table: "ExchangeRates",
                column: "FromCurrencyId",
                principalTable: "Currencies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ExchangeRates_Currencies_ToCurrencyId",
                table: "ExchangeRates",
                column: "ToCurrencyId",
                principalTable: "Currencies",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ExchangeRates_Currencies_FromCurrencyId",
                table: "ExchangeRates");

            migrationBuilder.DropForeignKey(
                name: "FK_ExchangeRates_Currencies_ToCurrencyId",
                table: "ExchangeRates");

            migrationBuilder.DropIndex(
                name: "IX_ExchangeRates_FromCurrencyId",
                table: "ExchangeRates");

            migrationBuilder.DropColumn(
                name: "FromCurrencyId",
                table: "ExchangeRates");

            migrationBuilder.RenameColumn(
                name: "ToCurrencyId",
                table: "ExchangeRates",
                newName: "CurrencyId");

            migrationBuilder.RenameIndex(
                name: "IX_ExchangeRates_ToCurrencyId",
                table: "ExchangeRates",
                newName: "IX_ExchangeRates_CurrencyId");

            migrationBuilder.AddForeignKey(
                name: "FK_ExchangeRates_Currencies_CurrencyId",
                table: "ExchangeRates",
                column: "CurrencyId",
                principalTable: "Currencies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
