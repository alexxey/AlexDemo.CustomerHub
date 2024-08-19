using AlexDemo.CustomerHub.Core.Entities.Portfolio;

namespace AlexDemo.CustomerHub.Core.Application.Persistence.Contracts.Portfolio
{
    public interface IProjectRepository : IGenericRepository<Project, int>
    {
        public Task<List<Project>> GetAllByCompany(int companyId);

        public Task<List<Project>> GetAllByCompanyOffice(int companyOfficeId);

        public Task<List<Project>> GetAllByUser(int userId);
    }
}
