using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SmilyAccountant.Migrations
{
    /// <inheritdoc />
    public partial class addingChartofaccount : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ChartOfAccounts",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    GLAccountCardId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    NetChange = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    NetBalanace = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChartOfAccounts", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ChartOfAccounts");
        }
    }
}
