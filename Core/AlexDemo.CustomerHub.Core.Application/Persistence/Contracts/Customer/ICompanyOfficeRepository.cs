using AlexDemo.CustomerHub.Core.Entities.Customer;

namespace AlexDemo.CustomerHub.Core.Application.Persistence.Contracts.Customer
{
    public interface ICompanyOfficeRepository : IGenericRepository<CompanyOffice, int>
    {
        public Task<List<CompanyOffice>> GetAllByCompany(int companyId);
    }
}
