using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SmilyAccountant.Migrations
{
    /// <inheritdoc />
    public partial class Chartofaccoutnupdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_ChartOfAccounts_GLAccountCardId",
                table: "ChartOfAccounts",
                column: "GLAccountCardId");

            migrationBuilder.AddForeignKey(
                name: "FK_ChartOfAccounts_GLAccountCards_GLAccountCardId",
                table: "ChartOfAccounts",
                column: "GLAccountCardId",
                principalTable: "GLAccountCards",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ChartOfAccounts_GLAccountCards_GLAccountCardId",
                table: "ChartOfAccounts");

            migrationBuilder.DropIndex(
                name: "IX_ChartOfAccounts_GLAccountCardId",
                table: "ChartOfAccounts");
        }
    }
}
