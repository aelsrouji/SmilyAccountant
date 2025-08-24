using System.ComponentModel.DataAnnotations;
using System.Reflection;

namespace SmilyAccountant.Areas.GeneralAdministration.Models
{
    public class Contact
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }

        [Display(Name = "Phone Number")]
        public string PhoneNumber { get; set; }


    }
}