﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SmilyAccountant.Data;

#nullable disable

namespace SmilyAccountant.Migrations
{
    [DbContext(typeof(SmilyAccountantContext))]
    [Migration("20240104212510_Updating AccountSubCategory ForeignKey")]
    partial class UpdatingAccountSubCategoryForeignKey
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.14")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("SmilyAccountant.Models.AccountCategory", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("AccountSubCategoryId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("GLAccountCardId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("AccountSubCategoryId");

                    b.HasIndex("GLAccountCardId");

                    b.ToTable("AccountCategories");
                });

            modelBuilder.Entity("SmilyAccountant.Models.AccountSubCategory", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("AccountCategoryId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("GLAccountCardId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("GLAccountCardId");

                    b.ToTable("AccountSubCategories");
                });

            modelBuilder.Entity("SmilyAccountant.Models.AccountType", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("GLAccountCardId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("GLAccountCardId");

                    b.ToTable("AccountTypes");
                });

            modelBuilder.Entity("SmilyAccountant.Models.GLAccountCard", b =>
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

                    b.HasKey("Id");

                    b.ToTable("GLAccountCards");
                });

            modelBuilder.Entity("SmilyAccountant.Models.AccountCategory", b =>
                {
                    b.HasOne("SmilyAccountant.Models.AccountSubCategory", null)
                        .WithMany("AccountCategories")
                        .HasForeignKey("AccountSubCategoryId");

                    b.HasOne("SmilyAccountant.Models.GLAccountCard", null)
                        .WithMany("Categories")
                        .HasForeignKey("GLAccountCardId");
                });

            modelBuilder.Entity("SmilyAccountant.Models.AccountSubCategory", b =>
                {
                    b.HasOne("SmilyAccountant.Models.GLAccountCard", null)
                        .WithMany("AccountSubCategories")
                        .HasForeignKey("GLAccountCardId");
                });

            modelBuilder.Entity("SmilyAccountant.Models.AccountType", b =>
                {
                    b.HasOne("SmilyAccountant.Models.GLAccountCard", null)
                        .WithMany("AccountTypes")
                        .HasForeignKey("GLAccountCardId");
                });

            modelBuilder.Entity("SmilyAccountant.Models.AccountSubCategory", b =>
                {
                    b.Navigation("AccountCategories");
                });

            modelBuilder.Entity("SmilyAccountant.Models.GLAccountCard", b =>
                {
                    b.Navigation("AccountSubCategories");

                    b.Navigation("AccountTypes");

                    b.Navigation("Categories");
                });
#pragma warning restore 612, 618
        }
    }
}
