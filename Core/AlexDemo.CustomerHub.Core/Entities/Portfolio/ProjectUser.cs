using AlexDemo.CustomerHub.Core.Entities.Customer;
using AlexDemo.CustomerHub.Core.Enums;

namespace AlexDemo.CustomerHub.Core.Entities.Portfolio
{
    public sealed class ProjectUser : BaseMonitoredEntity
    {
        public long Id { get; set; }

        public int ProjectId { get; set; }

        public Project? Project { get; set; }

        public int UserId { get; set; }

        public User? User { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public ProjectUserRole CurrentRole { get; set; }

        public string? PositionDescription { get; set; }
    }
}
