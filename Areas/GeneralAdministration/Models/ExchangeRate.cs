using System.ComponentModel.DataAnnotations;

namespace SmilyAccountant.Areas.GeneralAdministration.Models
{
    public class ExchangeRate
    {
        public Guid Id { get; set; }

        [Display(Name = "From Currency")]
        public Guid FromCurrencyId { get; set; }

        public Currency FromCurrency { get; set; }

        [Display(Name = "To Currency")]
        public Guid ToCurrencyId { get; set; }

        public Currency ToCurrency { get; set; }

        [Display(Name = "Exchange Rate Value")]
        public decimal ExchangeRateValue { get; set; }


        [Display(Name = "Exchange Rate Date")]
        public DateTime ExchangeRateDate { get; set; }
        public bool IsActive { get; set; }


    }
}
