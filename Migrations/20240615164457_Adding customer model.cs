using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SmilyAccountant.Migrations
{
    /// <inheritdoc />
    public partial class Addingcustomermodel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Number = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Balanace = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    BalanaceAsVendor = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CreditLimit = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    SalesPersonId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TotalSalesFiscalYear = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Costs = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Profit = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ProfitPercentage = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    LastDateModified = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Address2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CountryId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    StateId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CityId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    PostalCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MobilePhone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HomePage = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    VatRegistrationNo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CopySellToAddrToQte = table.Column<int>(type: "int", nullable: false),
                    TaxLiable = table.Column<bool>(type: "bit", nullable: false),
                    TaxAreaCodeId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    TaxIdentificationType = table.Column<int>(type: "int", nullable: true),
                    TaxExcemptionNo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GeneralBusPostingGroupId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CustomerPostingGroupId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CustomerPriceGroupId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CustomerDiscGroupId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Customers_CustomerDiscountGroups_CustomerDiscGroupId",
                        column: x => x.CustomerDiscGroupId,
                        principalTable: "CustomerDiscountGroups",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Customers_CustomerPostingGroups_CustomerPostingGroupId",
                        column: x => x.CustomerPostingGroupId,
                        principalTable: "CustomerPostingGroups",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Customers_CustomerPriceGroups_CustomerPriceGroupId",
                        column: x => x.CustomerPriceGroupId,
                        principalTable: "CustomerPriceGroups",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Customers_GeneralBusPostingGroups_GeneralBusPostingGroupId",
                        column: x => x.GeneralBusPostingGroupId,
                        principalTable: "GeneralBusPostingGroups",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Customers_TaxAreaCodes_TaxAreaCodeId",
                        column: x => x.TaxAreaCodeId,
                        principalTable: "TaxAreaCodes",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Customers_CustomerDiscGroupId",
                table: "Customers",
                column: "CustomerDiscGroupId");

            migrationBuilder.CreateIndex(
                name: "IX_Customers_CustomerPostingGroupId",
                table: "Customers",
                column: "CustomerPostingGroupId");

            migrationBuilder.CreateIndex(
                name: "IX_Customers_CustomerPriceGroupId",
                table: "Customers",
                column: "CustomerPriceGroupId");

            migrationBuilder.CreateIndex(
                name: "IX_Customers_GeneralBusPostingGroupId",
                table: "Customers",
                column: "GeneralBusPostingGroupId");

            migrationBuilder.CreateIndex(
                name: "IX_Customers_TaxAreaCodeId",
                table: "Customers",
                column: "TaxAreaCodeId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Customers");
        }
    }
}
