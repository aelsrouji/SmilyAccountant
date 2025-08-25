using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SmilyAccountant.Migrations
{
    /// <inheritdoc />
    public partial class UpdateVendorState : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "StateId",
                table: "Vendors",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_Vendors_StateId",
                table: "Vendors",
                column: "StateId");

            migrationBuilder.AddForeignKey(
                name: "FK_Vendors_States_StateId",
                table: "Vendors",
                column: "StateId",
                principalTable: "States",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Vendors_States_StateId",
                table: "Vendors");

            migrationBuilder.DropIndex(
                name: "IX_Vendors_StateId",
                table: "Vendors");

            migrationBuilder.DropColumn(
                name: "StateId",
                table: "Vendors");
        }
    }
}
