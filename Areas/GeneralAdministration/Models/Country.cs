using System.ComponentModel.DataAnnotations;

namespace SmilyAccountant.Areas.GeneralAdministration.Models
{
    public class Country
    {
        [Key]
        public Guid Id { get; set; }


        [Required]
        [StringLength(255)]
        [Display(Name = "Country Name")]
        public required string Name { get; set; }

        [Required]
        [StringLength(10)]
        [Display(Name = "Country Code")]
        public required string Code { get; set; }


        [Display(Name = "Is Active")]
        public bool IsActive { get; set; } = true;


        [Display(Name = "Created By")]
        public required string CreatedBy { get; set; }


        [Display(Name = "Modified By")]
        public string? ModifiedBy { get; set; }


        private DateTime createdDate;

        [Display(Name = "Created Date")]
        public DateTime CreatedDate
        {
            get
            {
                return createdDate.ToUniversalTime();
            }
            set
            {
                createdDate = value;
            }
        }

        private DateTime updatedDate;

        [Display(Name = "Updated Date")]
        public DateTime UpdatedDate
        {
            get
            {
                return updatedDate.ToUniversalTime();
            }
            set
            {
                updatedDate = value;
            }
        }
        public ICollection<State> States { get; } = new List<State>();
        public ICollection<City> Cities { get; } = new List<City>();

    }
}
