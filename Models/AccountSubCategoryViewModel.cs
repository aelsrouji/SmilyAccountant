namespace SmilyAccountant.Models
{
    public class AccountSubCategoryViewModel
    {
        public Guid Id { get; set; }

        public required string Name { get; set; }

        public Guid AccountCategoryId { get; set; }

    }
}