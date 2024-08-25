using AlexDemo.CustomerHub.Core.Enums;

namespace AlexDemo.CustomerHub.Core.Application.Models.DTOs.Portfolio.Project
{
    public class UpdateProjectDto : BaseDto<int>, IBaseStatusDto
    {
        public decimal ProjectBudget { get; set; }

        public DateTime? StartDate { get; set; }

        public DateTime? EndDate { get; set; }

        public string? Description { get; set; }

        public ProjectStatus ProjectStatus { get; set; }

        public Status Status { get; set; }
    }
}
