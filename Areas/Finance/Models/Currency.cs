using System.ComponentModel.DataAnnotations.Schema;

namespace SmilyAccountant.Areas.Finance.Models
{
    public class Currency
    {
        public Guid Id { get; set; }
        public required string Name { get; set; } 
        public required string Code { get; set; }

    }
}
