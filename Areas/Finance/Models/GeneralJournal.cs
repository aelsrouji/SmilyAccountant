using System.ComponentModel.DataAnnotations;
using System.Diagnostics.SymbolStore;
using SmilyAccountant.Areas.Finance.Models.Enums;

namespace SmilyAccountant.Areas.Finance.Models
{
    public class GeneralJournal
    {
        public Guid Id { get; set; }

        [Display(Name = "Posting Date")]
        public required DateTime PostingDate { get; set; }

        
        [Display(Name = "Document Type")]
        public DocumentType? DocumentType { get; set; }

        
        [Display(Name = "Document Number")]
        public string? DocumentNumber { get; set; }

        //public required Guid FixedAssetCardId { get; set; } //ToDo: If fixed asset type is selcted
        //public FixedAssetCard FixedAssetCard { get; set; }

        [Display(Name = "GL Account Card Id")]
        public required Guid GLAccountCardId { get; set; } // for gl account type

        [Display(Name = "GL Account Card")]
        public GLAccountCard? GLAccountCard { get; set; }

        public string? Description { get; set; }

        
        [Display(Name = "Currency Id")]
        public Guid? CurrencyId { get; set; }
        
        public Currency? Currency { get; set; }


        [Display(Name = "General Posting Type")]
        public GeneralPostingType GeneralPostingType { get; set; }

        [Range(0.1, double.MaxValue)]
        public decimal Amount { get; set; }

        [Range(0.1, double.MaxValue)]
        [Display(Name = "Amount With Tax")]
        public decimal AmountWithTax { get; set; }
        public string? Comment { get; set; }

        public bool IsPosted { get; set; }


        public virtual ICollection<FixedAssetCard>? FixedAssetCards { get; set; }
        public virtual ICollection<GLAccountCard>? GLAccountCards { get; set; }
        public virtual ICollection<Currency>? Currencies { get; set; }


    }
}
