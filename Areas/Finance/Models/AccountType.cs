using System.ComponentModel.DataAnnotations;

namespace SmilyAccountant.Areas.Finance.Models
{
    public class AccountType
    {
        public Guid Id { get; set; }


        [Display(Name = "Account Type Name")]
        public string Name { get; set; }

    }
}