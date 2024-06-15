using SmilyAccountant.Areas.GeneralAdministration.Models.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SmilyAccountant.Areas.GeneralAdministration.Models
{
    public class Employee
    {
        public Guid Id { get; set; }


        [Display(Name = "Employee No")]
        public required string EmployeeNumber { get; set; }


        [Display(Name = "First Name")]
        public required string FirstName { get; set; }


        [Display(Name = "Middle Name")]
        public string? MiddleName { get; set; }


        [Display(Name = "Last Name")]
        public required string LastName { get; set; }

        [NotMapped]
        [Display(Name = "Full Name")]
        public string FullName { get { return FirstName + " " + LastName; } }

        [Display(Name = "Job title")]
        public string? JobTitle { get; set; }

        public string? Initials { get; set; }

        public Gender Gender { get; set; }

        [Display(Name = "Company Email")]
        public string? CompanyEmail { get; set; }


        [Display(Name = "Company Phone")]
        public string? CompanyPhone { get; set; }

        public string? Extension { get; set; }


        [Display(Name = "Private Email")]
        public string? PrivateEmail { get; set; }


        [Display(Name = "Private Phone Number")]
        public string? PrivatePhoneNumber { get; set; }

        public string? Address { get; set; }


        [Display(Name = "Address 2")]
        public string? Address2 { get; set; }

        public string? City { get; set; }


        [Display(Name = "Country Id")]
        public string? CountryId { get; set; }

        public string? Region { get; set; }


        [Display(Name = "Postal Code")]
        public string? PostalCode { get; set; }


        [Display(Name = "Employment Date")]
        public DateTime EmployementDate { get; set; }


        [Display(Name = "Employment Status")]
        public EmploymenetStatus EmploymenetStatus { get; set; }


        [Display(Name = "Invoice Date")]
        public DateTime InactiveDate { get; set; }


        [Display(Name = "Termination Date")]
        public DateTime TerminationDate { get; set; }


        [Display(Name = "Birth Date")]
        public DateTime BirthDate { get; set; }


        [Display(Name = "Sub Category Name")]
        public string? SSN { get; set; }


        [Display(Name = "Bank Branch Number")]
        public string? BankBranchNumber { get; set; }


        [Display(Name = "Bank Account Number")]
        public string? BankAccountNumber { get; set; }

        public string? IBAN { get; set; }

        [Display(Name = "Swift Code")]
        public string? SwiftCode { get; set; }
    }
}
