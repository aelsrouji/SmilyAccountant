namespace SmilyAccountant.Areas.Finance.Models
{
    public class GeneralBusPostingGroup
    {
        public Guid Id { get; set; }
        public required string Code { get; set; }
        public required string Description { get; set; }

        //Todo: add default VAT bus posting group
    }
}
