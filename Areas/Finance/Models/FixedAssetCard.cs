using System.ComponentModel.DataAnnotations;

namespace SmilyAccountant.Areas.Finance.Models
{
    public class FixedAssetCard
    {
        public Guid FixedAssetCardId { get; set; }
        
        public required string Description { get; set; }

        public Guid FAClassCodeId { get; set; } 
     
        public Guid FASubClassCodeId { get; set; }

        public string? SerialNumber { get; set; }

        public Guid EmployeeId { get; set; }


        public FAClassCode FAClassCode { get; set; }
        public FASubClassCode FASubClassCode { get; set;}
        public Employee Employee { get; set; }


        // todo: add depreciation details

        // this will add FixedAssetCardId to both FCClassCodes and FASubClassCodes tables
        //public virtual ICollection<FAClassCode>? FAClassCodes { get; set; }
        //public virtual ICollection<FASubClassCode>? FASubClassCodes { get; set; }

    }
}
