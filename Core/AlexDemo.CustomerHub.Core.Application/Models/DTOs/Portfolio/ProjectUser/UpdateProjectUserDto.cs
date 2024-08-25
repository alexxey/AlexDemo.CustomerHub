using AlexDemo.CustomerHub.Core.Enums;

namespace AlexDemo.CustomerHub.Core.Application.Models.DTOs.Portfolio.ProjectUser
{
    public class UpdateProjectUserDto : BaseDto<long>, IBaseStatusDto
    {
        public DateTime EndDate { get; set; }

        public ProjectUserRole CurrentRole { get; set; }

        public string? PositionDescription { get; set; }

        public Status Status { get; set; }
    }
}
