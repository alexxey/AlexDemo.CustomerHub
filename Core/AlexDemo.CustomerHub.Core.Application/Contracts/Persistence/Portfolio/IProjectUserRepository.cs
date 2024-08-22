using AlexDemo.CustomerHub.Core.Application.Contracts.Persistence;
using AlexDemo.CustomerHub.Core.Entities.Portfolio;

namespace AlexDemo.CustomerHub.Core.Application.Contracts.Persistence.Portfolio
{
    public interface IProjectUserRepository : IGenericRepository<ProjectUser, long>
    {
        public Task<List<ProjectUser>> GetAllByProject(int projectId);

        public Task<List<ProjectUser>> GetAllByUser(int userId);
    }
}
