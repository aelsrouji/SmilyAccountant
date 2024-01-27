using Humanizer;
using SmilyAccountant.Areas.Finance.Models.Enums;

namespace SmilyAccountant.Areas.Finance.Models
{
    public class Employee
    {
        public Guid Id { get; set; }
        public required string EmployeeNumber { get; set; }
        public required string FirstName { get; set; }
        public string? MiddleName { get; set; }
        public required string LastName { get; set; }
        public string? JobTitle { get; set; }
        public string? Initials { get; set; }
        public Gender Gender { get; set; }
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
