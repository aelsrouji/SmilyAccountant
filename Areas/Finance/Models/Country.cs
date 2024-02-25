using System.ComponentModel.DataAnnotations;

namespace SmilyAccountant.Areas.Finance.Models
{
    public class Country
    {
        public Guid Id { get; set; }


        [Display(Name = "Country Name")]
        public string Name { get; set; }

        
        [Display(Name = "Country Code")]
        public string Code { get; set; }

    }
}
