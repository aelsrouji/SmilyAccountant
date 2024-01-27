using System.Diagnostics.SymbolStore;
using SmilyAccountant.Areas.Finance.Models.Enums;

namespace SmilyAccountant.Areas.Finance.Models
{
    public class GeneralJournal
    {
        public Guid Id { get; set; }
        public DateTime PostingDate { get; set; }
        public DocumentType DocumentType { get; set; }
        public string? DocumentNumber { get; set; }

        public Guid FixedAssetCardId { get; set; } // Called Account Number in General Journal

        public string? Description { get; set; }

        public Guid CurrencyId { get; set; }
        public GeneralPostingType GeneralPostingType { get; set; }

        public decimal Amount { get; set; }
        public decimal AmountWithTax { get; set; }

        public string? Comment { get; set; }

    }
}
