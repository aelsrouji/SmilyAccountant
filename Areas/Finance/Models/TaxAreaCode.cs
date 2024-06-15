using SmilyAccountant.Areas.GeneralAdministration.Models;

namespace SmilyAccountant.Areas.Finance.Models
{
    public class TaxAreaCode
    {
        public Guid Id { get; set; }
        public required string Code { get; set; }

        public required string Description { get; set; }

        public Guid CountryId { get; set; }
        public Country Country { get; set; }
    }
}
