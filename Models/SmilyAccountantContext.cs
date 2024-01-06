using Microsoft.EntityFrameworkCore;

namespace SmilyAccountant.Models
{
    public class SmilyAccountantContext: DbContext
    {
        public SmilyAccountantContext(DbContextOptions<SmilyAccountantContext> options)
        : base(options)
        {
        }

        public DbSet<GLAccountCard> GLAccountCards { get; set; }
        public DbSet<AccountCategory> AccountCategories { get; set; }
        public DbSet<AccountSubCategory> AccountSubCategories { get; set; }
        public DbSet<AccountType> AccountTypes { get; set; }
        
    }
}
