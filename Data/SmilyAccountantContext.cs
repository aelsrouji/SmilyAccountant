﻿using Microsoft.EntityFrameworkCore;
using SmilyAccountant.Areas.Finance.Models;
using SmilyAccountant.Areas.GeneralAdministration.Models;

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


    }
}
