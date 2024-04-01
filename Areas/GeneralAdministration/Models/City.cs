using System.ComponentModel.DataAnnotations;

namespace SmilyAccountant.Areas.GeneralAdministration.Models
{
    public class City
    {
        public Guid Id { get; set; }

        [StringLength(255)]
        public required string Name { get; set; }

        [Display(Name = "Is Active?")]
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

        public Guid CountryId { get; set; }

        public virtual Country Country { get; set; }

        public Guid StateId { get; set; }

        public virtual State State { get; set; }

    }
}
