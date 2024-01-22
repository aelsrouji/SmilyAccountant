using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SmilyAccountant.Migrations
{
    /// <inheritdoc />
    public partial class Relationshipsupdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AccountCategories_GLAccountCards_GLAccountCardId",
                table: "AccountCategories");

            migrationBuilder.DropForeignKey(
                name: "FK_AccountSubCategories_GLAccountCards_GLAccountCardId",
                table: "AccountSubCategories");

            //migrationBuilder.DropForeignKey(
            //    name: "FK_AccountTypes_GLAccountCards_GLAccountCardId",
            //    table: "AccountTypes");

            //migrationBuilder.DropIndex(
            //    name: "IX_AccountTypes_GLAccountCardId",
            //    table: "AccountTypes");

            migrationBuilder.DropIndex(
                name: "IX_AccountSubCategories_GLAccountCardId",
                table: "AccountSubCategories");

            migrationBuilder.DropIndex(
                name: "IX_AccountCategories_GLAccountCardId",
                table: "AccountCategories");

            //migrationBuilder.DropColumn(
            //    name: "GLAccountCardId",
            //    table: "AccountTypes");

            migrationBuilder.DropColumn(
                name: "GLAccountCardId",
                table: "AccountSubCategories");

            migrationBuilder.DropColumn(
                name: "GLAccountCardId",
                table: "AccountCategories");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "GLAccountCardId",
                table: "AccountTypes",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "GLAccountCardId",
                table: "AccountSubCategories",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "GLAccountCardId",
                table: "AccountCategories",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_AccountTypes_GLAccountCardId",
                table: "AccountTypes",
                column: "GLAccountCardId");

            migrationBuilder.CreateIndex(
                name: "IX_AccountSubCategories_GLAccountCardId",
                table: "AccountSubCategories",
                column: "GLAccountCardId");

            migrationBuilder.CreateIndex(
                name: "IX_AccountCategories_GLAccountCardId",
                table: "AccountCategories",
                column: "GLAccountCardId");

            migrationBuilder.AddForeignKey(
                name: "FK_AccountCategories_GLAccountCards_GLAccountCardId",
                table: "AccountCategories",
                column: "GLAccountCardId",
                principalTable: "GLAccountCards",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AccountSubCategories_GLAccountCards_GLAccountCardId",
                table: "AccountSubCategories",
                column: "GLAccountCardId",
                principalTable: "GLAccountCards",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AccountTypes_GLAccountCards_GLAccountCardId",
                table: "AccountTypes",
                column: "GLAccountCardId",
                principalTable: "GLAccountCards",
                principalColumn: "Id");
        }
    }
}
