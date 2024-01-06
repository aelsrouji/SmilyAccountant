using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SmilyAccountant.Migrations
{
    /// <inheritdoc />
    public partial class Initialmigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
                    DebitCredit = table.Column<int>(type: "int", nullable: false),
                    AccountTypeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GLAccountCards", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AccountSubCategories",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    GLAccountCardId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AccountSubCategories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AccountSubCategories_GLAccountCards_GLAccountCardId",
                        column: x => x.GLAccountCardId,
                        principalTable: "GLAccountCards",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "AccountTypes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    GLAccountCardId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AccountTypes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AccountTypes_GLAccountCards_GLAccountCardId",
                        column: x => x.GLAccountCardId,
                        principalTable: "GLAccountCards",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "AccountCategories",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AccountSubCategoryId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    GLAccountCardId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AccountCategories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AccountCategories_AccountSubCategories_AccountSubCategoryId",
                        column: x => x.AccountSubCategoryId,
                        principalTable: "AccountSubCategories",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_AccountCategories_GLAccountCards_GLAccountCardId",
                        column: x => x.GLAccountCardId,
                        principalTable: "GLAccountCards",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_AccountCategories_AccountSubCategoryId",
                table: "AccountCategories",
                column: "AccountSubCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_AccountCategories_GLAccountCardId",
                table: "AccountCategories",
                column: "GLAccountCardId");

            migrationBuilder.CreateIndex(
                name: "IX_AccountSubCategories_GLAccountCardId",
                table: "AccountSubCategories",
                column: "GLAccountCardId");

            migrationBuilder.CreateIndex(
                name: "IX_AccountTypes_GLAccountCardId",
                table: "AccountTypes",
                column: "GLAccountCardId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AccountCategories");

            migrationBuilder.DropTable(
                name: "AccountTypes");

            migrationBuilder.DropTable(
                name: "AccountSubCategories");

            migrationBuilder.DropTable(
                name: "GLAccountCards");
        }
    }
}
