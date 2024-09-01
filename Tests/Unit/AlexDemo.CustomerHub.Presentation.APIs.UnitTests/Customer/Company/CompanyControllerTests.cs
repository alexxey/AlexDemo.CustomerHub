using AlexDemo.CustomerHub.Core.Application.Contracts.Persistence.Customer;
using AlexDemo.CustomerHub.Core.Application.UseCases.Customer.Company.Handlers.Commands;
using AutoMapper;
using Moq;

namespace AlexDemo.CustomerHub.Presentation.APIs.UnitTests.Customer.Company
{
    public class CompanyControllerTests
    {
        private CreateCompanyCommandHandler _createCompanyCommandHandler;
        private readonly Mock<ICompanyRepository> _companyRepositoryMock = new Mock<ICompanyRepository>();
        private readonly Mock<IMapper> _mapperMock = new Mock<IMapper>();
       
        public CompanyControllerTests()
        {


        }

        [Fact]
        public async Task CreateCompany_ValidInfo_Added()
        {
            throw new NotImplementedException();
        }
    }
}