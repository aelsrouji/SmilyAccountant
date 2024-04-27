using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SmilyAccountant.Migrations
{
    /// <inheritdoc />
    public partial class Addingfixedassetsmaintenancefields : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Insured",
                table: "FixedAssetCards",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<Guid>(
                name: "MaintenanceVendorId",
                table: "FixedAssetCards",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<DateTime>(
                name: "NextServiceDate",
                table: "FixedAssetCards",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<bool>(
                name: "UnderMaintenance",
                table: "FixedAssetCards",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<Guid>(
                name: "VendorId",
                table: "FixedAssetCards",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<DateTime>(
                name: "WarrantyDate",
                table: "FixedAssetCards",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.CreateIndex(
                name: "IX_FixedAssetCards_MaintenanceVendorId",
                table: "FixedAssetCards",
                column: "MaintenanceVendorId");

            migrationBuilder.CreateIndex(
                name: "IX_FixedAssetCards_VendorId",
                table: "FixedAssetCards",
                column: "VendorId");

            //migrationBuilder.AddForeignKey(
            //    name: "FK_FixedAssetCards_Vendors_MaintenanceVendorId",
            //    table: "FixedAssetCards",
            //    column: "MaintenanceVendorId",
            //    principalTable: "Vendors",
            //    principalColumn: "Id",
            //    onDelete: ReferentialAction.NoAction);

            //migrationBuilder.AddForeignKey(
            //    name: "FK_FixedAssetCards_Vendors_VendorId",
            //    table: "FixedAssetCards",
            //    column: "VendorId",
            //    principalTable: "Vendors",
            //    principalColumn: "Id",
            //    onDelete: ReferentialAction.NoAction);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FixedAssetCards_Vendors_MaintenanceVendorId",
                table: "FixedAssetCards");

            migrationBuilder.DropForeignKey(
                name: "FK_FixedAssetCards_Vendors_VendorId",
                table: "FixedAssetCards");

            migrationBuilder.DropIndex(
                name: "IX_FixedAssetCards_MaintenanceVendorId",
                table: "FixedAssetCards");

            migrationBuilder.DropIndex(
                name: "IX_FixedAssetCards_VendorId",
                table: "FixedAssetCards");

            migrationBuilder.DropColumn(
                name: "Insured",
                table: "FixedAssetCards");

            migrationBuilder.DropColumn(
                name: "MaintenanceVendorId",
                table: "FixedAssetCards");

            migrationBuilder.DropColumn(
                name: "NextServiceDate",
                table: "FixedAssetCards");

            migrationBuilder.DropColumn(
                name: "UnderMaintenance",
                table: "FixedAssetCards");

            migrationBuilder.DropColumn(
                name: "VendorId",
                table: "FixedAssetCards");

            migrationBuilder.DropColumn(
                name: "WarrantyDate",
                table: "FixedAssetCards");
        }
    }
}
