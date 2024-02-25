using System.ComponentModel.DataAnnotations;

namespace SmilyAccountant.Areas.Finance.Models
{
    public class AccountCategory
    {

        public Guid Id { get; set; }


        [Display(Name = "Account Category Name")]
        public string Name { get; set; }

        public virtual ICollection<AccountSubCategory> SubCategories { get; set; } = new List<AccountSubCategory>();


    }
}