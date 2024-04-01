using System.ComponentModel.DataAnnotations;

namespace SmilyAccountant.Areas.GeneralAdministration.Models
{
    public class State
    {
        [Key]
        public Guid Id { get; set; }

        [StringLength(10)]
        public required string Code { get; set; }
        [StringLength(255)]
        public required string Name { get; set; }
        [Display(Name = "Active")]
        public required bool IsActive { get; set; }
        [Display(Name = "Created By")]
        public required string CreatedBy { get; set; }

        private DateTime createdDate;
        [Display(Name = "Created Date")]
        public DateTime CreatedDate { get { return createdDate.ToLocalTime(); } set { createdDate = value; } }
        [Display(Name = "Modified By")]
        public string? ModifiedBy { get; set; }

        private DateTime updatedDate;
        [Display(Name = "Updated Date")]
        public DateTime UpdatedDate { get { return updatedDate.ToLocalTime(); } set { updatedDate = value; } }
        [Display(Name = "Country")]
        public Guid CountryID { get; set; }
        public virtual Country Country { get; set; }
    }
}
