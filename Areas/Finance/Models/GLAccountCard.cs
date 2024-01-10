using System.ComponentModel;
using SmilyAccountant.Areas.Finance.Models.Enums;

namespace SmilyAccountant.Areas.Finance.Models
{
    public class GLAccountCard
    {
        public Guid Id { get; set; }

        [DisplayName("Account Number")]
        public string AccountNo { get; set; }

        [DisplayName("Account Name")]
        public string AccountName { get; set; }
        public decimal Balance { get; set; }
        public Guid AccountCategoryId { get; set; }
        public virtual IEnumerable<AccountCategory> Categories { get; set; }
        public Guid AccountSubCategoryId { get; set; }

        [DisplayName("Sub Category")]
        public virtual IEnumerable<AccountSubCategory> AccountSubCategories { get; set; }

        [DisplayName("Debit or Credit?")]
        public DebitCreditBoth DebitCredit { get; set; }

        [DisplayName("Account Type")]
        public virtual IEnumerable<AccountType> AccountTypes { get; set; }

        public Guid AccountTypeId { get; set; }

    }
}
