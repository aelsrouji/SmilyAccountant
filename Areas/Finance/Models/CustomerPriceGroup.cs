namespace SmilyAccountant.Areas.Finance.Models
{
    public class CustomerPriceGroup
    {
        public Guid Id { get; set; }
        public required string Code { get; set; }
        public required string Description { get; set; }

    }
}
