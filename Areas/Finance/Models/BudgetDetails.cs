using System.ComponentModel.DataAnnotations;

namespace SmilyAccountant.Areas.Finance.Models
{
    public class BudgetDetails
    {
        public Guid Id { get; set; }
        public Guid BudgetId { get; set; }
        public Budget Budget { get; set; }
        public Guid GLAccountCardId { get; set; }
        public required GLAccountCard GLAccountCard { get; set; }

        [Display(Name = "Budget Month")]
        [Range(1, 12)]
        public int BudgetMonth { get; set; } = DateTime.UtcNow.Month;

        [Display(Name = "Budget Year")]
        public int BudgetYear { get; set; } = DateTime.UtcNow.Year;

        [Display(Name = "Budgeted Amount")]
        public decimal BudgetedAmount { get; set; }

        [Display(Name = "Total Budgeted Amount")]
        public decimal TotalBudgetedAmount { get; set; } // todo: move to new table for budgettotals

    }
}
