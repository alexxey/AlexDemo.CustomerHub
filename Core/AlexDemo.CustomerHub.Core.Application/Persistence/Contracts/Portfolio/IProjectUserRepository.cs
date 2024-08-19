using AlexDemo.CustomerHub.Core.Entities.Portfolio;

namespace AlexDemo.CustomerHub.Core.Application.Persistence.Contracts.Portfolio
{
    public interface IProjectUserRepository : IGenericRepository<ProjectUser, long>
    {
        public Task<List<ProjectUser>> GetAllByProject(int project);

        public Task<List<ProjectUser>> GetAllByUser(int user);
    }
}
