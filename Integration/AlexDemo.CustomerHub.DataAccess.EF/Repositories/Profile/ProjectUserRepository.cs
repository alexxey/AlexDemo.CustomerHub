using AlexDemo.CustomerHub.Core.Application.Persistence.Contracts.Portfolio;
using AlexDemo.CustomerHub.Core.Entities.Portfolio;
using AlexDemo.CustomerHub.Core.Enums;
using AlexDemo.CustomerHub.DataAccess.EF.DbContexts;
using Microsoft.EntityFrameworkCore;

namespace AlexDemo.CustomerHub.DataAccess.EF.Repositories.Profile
{
    public class ProjectUserRepository : GenericRepository<ProjectUser, long>, IProjectUserRepository
    {
        public ProjectUserRepository(CustomerHubDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<List<ProjectUser>> GetAllByProject(int projectId)
        {
            return await DbContext.Set<ProjectUser>()
                .Where(x => x.Status != Status.Deleted && x.ProjectId == projectId)
                .ToListAsync();
        }

        public async Task<List<ProjectUser>> GetAllByUser(int userId)
        {
            return await DbContext.Set<ProjectUser>()
                .Where(x => x.Status != Status.Deleted && x.UserId == userId)
                .ToListAsync();
        }
    }
}
