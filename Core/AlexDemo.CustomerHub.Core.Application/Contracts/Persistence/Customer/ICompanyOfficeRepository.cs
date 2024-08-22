using AlexDemo.CustomerHub.Core.Application.Contracts.Persistence;
using AlexDemo.CustomerHub.Core.Entities.Customer;

namespace AlexDemo.CustomerHub.Core.Application.Contracts.Persistence.Customer
{
    public interface ICompanyOfficeRepository : IGenericRepository<CompanyOffice, int>
    {
        public Task<List<CompanyOffice>> GetAllByCompany(int companyId);
    }
}
