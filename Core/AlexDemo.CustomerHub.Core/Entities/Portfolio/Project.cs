using AlexDemo.CustomerHub.Core.Entities.Customer;
using AlexDemo.CustomerHub.Core.Enums;

namespace AlexDemo.CustomerHub.Core.Entities.Portfolio
{
    public sealed class Project : BaseMonitoredEntity
    {
        public int Id { get; set; }

        public required string ProjectCode { get; set; }

        public required string Name { get; set; }

        public string? Description { get; set; }

        public decimal ProjectBudget { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime? EndDate { get; set; }

        public ProjectStatus ProjectStatus { get; set; }

        public Status Status { get; set; }

        public int ResponsibleOfficeId { get; set; }

        public CompanyOffice? ResponsibleOffice { get; set; }

        public int CompanyId { get; set; }

        public Company? Company { get; set; }

        public int ProjectOwnerId { get; set; }

        public User? ProjectOwner { get; set; }

        public List<ProjectUser>? ProjectUsers { get; set; } = [];
    }
}
