namespace SmilyAccountant.Areas.Finance.Models
{
    public class FAClassCode
    {
        public Guid Id { get; set; }
        public required string Code { get; set; }
        public required string Name { get; set; }

        // this this the many part in relationship to FASubClassCodes table
        public virtual ICollection<FASubClassCode>? FASubClassCodes { get; set; }
    }
}
