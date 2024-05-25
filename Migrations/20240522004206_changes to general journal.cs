using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SmilyAccountant.Migrations
{
    /// <inheritdoc />
    public partial class changestogeneraljournal : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Currencies_GeneralJournals_GeneralJournalId",
                table: "Currencies");

            migrationBuilder.DropForeignKey(
                name: "FK_FixedAssetCards_GeneralJournals_GeneralJournalId",
                table: "FixedAssetCards");

            migrationBuilder.DropForeignKey(
                name: "FK_GLAccountCards_GeneralJournals_GeneralJournalId",
                table: "GLAccountCards");

            migrationBuilder.DropIndex(
                name: "IX_GLAccountCards_GeneralJournalId",
                table: "GLAccountCards");

            migrationBuilder.DropIndex(
                name: "IX_FixedAssetCards_GeneralJournalId",
                table: "FixedAssetCards");

            migrationBuilder.DropIndex(
                name: "IX_Currencies_GeneralJournalId",
                table: "Currencies");

            migrationBuilder.DropColumn(
                name: "GeneralJournalId",
                table: "GLAccountCards");

            migrationBuilder.DropColumn(
                name: "GeneralJournalId",
                table: "FixedAssetCards");

            migrationBuilder.DropColumn(
                name: "GeneralJournalId",
                table: "Currencies");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "GeneralJournalId",
                table: "GLAccountCards",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "GeneralJournalId",
                table: "FixedAssetCards",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "GeneralJournalId",
                table: "Currencies",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_GLAccountCards_GeneralJournalId",
                table: "GLAccountCards",
                column: "GeneralJournalId");

            migrationBuilder.CreateIndex(
                name: "IX_FixedAssetCards_GeneralJournalId",
                table: "FixedAssetCards",
                column: "GeneralJournalId");

            migrationBuilder.CreateIndex(
                name: "IX_Currencies_GeneralJournalId",
                table: "Currencies",
                column: "GeneralJournalId");

            migrationBuilder.AddForeignKey(
                name: "FK_Currencies_GeneralJournals_GeneralJournalId",
                table: "Currencies",
                column: "GeneralJournalId",
                principalTable: "GeneralJournals",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_FixedAssetCards_GeneralJournals_GeneralJournalId",
                table: "FixedAssetCards",
                column: "GeneralJournalId",
                principalTable: "GeneralJournals",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_GLAccountCards_GeneralJournals_GeneralJournalId",
                table: "GLAccountCards",
                column: "GeneralJournalId",
                principalTable: "GeneralJournals",
                principalColumn: "Id");
        }
    }
}
