using System.ComponentModel.DataAnnotations;
using SmilyAccountant.Areas.GeneralAdministration.Models;

namespace SmilyAccountant.Areas.Finance.Models
{
    public class FixedAssetCard
    {
        [Display(Name = "Fixed Asset Id")]
        public Guid FixedAssetCardId { get; set; }

        
        [Display(Name = "Fixed Asset Description")]
        public required string Description { get; set; }

        
        [Display(Name = "FA Class Code Id")]
        public Guid FAClassCodeId { get; set; }


        [Display(Name = "FA Class Code")]
        public FAClassCode? FAClassCode { get; set; }


        [Display(Name = "FA Sub Class Id")]
        public Guid FASubClassCodeId { get; set; }

        [Display(Name = "FA Sub Class Code")]
        public FASubClassCode? FASubClassCode { get; set; }

        [Display(Name = "Fixed Asset Serial Number")]
        public string? SerialNumber { get; set; }

        
        [Display(Name = "Employee Id")]
        public Guid EmployeeId { get; set; }

        public Employee? Employee { get; set; }


        //Depretiation method = Straight line - later to add different methods
        [Display(Name = "Depreciation Starting Date")]
        public DateTime DepreciationStartingDate { get; set; }

        [Display(Name = "No of Depreciation Years")]
        public double NoOfDepreciataionYears { get; set; }

        [Display(Name = "Depreciation Ending Date")]
        public DateTime DepreciationEndingDate { get; set; }
        
        [Display(Name = "Book Value")]
        public decimal BookValue { get; set; } = 0; // todo: calculate it - Add depreciation book?!

        //Maintenance
        //public Guid VendorId { get; set; }
        //public Vendor Vendor { get; set; } // todo: Add Vendor
        //public Guid MaintenanceVendorId { get; set; }
        //public Vendor MaintenanceVendor { get; set; } // todo: Add Vendor
        //public bool UnderMaintenance { get; set; }
        //public DateTime NextServiceDate { get; set; }
        //public DateTime WarrantyDate { get; set; }
        //public bool Insured { get; set; }

    }
}
