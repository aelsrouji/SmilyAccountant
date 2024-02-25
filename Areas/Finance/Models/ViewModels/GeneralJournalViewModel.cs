using SmilyAccountant.Areas.Finance.Models.Enums;
using System.ComponentModel.DataAnnotations;

namespace SmilyAccountant.Areas.Finance.Models.ViewModels
{
    public class GeneralJournalViewModel
    {
        public Guid Id { get; set; }

        [Display(Name = "Posting Date")]
        public DateTime PostingDate { get; set; }

        
        [Display(Name = "Document Type")]
        public DocumentType DocumentType { get; set; }

        
        [Display(Name = "Document Number")]
        public string? DocumentNumber { get; set; }

        [Display(Name = "Fixed Asset Card Id")]
        public Guid FixedAssetCardId { get; set; }

        
        [Display(Name = "GL Account Card Id")]
        public Guid GLAccountCardId { get; set; } 


        public string? Description { get; set; }


        [Display(Name = "Currency Id")]
        public Guid CurrencyId { get; set; }

        [Display(Name = "General Posting Type")]
        public GeneralPostingType GeneralPostingType { get; set; }

        public decimal Amount { get; set; }

        [Display(Name = "Amount With Tax")]
        public decimal AmountWithTax { get; set; }

        public string? Comment { get; set; }

    }
}
