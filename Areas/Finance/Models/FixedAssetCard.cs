using System.ComponentModel.DataAnnotations;

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


        [Display(Name = "FA Sub Class Id")]
        public Guid FASubClassCodeId { get; set; }


        [Display(Name = "Fixed Asset Serial Number")]
        public string? SerialNumber { get; set; }

        [Display(Name = "Employee Id")]
        public Guid EmployeeId { get; set; }


        [Display(Name = "FA Class Code")]
        public FAClassCode? FAClassCode { get; set; }

        [Display(Name = "FA Sub Class Code")]
        public FASubClassCode? FASubClassCode { get; set;}

        public Employee? Employee { get; set; }


        // todo: add depreciation details

        // this will add FixedAssetCardId to both FCClassCodes and FASubClassCodes tables
        //public virtual ICollection<FAClassCode>? FAClassCodes { get; set; }
        //public virtual ICollection<FASubClassCode>? FASubClassCodes { get; set; }

    }
}
