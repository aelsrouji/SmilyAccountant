namespace SmilyAccountant.Models
{
    public class AccountCategory
    {

        public Guid Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<AccountSubCategory> SubCategories { get; set; } = new List<AccountSubCategory>();


    }
}