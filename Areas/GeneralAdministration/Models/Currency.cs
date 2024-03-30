using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SmilyAccountant.Areas.GeneralAdministration.Models
{
    public class Currency
    {
        public Guid Id { get; set; }


        [Display(Name = "Currency Name")]
        public required string Name { get; set; }


        [Display(Name = "Currency Code")]
        public required string Code { get; set; }

    }
}
