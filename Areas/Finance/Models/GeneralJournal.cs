using System.Diagnostics.SymbolStore;
using SmilyAccountant.Areas.Finance.Models.Enums;

namespace SmilyAccountant.Areas.Finance.Models
{
    public class GeneralJournal
    {
        public Guid Id { get; set; }
        public required DateTime PostingDate { get; set; }
        public DocumentType? DocumentType { get; set; }
        public string? DocumentNumber { get; set; }

        //public required Guid FixedAssetCardId { get; set; } // For fixed asset type 
        //public FixedAssetCard FixedAssetCard { get; set; }
        
        public required Guid GLAccountCardId { get; set; } // for gl account type
        public GLAccountCard GLAccountCard { get; set; }

        public string? Description { get; set; }

        public Guid? CurrencyId { get; set; }
        public Currency Currency { get; set; }

        public GeneralPostingType GeneralPostingType { get; set; }

        public decimal Amount { get; set; }
        public decimal AmountWithTax { get; set; }

        public string? Comment { get; set; }

        public virtual ICollection<FixedAssetCard>? FixedAssetCards { get; set; }
        public virtual ICollection<GLAccountCard>? GLAccountCards { get; set; }
        public virtual ICollection<Currency>? Currencies { get; set; }



    }
}
