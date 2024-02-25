using SmilyAccountant.Areas.Finance.Models.Enums;
using System.ComponentModel;

namespace SmilyAccountant.Areas.Finance.Models.ViewModels
{
    public class GLAccountCardViewModel
    {
        public Guid Id { get; set; }

        [DisplayName("Account Number")]
        public string AccountNo { get; set; }

        
        [DisplayName("Account Name")]
        public string AccountName { get; set; }
        
        public decimal Balance { get; set; }

        
        [DisplayName("Account Category")]
        public Guid AccountCategoryId { get; set; }

        
        [DisplayName("Account Sub Category")]
        public Guid AccountSubCategoryId { get; set; }


        [DisplayName("Account Type")]
        public Guid AccountTypeId { get; set; }

        
        [DisplayName("Debit or Credit?")]
        public DebitCreditBoth DebitCredit { get; set; }

        //public virtual AccountCategory AccountCategory { get; set; }
        //public virtual AccountSubCategory AccountSubCategory { get; set; }
        //public virtual AccountType AccountType { get; set; }





    }
}
