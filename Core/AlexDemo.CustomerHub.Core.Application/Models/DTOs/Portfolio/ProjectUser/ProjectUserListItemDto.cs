using AlexDemo.CustomerHub.Core.Application.Models.DTOs.Customer.User;
using AlexDemo.CustomerHub.Core.Application.Models.DTOs.Portfolio.Project;
using AlexDemo.CustomerHub.Core.Enums;

namespace AlexDemo.CustomerHub.Core.Application.Models.DTOs.Portfolio.ProjectUser
{
    public record ProjectUserListItemDto : BaseDto<long>
    {
        public int ProjectId { get; set; }

        public ProjectDetailsDto? Project { get; set; }

        public int UserId { get; set; }

        public UserDetailsDto? User { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public ProjectUserRole CurrentRole { get; set; }
    }
}
