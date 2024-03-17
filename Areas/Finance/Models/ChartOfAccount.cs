using System.ComponentModel.DataAnnotations;

namespace SmilyAccountant.Areas.Finance.Models
{
    public class ChartOfAccount
    {
        public Guid Id { get; set; }
        public Guid GLAccountCardId { get; set; }

        [Display(Name ="Net Change")]
        public decimal NetChange { get; set; }

        [Display(Name = "Net Balanace")]
        public decimal NetBalanace { get; set; }

        public  virtual  GLAccountCard GLAccountCard  { get; set; }
    }
}
