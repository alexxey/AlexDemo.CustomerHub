using AlexDemo.CustomerHub.Core.Entities.Portfolio;
using AlexDemo.CustomerHub.Core.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AlexDemo.CustomerHub.DataAccess.EF.Configurations.Entities.Portfolio
{
    internal class ProjectConfiguration : IEntityTypeConfiguration<Project> 
    {
        public void Configure(EntityTypeBuilder<Project> modelBuilder)
        {
            int bentleyHeadOfficeId = 1;
            int bentleyCompanyId = 1;

            int astonHeadOfficeId = 2;
            int astonMartinCompanyId = 2;

            var bentleyProject = new Project
            {
                CompanyId = bentleyCompanyId,
                ResponsibleOfficeId = bentleyHeadOfficeId,
                Id = 1,
                Name = "first bentley project",
                Description = "test bentley project",
                StartDate = DateTime.UtcNow.AddDays(7),
                Status = Status.Draft,
                ProjectCode = "BNTL-TEST",
                ProjectOwnerId = 1
            };

            var bentleyProject2 = new Project
            {
                CompanyId = bentleyCompanyId,
                ResponsibleOfficeId = bentleyHeadOfficeId,
                Id = 3,
                Name = "second bentley project",
                Description = "second test bentley project",
                StartDate = DateTime.UtcNow.AddDays(1),
                Status = Status.Draft,
                ProjectCode = "BNTL-TEST-2",
                ProjectOwnerId = 1
            };

            modelBuilder.HasData(bentleyProject, bentleyProject2);
        }
    }
}
