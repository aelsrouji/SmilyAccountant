using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SmilyAccountant.Migrations
{
    /// <inheritdoc />
    public partial class FixedFAclasscoderelationship : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FAClassCodes_FixedAssetCards_FixedAssetCardId",
                table: "FAClassCodes");

            migrationBuilder.DropForeignKey(
                name: "FK_FASubClassCodes_FixedAssetCards_FixedAssetCardId",
                table: "FASubClassCodes");

            migrationBuilder.DropIndex(
                name: "IX_FASubClassCodes_FixedAssetCardId",
                table: "FASubClassCodes");

            migrationBuilder.DropIndex(
                name: "IX_FAClassCodes_FixedAssetCardId",
                table: "FAClassCodes");

            migrationBuilder.DropColumn(
                name: "FixedAssetCardId",
                table: "FASubClassCodes");

            migrationBuilder.DropColumn(
                name: "FixedAssetCardId",
                table: "FAClassCodes");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "FixedAssetCardId",
                table: "FASubClassCodes",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "FixedAssetCardId",
                table: "FAClassCodes",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_FASubClassCodes_FixedAssetCardId",
                table: "FASubClassCodes",
                column: "FixedAssetCardId");

            migrationBuilder.CreateIndex(
                name: "IX_FAClassCodes_FixedAssetCardId",
                table: "FAClassCodes",
                column: "FixedAssetCardId");

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
        }
    }
}
