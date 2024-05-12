using System.ComponentModel.DataAnnotations;

namespace SmilyAccountant.Areas.Finance.Models
{
    public class Budget
    {
        public Guid Id { get; set; }

        [Display(Name = "Budget Name")]
        public required string Name { get; set; }

        
    }
}

