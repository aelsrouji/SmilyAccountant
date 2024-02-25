using System.ComponentModel.DataAnnotations;

namespace SmilyAccountant.Areas.Finance.Models
{
    public class FAClassCode
    {
        public Guid Id { get; set; }


        [Display(Name = "Fixed Asset Class Code")]
        public required string Code { get; set; }


        [Display(Name = "Fixed Asset Class Name")]
        public required string Name { get; set; }

        // this the many part in relationship to FASubClassCodes table
        public virtual ICollection<FASubClassCode>? FASubClassCodes { get; set; }
    }
}
