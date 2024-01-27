using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SmilyAccountant.Migrations
{
    /// <inheritdoc />
    public partial class AddingGeneralJournalsandBankAccounts : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BankAccounts",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    No = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BranchNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BankAccountNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Balance = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Blocked = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BankAccounts", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "GeneralJournals",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PostingDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DocumentType = table.Column<int>(type: "int", nullable: false),
                    DocumentNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BankAccountId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CurrencyId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    GeneralPostingType = table.Column<int>(type: "int", nullable: false),
                    Amount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    AmountWithTax = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Comment = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GeneralJournals", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_GLAccountCards_AccountCategoryId",
                table: "GLAccountCards",
                column: "AccountCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_GLAccountCards_AccountSubCategoryId",
                table: "GLAccountCards",
                column: "AccountSubCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_GLAccountCards_AccountTypeId",
                table: "GLAccountCards",
                column: "AccountTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_GLAccountCards_AccountCategories_AccountCategoryId",
                table: "GLAccountCards",
                column: "AccountCategoryId",
                principalTable: "AccountCategories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_GLAccountCards_AccountSubCategories_AccountSubCategoryId",
                table: "GLAccountCards",
                column: "AccountSubCategoryId",
                principalTable: "AccountSubCategories",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_GLAccountCards_AccountTypes_AccountTypeId",
                table: "GLAccountCards",
                column: "AccountTypeId",
                principalTable: "AccountTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GLAccountCards_AccountCategories_AccountCategoryId",
                table: "GLAccountCards");

            migrationBuilder.DropForeignKey(
                name: "FK_GLAccountCards_AccountSubCategories_AccountSubCategoryId",
                table: "GLAccountCards");

            migrationBuilder.DropForeignKey(
                name: "FK_GLAccountCards_AccountTypes_AccountTypeId",
                table: "GLAccountCards");

            migrationBuilder.DropTable(
                name: "BankAccounts");

            migrationBuilder.DropTable(
                name: "GeneralJournals");

            migrationBuilder.DropIndex(
                name: "IX_GLAccountCards_AccountCategoryId",
                table: "GLAccountCards");

            migrationBuilder.DropIndex(
                name: "IX_GLAccountCards_AccountSubCategoryId",
                table: "GLAccountCards");

            migrationBuilder.DropIndex(
                name: "IX_GLAccountCards_AccountTypeId",
                table: "GLAccountCards");
        }
    }
}
