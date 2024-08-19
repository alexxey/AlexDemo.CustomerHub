using AlexDemo.CustomerHub.Core.Entities.Portfolio;
using AlexDemo.CustomerHub.Core.Enums;

namespace AlexDemo.CustomerHub.Core.Entities.Customer
{
    public sealed class User : BaseMonitoredEntity
    {
        public int Id { get; set; }

        public string? Title { get; set; }

        public string? FirstName { get; set; }

        public string? LastName { get; set; }

        public DateTime DateOfBirth { get; set; }

        public required string Login { get; set; }

        public required string PasswordHash { get; set; }

        public required string PasswordSalt { get; set; }

        public EmployeeCompanyRole CompanyRole { get; set; }

        public required string Email { get; set; }

        /// <summary>
        /// navigation property
        /// </summary>
        public CompanyOffice? PrimaryOffice { get; set; }

        public int PrimaryOfficeId { get; set; }

        /// <summary>
        /// navigation property
        /// </summary>
        public Company? Company { get; set; }

        public int CompanyId { get; set; }

        public List<Project>? Projects { get; set; } = [];

        public List<ProjectUser>? ProjectUsers { get; set; } = [];
    }
}
