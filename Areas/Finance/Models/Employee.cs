using SmilyAccountant.Areas.Finance.Models.Enums;
using System.ComponentModel.DataAnnotations;

namespace SmilyAccountant.Areas.Finance.Models
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

        [Display(Name = "Job title")]
        public string? JobTitle { get; set; }

        public string? Initials { get; set; }

        public Gender Gender { get; set; }

        [Display(Name = "Company Email")]
        public string? CompanyEmail { get; set; }
        public string? CompanyPhone { get; set; }
        public string? Extension { get; set; }
        public string? PrivateEmail { get; set; }
        public string? PrivatePhoneNumber { get; set; }
        public string? Address { get; set; }
        public string? Address2 { get; set; }
        public string? City { get; set; }
        public string? CountryId { get; set; }
        public string? Region { get; set; }
        public string? PostalCode { get; set; }

        public DateTime EmployementDate { get; set; }
        public EmploymenetStatus EmploymenetStatus { get; set; } 
        public DateTime InactiveDate { get; set; }
        public DateTime TerminationDate { get; set; }

        public DateTime BirthDate { get; set; }
        public string? SSN { get; set; }

        public string? BankBranchNumber { get; set; }
        public string? BankAccountNumber { get; set; }
        public string? IBAN { get; set; }
        public string? SwiftCode { get; set; }
    }
}
