using System.ComponentModel.DataAnnotations;
using System.Reflection;

namespace SmilyAccountant.Areas.Finance.Models.ViewModels
{
    public class AccountSubCategoryViewModel
    {
        public Guid Id { get; set; }

        [Display(Name = "Sub Category Name")]
        public required string Name { get; set; }

        [Display(Name = "Account Category Id")]
        public Guid AccountCategoryId { get; set; }

        public virtual AccountCategory AccountCategory { get; set; }
    }
}