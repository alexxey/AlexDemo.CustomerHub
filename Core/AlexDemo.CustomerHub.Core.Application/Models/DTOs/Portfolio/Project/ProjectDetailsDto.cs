using AlexDemo.CustomerHub.Core.Application.Models.DTOs.Customer.CompanyOffice;
using AlexDemo.CustomerHub.Core.Application.Models.DTOs.Customer.User;
using AlexDemo.CustomerHub.Core.Enums;

namespace AlexDemo.CustomerHub.Core.Application.Models.DTOs.Portfolio.Project
{
    public record ProjectDetailsDto : BaseDto<int>
    {
        public required string ProjectCode { get; set; }

        public required string Name { get; set; }

        public string? Description { get; set; }

        public decimal ProjectBudget { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime? EndDate { get; set; }

        public ProjectStatus ProjectStatus { get; set; }

        public int ResponsibleOfficeId { get; set; }

        public CompanyOfficeDetailsDto? ResponsibleOffice { get; set; }

        public int CompanyId { get; set; }

        public int ProjectOwnerId { get; set; }

        public UserDetailsDto? ProjectOwner { get; set; }
    }
}
