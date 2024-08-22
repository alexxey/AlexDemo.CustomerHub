using AlexDemo.CustomerHub.Core.Entities.Portfolio;
using AlexDemo.CustomerHub.Core.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AlexDemo.CustomerHub.DataAccess.EF.Configurations.Entities.Portfolio
{
    internal class ProjectUserConfiguration : IEntityTypeConfiguration<ProjectUser> 
    {
        public void Configure(EntityTypeBuilder<ProjectUser> modelBuilder)
        {
            var bentleyProjectUser = new ProjectUser
            {
                Id = 1,
                ProjectId = 1,
                UserId = 1,
                CurrentRole = ProjectUserRole.Stakeholder,
                StartDate = DateTime.UtcNow,
                Status = Status.Active
            };

            modelBuilder.HasData(bentleyProjectUser);
        }
    }
}
