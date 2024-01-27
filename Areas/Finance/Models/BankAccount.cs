namespace SmilyAccountant.Areas.Finance.Models
{
    public class BankAccount
    {
        public Guid Id { get; set; }
        public required string No { get; set; }
        public string? BranchNumber { get; set; }
        public string? BankAccountNumber { get; set; }
        public decimal Balance { get; set; }
        public bool Blocked { get; set; }
    }
}
