using System.ComponentModel.DataAnnotations;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Diagnostics.Metrics;
using System.Net;

namespace SmilyAccountant.Areas.GeneralAdministration.Models
{
    public class Vendor
    {
        [Key]
        public Guid Id { get; set; }


        [Display(Name = "Vendor No")]
        public required string VendorNo { get; set; }


        [Display(Name="Vendor Name")]
        public required string Name { get; set; }


        [Display(Name = "Balance LCY")]
        public decimal BalanceLCY { get; set; }


        [Display(Name = "Balance as Customer LCY")]
        public decimal BalanceLCYasCustomer { get; set; }

        
        [Display(Name = "Balance Due")]
        public decimal BalanceDue { get; set; }

        public string Address { get; set; }


        [Display(Name = "Address 2")]
        public string Address2 { get; set; }

        public Guid CityId { get; set; } 

        public City City { get; set; }

        [Display(Name="State/Province")]
        public Guid StateProvince { get; set; }

        public Guid CountryId { get; set; }

        public Country Country { get; set; }


        [Display(Name="Postal Code")]
        public string PostalCode { get; set; }

        public string Phone { get; set; }


        [Display(Name="Mobile Phone")]
        public string MobilePhone { get; set; }

        public string Email { get; set; }

        [Display(Name = "Primary Contact")]
        public Guid PrimaryContactId { get; set; }

        public Contact PrimaryContact { get; set; }


        [Display(Name = "Secondary Contact")]
        public Guid SecondaryContactId { get; set; }

        public Contact SecondaryContact { get; set; }
    }
}
