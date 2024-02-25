using System.ComponentModel.DataAnnotations;

namespace SmilyAccountant.Areas.Finance.Models
{
    public class FASubClassCode
    {
        public Guid Id { get; set; }


        [Display(Name= "Fixed Asset Class Id")]
        public Guid FAClassCodeId { get; set; }

        [Display(Name = "Fixed Asset Sub Class Code")]
        public required string Code { get; set; }


        [Display(Name = "Fixed Asset Sub Class Name")]
        public required string Name { get; set; }

        public  required FAClassCode FAClassCode { get; set; }
    }
}
