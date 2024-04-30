using System.ComponentModel.DataAnnotations;

namespace SmilyAccountant.Areas.Finance.Models
{
    public class BankDeposit
    {
        public Guid Id { get; set; }

        [Display(Name = "Bank Account")]
        public Guid BankAccountId { get; set; }

        public BankAccount BankAccount { get; set; }


        [Display(Name = "Deposit Amount")]
        public decimal DepositAmount { get; set; }

        [Display(Name = "Posting Date")]
        public DateTime PostingDate { get; set; }

    }
}
