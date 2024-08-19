using AlexDemo.CustomerHub.Core.Entities.Customer;

namespace AlexDemo.CustomerHub.Core.Application.Persistence.Contracts.Customer
{
    public interface IUserRepository : IGenericRepository<User, int>
    {
        public Task<List<User>> GetAllByCompany(int companyId);

        public Task<List<User>> GetAllByCompanyOffice(int companyOfficeId);
    }
}
