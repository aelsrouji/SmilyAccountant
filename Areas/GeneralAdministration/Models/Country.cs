using System.ComponentModel.DataAnnotations;

namespace SmilyAccountant.Areas.GeneralAdministration.Models
{
    public class Country
    {
        public Guid Id { get; set; }


        [Display(Name = "Country Name")]
        public required string Name { get; set; }


        [Display(Name = "Country Code")]
        public required string Code { get; set; }

    }
}
