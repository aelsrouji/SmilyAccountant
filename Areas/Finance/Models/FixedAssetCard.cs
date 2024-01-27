namespace SmilyAccountant.Areas.Finance.Models
{
    public class FixedAssetCard
    {
        public int Id { get; set; }
        public required string Description { get; set; }

        public Guid FAClassCodeId { get; set; } 
     
        public Guid FASubClassCodeId { get; set; }

        public string? SerialNumber { get; set; }

        public Guid EmployeeId { get; set; }

        // todo: add depreciation details

        public virtual ICollection<FAClassCode>? FAClassCodes { get; set; }
        public virtual ICollection<FASubClassCode>? FASubClassCodes { get; set; }

    }
}
