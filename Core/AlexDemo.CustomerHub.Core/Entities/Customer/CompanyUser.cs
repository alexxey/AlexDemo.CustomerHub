using AlexDemo.CustomerHub.Core.Entities.Portfolio;
using AlexDemo.CustomerHub.Core.Enums;

namespace AlexDemo.CustomerHub.Core.Entities.Customer
{
    /// <summary>
    /// business logic related entity to store company-office: user relations only
    /// </summary>
    public sealed class CompanyUser : BaseMonitoredEntity
    {
        public int Id { get; set; }

        /// <summary>
        /// reference to the identity user entity that store login and other authentication user's specific data
        /// </summary>
        public required string IdentityUserId { get; set; } 

        public string? Title { get; set; }

        public string? FirstName { get; set; }

        public string? LastName { get; set; }

        public DateTime DateOfBirth { get; set; }

        public required string DisplayName { get; set; }

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
