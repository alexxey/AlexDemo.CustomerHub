﻿using AlexDemo.CustomerHub.Core.Application.Contracts.Persistence;
using AlexDemo.CustomerHub.Core.Entities.Customer;

namespace AlexDemo.CustomerHub.Core.Application.Contracts.Persistence.Customer
{
    public interface IUserRepository : IGenericRepository<User, int>
    {
        public Task<List<User>> GetAllByCompany(int companyId);

        public Task<List<User>> GetAllByCompanyOffice(int companyOfficeId);

        Task<bool> IsLoginUnique(string createDtoLogin, int createDtoCompanyId);
    }
}
