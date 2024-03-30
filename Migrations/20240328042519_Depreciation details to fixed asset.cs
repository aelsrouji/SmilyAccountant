using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SmilyAccountant.Migrations
{
    /// <inheritdoc />
    public partial class Depreciationdetailstofixedasset : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "BookValue",
                table: "FixedAssetCards",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<DateTime>(
                name: "DepreciationEndingDate",
                table: "FixedAssetCards",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DepreciationStartingDate",
                table: "FixedAssetCards",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<double>(
                name: "NoOfDepreciataionYears",
                table: "FixedAssetCards",
                type: "float",
                nullable: false,
                defaultValue: 0.0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BookValue",
                table: "FixedAssetCards");

            migrationBuilder.DropColumn(
                name: "DepreciationEndingDate",
                table: "FixedAssetCards");

            migrationBuilder.DropColumn(
                name: "DepreciationStartingDate",
                table: "FixedAssetCards");

            migrationBuilder.DropColumn(
                name: "NoOfDepreciataionYears",
                table: "FixedAssetCards");
        }
    }
}
