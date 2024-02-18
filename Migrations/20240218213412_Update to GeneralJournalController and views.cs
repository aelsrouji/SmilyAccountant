using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SmilyAccountant.Migrations
{
    /// <inheritdoc />
    public partial class UpdatetoGeneralJournalControllerandviews : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GeneralJournals_FixedAssetCards_FixedAssetCardId",
                table: "GeneralJournals");

            migrationBuilder.RenameColumn(
                name: "FixedAssetCardId",
                table: "GeneralJournals",
                newName: "GlAccountCardId");

            migrationBuilder.RenameIndex(
                name: "IX_GeneralJournals_FixedAssetCardId",
                table: "GeneralJournals",
                newName: "IX_GeneralJournals_GlAccountCardId");

            migrationBuilder.AddColumn<Guid>(
                name: "GeneralJournalId",
                table: "GLAccountCards",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_GLAccountCards_GeneralJournalId",
                table: "GLAccountCards",
                column: "GeneralJournalId");

            migrationBuilder.AddForeignKey(
                name: "FK_GeneralJournals_GLAccountCards_GlAccountCardId",
                table: "GeneralJournals",
                column: "GlAccountCardId",
                principalTable: "GLAccountCards",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_GLAccountCards_GeneralJournals_GeneralJournalId",
                table: "GLAccountCards",
                column: "GeneralJournalId",
                principalTable: "GeneralJournals",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GeneralJournals_GLAccountCards_GlAccountCardId",
                table: "GeneralJournals");

            migrationBuilder.DropForeignKey(
                name: "FK_GLAccountCards_GeneralJournals_GeneralJournalId",
                table: "GLAccountCards");

            migrationBuilder.DropIndex(
                name: "IX_GLAccountCards_GeneralJournalId",
                table: "GLAccountCards");

            migrationBuilder.DropColumn(
                name: "GeneralJournalId",
                table: "GLAccountCards");

            migrationBuilder.RenameColumn(
                name: "GlAccountCardId",
                table: "GeneralJournals",
                newName: "FixedAssetCardId");

            migrationBuilder.RenameIndex(
                name: "IX_GeneralJournals_GlAccountCardId",
                table: "GeneralJournals",
                newName: "IX_GeneralJournals_FixedAssetCardId");

            migrationBuilder.AddForeignKey(
                name: "FK_GeneralJournals_FixedAssetCards_FixedAssetCardId",
                table: "GeneralJournals",
                column: "FixedAssetCardId",
                principalTable: "FixedAssetCards",
                principalColumn: "FixedAssetCardId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
