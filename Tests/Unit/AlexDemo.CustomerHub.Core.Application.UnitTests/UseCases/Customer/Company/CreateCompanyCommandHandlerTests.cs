using AlexDemo.CustomerHub.Core.Application.Contracts.Persistence.Customer;
using AlexDemo.CustomerHub.Core.Application.Models.DTOs.Customer.Company;
using AlexDemo.CustomerHub.Core.Application.UseCases.Customer.Company.Actions.Commands;
using AlexDemo.CustomerHub.Core.Application.UseCases.Customer.Company.Actions.Responses;
using AlexDemo.CustomerHub.Core.Application.UseCases.Customer.Company.Handlers.Commands;
using AlexDemo.CustomerHub.Core.Enums;
using AutoMapper;
using Moq;

namespace AlexDemo.CustomerHub.Core.Application.UnitTests.UseCases.Customer.Company
{
    public class CreateCompanyCommandHandlerTests
    {
        private readonly Mock<ICompanyRepository> _companyRepositoryMock = new Mock<ICompanyRepository>();
        private readonly Mock<IMapper> _mapperMock = new Mock<IMapper>();

        [Fact]
        public async Task Handle_ValidInfo_ShouldCreateSuccessResult()
        {
            // arrange 
            var createCompanyDto = new CreateCompanyDto
            {
                BrandName = "Tesla",
                HeadOfficeCountry = Country.USA,
                AnnualRevenue = 123,
                NumberOfEmployees = 123
            };

            var createCompanyCommand = new CreateCompanyCommand
            {
                CreateDto = createCompanyDto
            };

            var companyEntity = new Entities.Customer.Company
            {
                BrandName = createCompanyDto.BrandName,
                HeadOfficeCountry = createCompanyDto.HeadOfficeCountry,
                AnnualRevenue = createCompanyDto.AnnualRevenue,
                NumberOfEmployees = createCompanyDto.NumberOfEmployees,
                Status = Status.Active,
                Id = 12345
            };

            var createCompanyResponse = new CreateCompanyCommandResponse
            {
                Data = null,
                Id = companyEntity.Id,
                IsSuccessful = true,
                Message = "Company created"
            };

            var createCompanyCommandHandler = new CreateCompanyCommandHandler(_companyRepositoryMock.Object, _mapperMock.Object);

            _companyRepositoryMock.Setup(x => x.Create(
                    It.IsAny<Entities.Customer.Company>()))
                .ReturnsAsync(companyEntity);

            _mapperMock.Setup(x => x.Map<Entities.Customer.Company>(
                It.IsAny<CreateCompanyDto>))
                .Returns(companyEntity);

            // act 
           var result = await  createCompanyCommandHandler.Handle(createCompanyCommand, CancellationToken.None);

            // assert
            Assert.True(result.IsSuccessful);
        }
    }
}
