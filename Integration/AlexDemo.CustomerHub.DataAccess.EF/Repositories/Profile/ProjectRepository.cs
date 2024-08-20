using AlexDemo.CustomerHub.Core.Application.Persistence.Contracts.Portfolio;
using AlexDemo.CustomerHub.Core.Entities.Portfolio;
using AlexDemo.CustomerHub.Core.Enums;
using AlexDemo.CustomerHub.DataAccess.EF.DbContexts;
using Microsoft.EntityFrameworkCore;

namespace AlexDemo.CustomerHub.DataAccess.EF.Repositories.Profile
{
    public class ProjectRepository : GenericRepository<Project, int>, IProjectRepository
    {
        public ProjectRepository(CustomerHubDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<List<Project>> GetAllByCompany(int companyId)
        {
            return await DbContext.Set<Project>()
                .Where(x => x.Status != Status.Deleted && x.CompanyId == companyId)
                .ToListAsync();
        }

        public async Task<List<Project>> GetAllByCompanyOffice(int companyOfficeId)
        {
            return await DbContext.Set<Project>()
                .Where(x => x.Status != Status.Deleted && x.ResponsibleOfficeId == companyOfficeId)
                .ToListAsync();
        }

        public async Task<List<Project>> GetAllByUser(int userId)
        {
            return await DbContext.Set<Project>()
                .Where(x => x.Status != Status.Deleted && x.ProjectOwnerId == userId)
                .ToListAsync();
        }
    }
}
