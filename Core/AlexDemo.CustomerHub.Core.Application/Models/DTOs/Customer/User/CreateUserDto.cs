using AlexDemo.CustomerHub.Core.Enums;

namespace AlexDemo.CustomerHub.Core.Application.Models.DTOs.Customer.User
{
    public class CreateUserDto
    {
        public string? FirstName { get; set; }

        public string? LastName { get; set; }

        public DateTime DateOfBirth { get; set; }

        public required string Login { get; set; }

        public required string Password { get; set; }

        public EmployeeCompanyRole CompanyRole { get; set; }

        public required string Email { get; set; }

        public int PrimaryOfficeId { get; set; }

        public int CompanyId { get; set; }
    }
}
