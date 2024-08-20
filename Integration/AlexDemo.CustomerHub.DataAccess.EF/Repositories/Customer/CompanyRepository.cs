using AlexDemo.CustomerHub.Core.Application.Persistence.Contracts.Customer;
using AlexDemo.CustomerHub.Core.Entities.Customer;
using AlexDemo.CustomerHub.DataAccess.EF.DbContexts;

namespace AlexDemo.CustomerHub.DataAccess.EF.Repositories.Customer
{
    public sealed class CompanyRepository : GenericRepository<Company, int>, ICompanyRepository
    {
        public CompanyRepository(CustomerHubDbContext dbContext) : base(dbContext)
        {
        }
    }
}
