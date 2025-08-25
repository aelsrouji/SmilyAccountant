using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SmilyAccountant.Migrations
{
    /// <inheritdoc />
    public partial class UpdateVendorState2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "StateProvince",
                table: "Vendors");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "StateProvince",
                table: "Vendors",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));
        }
    }
}
