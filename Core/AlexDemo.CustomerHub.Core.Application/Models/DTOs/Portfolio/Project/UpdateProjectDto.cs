using AlexDemo.CustomerHub.Core.Enums;

namespace AlexDemo.CustomerHub.Core.Application.Models.DTOs.Portfolio.Project
{
    public record UpdateProjectDto : BaseDto<int>
    {
        public decimal ProjectBudget { get; set; }

        public DateTime? StartDate { get; set; }

        public DateTime? EndDate { get; set; }

        public string? Description { get; set; }

        public ProjectStatus ProjectStatus { get; set; }

        public Status Status { get; set; }
    }
}
