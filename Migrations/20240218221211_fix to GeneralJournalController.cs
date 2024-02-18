using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SmilyAccountant.Migrations
{
    /// <inheritdoc />
    public partial class fixtoGeneralJournalController : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GeneralJournals_GLAccountCards_GlAccountCardId",
                table: "GeneralJournals");

            migrationBuilder.RenameColumn(
                name: "GlAccountCardId",
                table: "GeneralJournals",
                newName: "GLAccountCardId");

            migrationBuilder.RenameIndex(
                name: "IX_GeneralJournals_GlAccountCardId",
                table: "GeneralJournals",
                newName: "IX_GeneralJournals_GLAccountCardId");

            migrationBuilder.AddForeignKey(
                name: "FK_GeneralJournals_GLAccountCards_GLAccountCardId",
                table: "GeneralJournals",
                column: "GLAccountCardId",
                principalTable: "GLAccountCards",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GeneralJournals_GLAccountCards_GLAccountCardId",
                table: "GeneralJournals");

            migrationBuilder.RenameColumn(
                name: "GLAccountCardId",
                table: "GeneralJournals",
                newName: "GlAccountCardId");

            migrationBuilder.RenameIndex(
                name: "IX_GeneralJournals_GLAccountCardId",
                table: "GeneralJournals",
                newName: "IX_GeneralJournals_GlAccountCardId");

            migrationBuilder.AddForeignKey(
                name: "FK_GeneralJournals_GLAccountCards_GlAccountCardId",
                table: "GeneralJournals",
                column: "GlAccountCardId",
                principalTable: "GLAccountCards",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
