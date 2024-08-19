using AlexDemo.CustomerHub.Core.Enums;

namespace AlexDemo.CustomerHub.Core.Application.Models.DTOs.Portfolio.ProjectUser
{
    public record CreateProjectUserDto
    {
        public int ProjectId { get; set; }

        public int UserId { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime? EndDate { get; set; }

        public ProjectUserRole CurrentRole { get; set; }

        public string? PositionDescription { get; set; }
    }
}
