using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SmilyAccountant.Migrations
{
    /// <inheritdoc />
    public partial class Employeeasforiegnkeytofixedassetcard : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_FixedAssetCards_EmployeeId",
                table: "FixedAssetCards",
                column: "EmployeeId");

            migrationBuilder.AddForeignKey(
                name: "FK_FixedAssetCards_Employees_EmployeeId",
                table: "FixedAssetCards",
                column: "EmployeeId",
                principalTable: "Employees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FixedAssetCards_Employees_EmployeeId",
                table: "FixedAssetCards");

            migrationBuilder.DropIndex(
                name: "IX_FixedAssetCards_EmployeeId",
                table: "FixedAssetCards");
        }
    }
}
