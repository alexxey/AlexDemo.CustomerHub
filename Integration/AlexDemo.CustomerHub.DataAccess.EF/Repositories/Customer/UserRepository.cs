using AlexDemo.CustomerHub.Core.Application.Contracts.Persistence.Customer;
using AlexDemo.CustomerHub.Core.Entities.Customer;
using AlexDemo.CustomerHub.Core.Enums;
using AlexDemo.CustomerHub.DataAccess.EF.DbContexts;

using Microsoft.EntityFrameworkCore;

namespace AlexDemo.CustomerHub.DataAccess.EF.Repositories.Customer
{
    public class UserRepository : GenericRepository<User, int>, IUserRepository
    {
        public UserRepository(CustomerHubDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<List<User>> GetAllByCompany(int companyId)
        {
            return await DbContext.Set<User>()
                .Where(x => x.Status != Status.Deleted && x.CompanyId == companyId)
                .ToListAsync();
        }

        public async Task<List<User>> GetAllByCompanyOffice(int companyOfficeId)
        {
            return await DbContext.Set<User>()
                .Where(x => x.Status != Status.Deleted && x.PrimaryOfficeId == companyOfficeId)
                .ToListAsync();
        }

        public async Task<bool> IsLoginUnique(string createDtoLogin, int createDtoCompanyId)
        {
            // here we do not take into account if login were removed already or not - it stays unique in context of company once created
            return await DbContext.Set<User>()
                .FirstOrDefaultAsync(x => x.Login == createDtoLogin && x.CompanyId == createDtoCompanyId) != null;
        }
    }
}
