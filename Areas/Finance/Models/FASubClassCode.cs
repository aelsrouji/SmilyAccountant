namespace SmilyAccountant.Areas.Finance.Models
{
    public class FASubClassCode
    {
        public Guid Id { get; set; }
        public Guid FAClassCodeId { get; set; }
        public required string Code { get; set; }
        public required string Name { get; set; }

        public  required FAClassCode FAClassCode { get; set; }
    }
}
