using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SmilyAccountant.Migrations
{
    /// <inheritdoc />
    public partial class Freshnewmigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AccountCategories",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AccountCategories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AccountTypes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AccountTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BankAccounts",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    No = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BranchNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BankAccountNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Balance = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Blocked = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BankAccounts", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Countries",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Countries", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    EmployeeNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MiddleName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    JobTitle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Initials = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Gender = table.Column<int>(type: "int", nullable: false),
                    CompanyEmail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CompanyPhone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Extension = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PrivateEmail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PrivatePhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Address2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CountryId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Region = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PostalCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EmployementDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EmploymenetStatus = table.Column<int>(type: "int", nullable: false),
                    InactiveDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TerminationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    BirthDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SSN = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BankBranchNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BankAccountNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IBAN = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SwiftCode = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AccountSubCategories",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AccountCategoryId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AccountSubCategories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AccountSubCategories_AccountCategories_AccountCategoryId",
                        column: x => x.AccountCategoryId,
                        principalTable: "AccountCategories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "GLAccountCards",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AccountNo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AccountName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Balance = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    AccountCategoryId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AccountSubCategoryId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AccountTypeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DebitCredit = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GLAccountCards", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GLAccountCards_AccountCategories_AccountCategoryId",
                        column: x => x.AccountCategoryId,
                        principalTable: "AccountCategories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GLAccountCards_AccountSubCategories_AccountSubCategoryId",
                        column: x => x.AccountSubCategoryId,
                        principalTable: "AccountSubCategories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_GLAccountCards_AccountTypes_AccountTypeId",
                        column: x => x.AccountTypeId,
                        principalTable: "AccountTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Currencies",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    GeneralJournalId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Currencies", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FAClassCodes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FixedAssetCardId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FAClassCodes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FASubClassCodes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FAClassCodeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FixedAssetCardId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FASubClassCodes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FASubClassCodes_FAClassCodes_FAClassCodeId",
                        column: x => x.FAClassCodeId,
                        principalTable: "FAClassCodes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FixedAssetCards",
                columns: table => new
                {
                    FixedAssetCardId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FAClassCodeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FASubClassCodeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SerialNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EmployeeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    GeneralJournalId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FixedAssetCards", x => x.FixedAssetCardId);
                });

            migrationBuilder.CreateTable(
                name: "GeneralJournals",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PostingDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DocumentType = table.Column<int>(type: "int", nullable: true),
                    DocumentNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FixedAssetCardId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CurrencyId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    GeneralPostingType = table.Column<int>(type: "int", nullable: false),
                    Amount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    AmountWithTax = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Comment = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GeneralJournals", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GeneralJournals_Currencies_CurrencyId",
                        column: x => x.CurrencyId,
                        principalTable: "Currencies",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_GeneralJournals_FixedAssetCards_FixedAssetCardId",
                        column: x => x.FixedAssetCardId,
                        principalTable: "FixedAssetCards",
                        principalColumn: "FixedAssetCardId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AccountSubCategories_AccountCategoryId",
                table: "AccountSubCategories",
                column: "AccountCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Currencies_GeneralJournalId",
                table: "Currencies",
                column: "GeneralJournalId");

            migrationBuilder.CreateIndex(
                name: "IX_FAClassCodes_FixedAssetCardId",
                table: "FAClassCodes",
                column: "FixedAssetCardId");

            migrationBuilder.CreateIndex(
                name: "IX_FASubClassCodes_FAClassCodeId",
                table: "FASubClassCodes",
                column: "FAClassCodeId");

            migrationBuilder.CreateIndex(
                name: "IX_FASubClassCodes_FixedAssetCardId",
                table: "FASubClassCodes",
                column: "FixedAssetCardId");

            migrationBuilder.CreateIndex(
                name: "IX_FixedAssetCards_GeneralJournalId",
                table: "FixedAssetCards",
                column: "GeneralJournalId");

            migrationBuilder.CreateIndex(
                name: "IX_GeneralJournals_CurrencyId",
                table: "GeneralJournals",
                column: "CurrencyId");

            migrationBuilder.CreateIndex(
                name: "IX_GeneralJournals_FixedAssetCardId",
                table: "GeneralJournals",
                column: "FixedAssetCardId");

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
                name: "FK_Currencies_GeneralJournals_GeneralJournalId",
                table: "Currencies",
                column: "GeneralJournalId",
                principalTable: "GeneralJournals",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_FAClassCodes_FixedAssetCards_FixedAssetCardId",
                table: "FAClassCodes",
                column: "FixedAssetCardId",
                principalTable: "FixedAssetCards",
                principalColumn: "FixedAssetCardId");

            migrationBuilder.AddForeignKey(
                name: "FK_FASubClassCodes_FixedAssetCards_FixedAssetCardId",
                table: "FASubClassCodes",
                column: "FixedAssetCardId",
                principalTable: "FixedAssetCards",
                principalColumn: "FixedAssetCardId");

            migrationBuilder.AddForeignKey(
                name: "FK_FixedAssetCards_GeneralJournals_GeneralJournalId",
                table: "FixedAssetCards",
                column: "GeneralJournalId",
                principalTable: "GeneralJournals",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Currencies_GeneralJournals_GeneralJournalId",
                table: "Currencies");

            migrationBuilder.DropForeignKey(
                name: "FK_FixedAssetCards_GeneralJournals_GeneralJournalId",
                table: "FixedAssetCards");

            migrationBuilder.DropTable(
                name: "BankAccounts");

            migrationBuilder.DropTable(
                name: "Countries");

            migrationBuilder.DropTable(
                name: "Employees");

            migrationBuilder.DropTable(
                name: "FASubClassCodes");

            migrationBuilder.DropTable(
                name: "GLAccountCards");

            migrationBuilder.DropTable(
                name: "FAClassCodes");

            migrationBuilder.DropTable(
                name: "AccountSubCategories");

            migrationBuilder.DropTable(
                name: "AccountTypes");

            migrationBuilder.DropTable(
                name: "AccountCategories");

            migrationBuilder.DropTable(
                name: "GeneralJournals");

            migrationBuilder.DropTable(
                name: "Currencies");

            migrationBuilder.DropTable(
                name: "FixedAssetCards");
        }
    }
}
