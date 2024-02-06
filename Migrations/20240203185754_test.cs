using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SmilyAccountant.Migrations
{
    /// <inheritdoc />
    public partial class test : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_FixedAssetCards_FAClassCodeId",
                table: "FixedAssetCards",
                column: "FAClassCodeId");

            migrationBuilder.CreateIndex(
                name: "IX_FixedAssetCards_FASubClassCodeId",
                table: "FixedAssetCards",
                column: "FASubClassCodeId");

            migrationBuilder.AddForeignKey(
                name: "FK_FixedAssetCards_FAClassCodes_FAClassCodeId",
                table: "FixedAssetCards",
                column: "FAClassCodeId",
                principalTable: "FAClassCodes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_FixedAssetCards_FASubClassCodes_FASubClassCodeId",
                table: "FixedAssetCards",
                column: "FASubClassCodeId",
                principalTable: "FASubClassCodes",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FixedAssetCards_FAClassCodes_FAClassCodeId",
                table: "FixedAssetCards");

            migrationBuilder.DropForeignKey(
                name: "FK_FixedAssetCards_FASubClassCodes_FASubClassCodeId",
                table: "FixedAssetCards");

            migrationBuilder.DropIndex(
                name: "IX_FixedAssetCards_FAClassCodeId",
                table: "FixedAssetCards");

            migrationBuilder.DropIndex(
                name: "IX_FixedAssetCards_FASubClassCodeId",
                table: "FixedAssetCards");
        }
    }
}
