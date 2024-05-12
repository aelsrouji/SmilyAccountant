﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SmilyAccountant.Data;

#nullable disable

namespace SmilyAccountant.Migrations
{
    [DbContext(typeof(SmilyAccountantContext))]
    partial class SmilyAccountantContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("SmilyAccountant.Areas.Finance.Models.AccountCategory", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("AccountCategories");
                });

            modelBuilder.Entity("SmilyAccountant.Areas.Finance.Models.AccountSubCategory", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("AccountCategoryId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("AccountCategoryId");

                    b.ToTable("AccountSubCategories");
                });

            modelBuilder.Entity("SmilyAccountant.Areas.Finance.Models.AccountType", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("AccountTypes");
                });

            modelBuilder.Entity("SmilyAccountant.Areas.Finance.Models.BankAccount", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<decimal>("Balance")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("BankAccountNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Blocked")
                        .HasColumnType("bit");

                    b.Property<string>("BranchNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("No")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("BankAccounts");
                });

            modelBuilder.Entity("SmilyAccountant.Areas.Finance.Models.BankDeposit", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("BankAccountId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<decimal>("DepositAmount")
                        .HasColumnType("decimal(18,2)");

                    b.Property<DateTime>("PostingDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("BankAccountId");

                    b.ToTable("BankDeposits");
                });

            modelBuilder.Entity("SmilyAccountant.Areas.Finance.Models.Budget", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Budgets");
                });

            modelBuilder.Entity("SmilyAccountant.Areas.Finance.Models.BudgetDetails", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("BudgetId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("BudgetMonth")
                        .HasColumnType("int");

                    b.Property<int>("BudgetYear")
                        .HasColumnType("int");

                    b.Property<decimal>("BudgetedAmount")
                        .HasColumnType("decimal(18,2)");

                    b.Property<Guid>("GLAccountCardId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<decimal>("TotalBudgetedAmount")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.HasIndex("BudgetId");

                    b.HasIndex("GLAccountCardId");

                    b.ToTable("BudgetsDetails");
                });

            modelBuilder.Entity("SmilyAccountant.Areas.Finance.Models.ChartOfAccount", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("GLAccountCardId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<decimal>("NetBalanace")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("NetChange")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.HasIndex("GLAccountCardId");

                    b.ToTable("ChartOfAccounts");
                });

            modelBuilder.Entity("SmilyAccountant.Areas.Finance.Models.FAClassCode", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("FAClassCodes");
                });

            modelBuilder.Entity("SmilyAccountant.Areas.Finance.Models.FASubClassCode", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("FAClassCodeId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("FAClassCodeId");

                    b.ToTable("FASubClassCodes");
                });

            modelBuilder.Entity("SmilyAccountant.Areas.Finance.Models.FixedAssetCard", b =>
                {
                    b.Property<Guid>("FixedAssetCardId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<decimal>("BookValue")
                        .HasColumnType("decimal(18,2)");

                    b.Property<DateTime>("DepreciationEndingDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DepreciationStartingDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("EmployeeId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("FAClassCodeId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("FASubClassCodeId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("GeneralJournalId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("Insured")
                        .HasColumnType("bit");

                    b.Property<Guid>("MaintenanceVendorId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("NextServiceDate")
                        .HasColumnType("datetime2");

                    b.Property<double>("NoOfDepreciataionYears")
                        .HasColumnType("float");

                    b.Property<string>("SerialNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("UnderMaintenance")
                        .HasColumnType("bit");

                    b.Property<Guid>("VendorId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("WarrantyDate")
                        .HasColumnType("datetime2");

                    b.HasKey("FixedAssetCardId");

                    b.HasIndex("EmployeeId");

                    b.HasIndex("FAClassCodeId");

                    b.HasIndex("FASubClassCodeId");

                    b.HasIndex("GeneralJournalId");

                    b.HasIndex("MaintenanceVendorId");

                    b.HasIndex("VendorId");

                    b.ToTable("FixedAssetCards");
                });

            modelBuilder.Entity("SmilyAccountant.Areas.Finance.Models.GLAccountCard", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("AccountCategoryId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("AccountName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("AccountNo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("AccountSubCategoryId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("AccountTypeId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<decimal>("Balance")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("DebitCredit")
                        .HasColumnType("int");

                    b.Property<Guid?>("GeneralJournalId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("AccountCategoryId");

                    b.HasIndex("AccountSubCategoryId");

                    b.HasIndex("AccountTypeId");

                    b.HasIndex("GeneralJournalId");

                    b.ToTable("GLAccountCards");
                });

            modelBuilder.Entity("SmilyAccountant.Areas.Finance.Models.GeneralJournal", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<decimal>("Amount")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("AmountWithTax")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("Comment")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid?>("CurrencyId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DocumentNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("DocumentType")
                        .HasColumnType("int");

                    b.Property<Guid>("GLAccountCardId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("GeneralPostingType")
                        .HasColumnType("int");

                    b.Property<bool>("IsPosted")
                        .HasColumnType("bit");

                    b.Property<DateTime>("PostingDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("CurrencyId");

                    b.HasIndex("GLAccountCardId");

                    b.ToTable("GeneralJournals");
                });

            modelBuilder.Entity("SmilyAccountant.Areas.GeneralAdministration.Models.City", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("CountryId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("CreatedBy")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<string>("ModifiedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<Guid>("StateId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("UpdatedDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("CountryId");

                    b.HasIndex("StateId");

                    b.ToTable("Cities");
                });

            modelBuilder.Entity("SmilyAccountant.Areas.GeneralAdministration.Models.Contact", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Contacts");
                });

            modelBuilder.Entity("SmilyAccountant.Areas.GeneralAdministration.Models.Country", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.Property<string>("CreatedBy")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<string>("ModifiedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<DateTime>("UpdatedDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Countries");
                });

            modelBuilder.Entity("SmilyAccountant.Areas.GeneralAdministration.Models.Currency", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid?>("GeneralJournalId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("GeneralJournalId");

                    b.ToTable("Currencies");
                });

            modelBuilder.Entity("SmilyAccountant.Areas.GeneralAdministration.Models.Employee", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Address2")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("BankAccountNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("BankBranchNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("BirthDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("City")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CompanyEmail")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CompanyPhone")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CountryId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("EmployeeNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("EmployementDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("EmploymenetStatus")
                        .HasColumnType("int");

                    b.Property<string>("Extension")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Gender")
                        .HasColumnType("int");

                    b.Property<string>("IBAN")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("InactiveDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Initials")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("JobTitle")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MiddleName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PostalCode")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PrivateEmail")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PrivatePhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Region")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SSN")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SwiftCode")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("TerminationDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Employees");
                });

            modelBuilder.Entity("SmilyAccountant.Areas.GeneralAdministration.Models.State", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.Property<Guid>("CountryID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("CreatedBy")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<string>("ModifiedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<DateTime>("UpdatedDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("CountryID");

                    b.ToTable("States");
                });

            modelBuilder.Entity("SmilyAccountant.Areas.GeneralAdministration.Models.Vendor", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Address2")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("BalanceDue")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("BalanceLCY")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("BalanceLCYasCustomer")
                        .HasColumnType("decimal(18,2)");

                    b.Property<Guid>("CityId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("CountryId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MobilePhone")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PostalCode")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("PrimaryContactId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("SecondaryContactId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("StateProvince")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("VendorNo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CityId");

                    b.HasIndex("CountryId");

                    b.HasIndex("PrimaryContactId");

                    b.HasIndex("SecondaryContactId");

                    b.ToTable("Vendors");
                });

            modelBuilder.Entity("SmilyAccountant.Areas.Finance.Models.AccountSubCategory", b =>
                {
                    b.HasOne("SmilyAccountant.Areas.Finance.Models.AccountCategory", "AccountCategory")
                        .WithMany("SubCategories")
                        .HasForeignKey("AccountCategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("AccountCategory");
                });

            modelBuilder.Entity("SmilyAccountant.Areas.Finance.Models.BankDeposit", b =>
                {
                    b.HasOne("SmilyAccountant.Areas.Finance.Models.BankAccount", "BankAccount")
                        .WithMany()
                        .HasForeignKey("BankAccountId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("BankAccount");
                });

            modelBuilder.Entity("SmilyAccountant.Areas.Finance.Models.BudgetDetails", b =>
                {
                    b.HasOne("SmilyAccountant.Areas.Finance.Models.Budget", "Budget")
                        .WithMany()
                        .HasForeignKey("BudgetId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SmilyAccountant.Areas.Finance.Models.GLAccountCard", "GLAccountCard")
                        .WithMany()
                        .HasForeignKey("GLAccountCardId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Budget");

                    b.Navigation("GLAccountCard");
                });

            modelBuilder.Entity("SmilyAccountant.Areas.Finance.Models.ChartOfAccount", b =>
                {
                    b.HasOne("SmilyAccountant.Areas.Finance.Models.GLAccountCard", "GLAccountCard")
                        .WithMany()
                        .HasForeignKey("GLAccountCardId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("GLAccountCard");
                });

            modelBuilder.Entity("SmilyAccountant.Areas.Finance.Models.FASubClassCode", b =>
                {
                    b.HasOne("SmilyAccountant.Areas.Finance.Models.FAClassCode", "FAClassCode")
                        .WithMany("FASubClassCodes")
                        .HasForeignKey("FAClassCodeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("FAClassCode");
                });

            modelBuilder.Entity("SmilyAccountant.Areas.Finance.Models.FixedAssetCard", b =>
                {
                    b.HasOne("SmilyAccountant.Areas.GeneralAdministration.Models.Employee", "Employee")
                        .WithMany()
                        .HasForeignKey("EmployeeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SmilyAccountant.Areas.Finance.Models.FAClassCode", "FAClassCode")
                        .WithMany()
                        .HasForeignKey("FAClassCodeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SmilyAccountant.Areas.Finance.Models.FASubClassCode", "FASubClassCode")
                        .WithMany()
                        .HasForeignKey("FASubClassCodeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SmilyAccountant.Areas.Finance.Models.GeneralJournal", null)
                        .WithMany("FixedAssetCards")
                        .HasForeignKey("GeneralJournalId");

                    b.HasOne("SmilyAccountant.Areas.GeneralAdministration.Models.Vendor", "MaintenanceVendor")
                        .WithMany()
                        .HasForeignKey("MaintenanceVendorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SmilyAccountant.Areas.GeneralAdministration.Models.Vendor", "Vendor")
                        .WithMany()
                        .HasForeignKey("VendorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Employee");

                    b.Navigation("FAClassCode");

                    b.Navigation("FASubClassCode");

                    b.Navigation("MaintenanceVendor");

                    b.Navigation("Vendor");
                });

            modelBuilder.Entity("SmilyAccountant.Areas.Finance.Models.GLAccountCard", b =>
                {
                    b.HasOne("SmilyAccountant.Areas.Finance.Models.AccountCategory", "AccountCategory")
                        .WithMany()
                        .HasForeignKey("AccountCategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SmilyAccountant.Areas.Finance.Models.AccountSubCategory", "AccountSubCategory")
                        .WithMany()
                        .HasForeignKey("AccountSubCategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SmilyAccountant.Areas.Finance.Models.AccountType", "AccountType")
                        .WithMany()
                        .HasForeignKey("AccountTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SmilyAccountant.Areas.Finance.Models.GeneralJournal", null)
                        .WithMany("GLAccountCards")
                        .HasForeignKey("GeneralJournalId");

                    b.Navigation("AccountCategory");

                    b.Navigation("AccountSubCategory");

                    b.Navigation("AccountType");
                });

            modelBuilder.Entity("SmilyAccountant.Areas.Finance.Models.GeneralJournal", b =>
                {
                    b.HasOne("SmilyAccountant.Areas.GeneralAdministration.Models.Currency", "Currency")
                        .WithMany()
                        .HasForeignKey("CurrencyId");

                    b.HasOne("SmilyAccountant.Areas.Finance.Models.GLAccountCard", "GLAccountCard")
                        .WithMany()
                        .HasForeignKey("GLAccountCardId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Currency");

                    b.Navigation("GLAccountCard");
                });

            modelBuilder.Entity("SmilyAccountant.Areas.GeneralAdministration.Models.City", b =>
                {
                    b.HasOne("SmilyAccountant.Areas.GeneralAdministration.Models.Country", "Country")
                        .WithMany("Cities")
                        .HasForeignKey("CountryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SmilyAccountant.Areas.GeneralAdministration.Models.State", "State")
                        .WithMany()
                        .HasForeignKey("StateId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Country");

                    b.Navigation("State");
                });

            modelBuilder.Entity("SmilyAccountant.Areas.GeneralAdministration.Models.Currency", b =>
                {
                    b.HasOne("SmilyAccountant.Areas.Finance.Models.GeneralJournal", null)
                        .WithMany("Currencies")
                        .HasForeignKey("GeneralJournalId");
                });

            modelBuilder.Entity("SmilyAccountant.Areas.GeneralAdministration.Models.State", b =>
                {
                    b.HasOne("SmilyAccountant.Areas.GeneralAdministration.Models.Country", "Country")
                        .WithMany("States")
                        .HasForeignKey("CountryID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Country");
                });

            modelBuilder.Entity("SmilyAccountant.Areas.GeneralAdministration.Models.Vendor", b =>
                {
                    b.HasOne("SmilyAccountant.Areas.GeneralAdministration.Models.City", "City")
                        .WithMany()
                        .HasForeignKey("CityId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SmilyAccountant.Areas.GeneralAdministration.Models.Country", "Country")
                        .WithMany()
                        .HasForeignKey("CountryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SmilyAccountant.Areas.GeneralAdministration.Models.Contact", "PrimaryContact")
                        .WithMany()
                        .HasForeignKey("PrimaryContactId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SmilyAccountant.Areas.GeneralAdministration.Models.Contact", "SecondaryContact")
                        .WithMany()
                        .HasForeignKey("SecondaryContactId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("City");

                    b.Navigation("Country");

                    b.Navigation("PrimaryContact");

                    b.Navigation("SecondaryContact");
                });

            modelBuilder.Entity("SmilyAccountant.Areas.Finance.Models.AccountCategory", b =>
                {
                    b.Navigation("SubCategories");
                });

            modelBuilder.Entity("SmilyAccountant.Areas.Finance.Models.FAClassCode", b =>
                {
                    b.Navigation("FASubClassCodes");
                });

            modelBuilder.Entity("SmilyAccountant.Areas.Finance.Models.GeneralJournal", b =>
                {
                    b.Navigation("Currencies");

                    b.Navigation("FixedAssetCards");

                    b.Navigation("GLAccountCards");
                });

            modelBuilder.Entity("SmilyAccountant.Areas.GeneralAdministration.Models.Country", b =>
                {
                    b.Navigation("Cities");

                    b.Navigation("States");
                });
#pragma warning restore 612, 618
        }
    }
}
