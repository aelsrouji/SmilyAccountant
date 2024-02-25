using System.ComponentModel.DataAnnotations;

namespace SmilyAccountant.Areas.Finance.Models
{
    public class BankAccount
    {
        public Guid Id { get; set; }

        [Display(Name = "Bank Account Number")]
        public required string No { get; set; }

        
        [Display(Name = "Branch Number")]
        public string? BranchNumber { get; set; }

       
        [Display(Name = "Bank Account Number")]
        public string? BankAccountNumber { get; set; }

        public decimal Balance { get; set; }

        [Display(Name = "Blocked?")]
        public bool Blocked { get; set; }
    }
}
