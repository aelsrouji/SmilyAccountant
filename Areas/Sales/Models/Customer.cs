using SmilyAccountant.Areas.Finance.Models;
using SmilyAccountant.Areas.Finance.Models.Enums;
using SmilyAccountant.Areas.GeneralAdministration.Models;
using SmilyAccountant.Areas.Sales.Models.Enums;
using System.ComponentModel.DataAnnotations;

namespace SmilyAccountant.Areas.Sales.Models
{
    public class Customer
    {
        public Guid Id { get; set; }
        public required string Number { get; set; }

        public required string Name { get; set; }
        public decimal Balanace { get; set; }

        [Display(Name= "Balanace As Vendor")]
        public decimal BalanaceAsVendor { get; set; }

        [Display(Name = "Credit Limit")]
        public decimal CreditLimit { get; set; }

        [Display(Name = "Sales Person")]
        public Guid? SalesPersonId { get; set; }
        public Employee? SalesPerson { get; set; }

        //public Guid ResponsibilityCeneterId { get; set; }
        //public Guid DocumentSendingProfileId { get; set; }

        [Display(Name = "Total Sales Fiscal Year")]
        public decimal TotalSalesFiscalYear { get; set; }
        public decimal Costs { get; set; }
        public decimal Profit { get; set; }


        [Display(Name = "Profit Percentage")]
        public decimal ProfitPercentage { get; set; }

        [Display(Name = "Last Date Modified")]
        public DateTime LastDateModified { get; set; }

        public string? Address { get; set; }

        [Display(Name = "Address 2")]
        public string? Address2 { get; set; }

        
        [Display(Name = "Country")]
        public Guid? CountryId { get; set; }
        public Country? Country { get; set; }

        [Display(Name = "State")]
        public Guid? StateId { get; set; }
        public State? State { get; set; }


        [Display(Name = "City")]
        public Guid? CityId { get; set; }
        public City? City  { get; set; }


        [Display(Name = "Postal Code")]
        public string? PostalCode { get; set; }

        public string? Phone { get; set; }

        [Display(Name = "Mobile Phone")]
        public string?  MobilePhone { get; set; }

        public string? Email { get; set; }

        [Display(Name = "Home Page")]
        public string? HomePage { get; set; }

        //Invoicing

        [Display(Name = "Vat Registration No")]
        public string? VatRegistrationNo { get; set; }


        [Display(Name = "Copy Sell To Addr to Qte")]
        public CopySellToAddrToQte CopySellToAddrToQte { get; set; }

        [Display(Name = "Tax Liable")]
        public bool TaxLiable { get; set; }

        [Display(Name = "Tax Area Code")]
        public Guid? TaxAreaCodeId { get; set; }
        public TaxAreaCode? TaxAreaCode { get; set; }

        [Display(Name = "Tax Identification Type")]
        public TaxIdentificationType? TaxIdentificationType { get; set; }

        [Display(Name = "Tax Excemption No")]
        public string? TaxExcemptionNo { get; set; }

        public Guid? GeneralBusPostingGroupId { get; set; }
        
        [Display(Name = "General Bus Posting Group")]
        public GeneralBusPostingGroup? GeneralBusPostingGroup { get; set; }

        
        public Guid? CustomerPostingGroupId { get; set; }

        [Display(Name = "Customer Posting Group")]
        public CustomerPostingGroup? CustomerPostingGroup { get; set; }

        
        public Guid? CustomerPriceGroupId { get; set; }

        [Display(Name = "Customer Price Group")]
        public CustomerPriceGroup? CustomerPriceGroup { get; set; }
        
        public Guid? CustomerDiscGroupId  { get; set; }

        [Display(Name = "Customer Disc Group")]
        public CustomerDiscGroup? CustomerDiscGroup { get; set; }


        //Payments


        //Shipping

    }
}
