using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SmilyAccountant.Migrations
{
    /// <inheritdoc />
    public partial class addingbankdeposits : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BankDeposits",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    BankAccountId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DepositAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    PostingDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BankDeposits", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BankDeposits_BankAccounts_BankAccountId",
                        column: x => x.BankAccountId,
                        principalTable: "BankAccounts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BankDeposits_BankAccountId",
                table: "BankDeposits",
                column: "BankAccountId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BankDeposits");
        }
    }
}
