using AlexDemo.CustomerHub.Core.Entities.Customer;

namespace AlexDemo.CustomerHub.Core.Application.Contracts.Persistence.Customer
{
    public interface IUserRepository : IGenericRepository<CompanyUser, int>
    {
        public Task<List<CompanyUser>> GetAllByCompany(int companyId);

        public Task<List<CompanyUser>> GetAllByCompanyOffice(int companyOfficeId);

        Task<bool> IsLoginUnique(string createDtoLogin, int createDtoCompanyId);
    }
}
