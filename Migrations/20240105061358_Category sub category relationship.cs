using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SmilyAccountant.Migrations
{
    /// <inheritdoc />
    public partial class Categorysubcategoryrelationship : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AccountCategories_AccountSubCategories_AccountSubCategoryId",
                table: "AccountCategories");

            migrationBuilder.DropIndex(
                name: "IX_AccountCategories_AccountSubCategoryId",
                table: "AccountCategories");

            migrationBuilder.DropColumn(
                name: "AccountSubCategoryId",
                table: "AccountCategories");

            migrationBuilder.CreateIndex(
                name: "IX_AccountSubCategories_AccountCategoryId",
                table: "AccountSubCategories",
                column: "AccountCategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_AccountSubCategories_AccountCategories_AccountCategoryId",
                table: "AccountSubCategories",
                column: "AccountCategoryId",
                principalTable: "AccountCategories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AccountSubCategories_AccountCategories_AccountCategoryId",
                table: "AccountSubCategories");

            migrationBuilder.DropIndex(
                name: "IX_AccountSubCategories_AccountCategoryId",
                table: "AccountSubCategories");

            migrationBuilder.AddColumn<Guid>(
                name: "AccountSubCategoryId",
                table: "AccountCategories",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_AccountCategories_AccountSubCategoryId",
                table: "AccountCategories",
                column: "AccountSubCategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_AccountCategories_AccountSubCategories_AccountSubCategoryId",
                table: "AccountCategories",
                column: "AccountSubCategoryId",
                principalTable: "AccountSubCategories",
                principalColumn: "Id");
        }
    }
}
