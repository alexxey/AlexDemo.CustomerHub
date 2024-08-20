using AlexDemo.CustomerHub.Core.Application.Persistence.Contracts.Customer;
using AlexDemo.CustomerHub.Core.Entities.Customer;
using AlexDemo.CustomerHub.Core.Enums;
using AlexDemo.CustomerHub.DataAccess.EF.DbContexts;
using Microsoft.EntityFrameworkCore;

namespace AlexDemo.CustomerHub.DataAccess.EF.Repositories.Customer
{
    public sealed class CompanyOfficeRepository : GenericRepository<CompanyOffice, int>, ICompanyOfficeRepository
    {
        public CompanyOfficeRepository(CustomerHubDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<List<CompanyOffice>> GetAllByCompany(int companyId)
        {
            return await DbContext.Set<CompanyOffice>()
                .Where(x => x.Status != Status.Deleted && x.CompanyId == companyId)
                .ToListAsync();
        }
    }
}
