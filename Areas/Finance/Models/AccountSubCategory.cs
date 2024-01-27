using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SmilyAccountant.Areas.Finance.Models
{
    [Bind(include: "Id, Name, AccountCategoryId")]
    public class AccountSubCategory
    {

        public Guid Id { get; set; }

        [Required]
        public required string Name { get; set; }

        public Guid AccountCategoryId { get; set; }
        public virtual AccountCategory AccountCategory { get; set; }

    }
}