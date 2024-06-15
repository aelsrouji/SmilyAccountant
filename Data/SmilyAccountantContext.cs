using Microsoft.EntityFrameworkCore;
using SmilyAccountant.Areas.Finance.Models;
using SmilyAccountant.Areas.GeneralAdministration.Models;
using SmilyAccountant.Areas.Sales.Models;
using System.Data;

namespace SmilyAccountant.Data
{
    public class SmilyAccountantContext : DbContext
    {
        public SmilyAccountantContext(DbContextOptions<SmilyAccountantContext> options)
        : base(options)
        {
        }

        public DbSet<GLAccountCard> GLAccountCards { get; set; }
        public DbSet<AccountCategory> AccountCategories { get; set; }
        public DbSet<AccountSubCategory> AccountSubCategories { get; set; }
        public DbSet<AccountType> AccountTypes { get; set; }
        public DbSet<GeneralJournal> GeneralJournals { get; set; }
        public DbSet<BankAccount> BankAccounts { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<FAClassCode> FAClassCodes { get; set; }
        public DbSet<FASubClassCode> FASubClassCodes { get; set; }
        public DbSet<FixedAssetCard> FixedAssetCards { get; set; }
        public DbSet<Currency> Currencies { get; set; }
        public DbSet<ChartOfAccount> ChartOfAccounts { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<State> States { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<Vendor> Vendors { get; set; }
        public DbSet<BankDeposit> BankDeposits { get; set; }
        public DbSet<Budget> Budgets { get; set; }
        public DbSet<BudgetDetails> BudgetsDetails { get; set; }

        public DbSet<ExchangeRate> ExchangeRates { get; set; }

        public DbSet<TaxAreaCode> TaxAreaCodes { get; set; }

        public DbSet<GeneralBusPostingGroup> GeneralBusPostingGroups { get; set; }
        public DbSet<CustomerPostingGroup> CustomerPostingGroups { get; set; }

        public DbSet<CustomerPriceGroup> CustomerPriceGroups { get; set; }

        public DbSet<CustomerDiscGroup> CustomerDiscountGroups { get; set; }

        public DbSet<Customer> Customers { get; set; }
    }   
}
