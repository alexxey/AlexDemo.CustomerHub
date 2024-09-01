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
        private readonly Mock<ICompanyRepository> _companyRepositoryMock = new();
        private readonly Mock<IMapper> _mapperMock = new();

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

            var companyEntity = new Entities.Customer.Company
            {
                BrandName = createCompanyDto.BrandName,
                HeadOfficeCountry = createCompanyDto.HeadOfficeCountry,
                AnnualRevenue = createCompanyDto.AnnualRevenue,
                NumberOfEmployees = createCompanyDto.NumberOfEmployees,
                Status = Status.Active,
                Id = 12345
            };

            var createCompanyCommand = new CreateCompanyCommand
            {
                CreateDto = createCompanyDto
            };

            var createCompanyCommandHandler = new CreateCompanyCommandHandler(_companyRepositoryMock.Object, _mapperMock.Object);

            // todo alex: validation setup?
            _companyRepositoryMock.Setup(x => x.Create(
                    It.IsAny<Entities.Customer.Company>()))
                .ReturnsAsync(companyEntity);

            // setup mapping for particular entity only (match by brand and country)
            _mapperMock.Setup(x => x.Map<Entities.Customer.Company>(
                It.Is<CreateCompanyDto>(dto =>
                    dto.BrandName == createCompanyDto.BrandName &&
                    dto.HeadOfficeCountry == createCompanyDto.HeadOfficeCountry)))
                .Returns(companyEntity);

            var expectedCreateCompanyResponse = new CreateCompanyCommandResponse
            {
                Id = companyEntity.Id,
                IsSuccessful = true,
                Message = "Company created"
            };

            // act 
            var actualCreateCompanyCommandResponse = await  createCompanyCommandHandler.Handle(createCompanyCommand, CancellationToken.None);

            // assert
            // ensure that response is of expected type
            Assert.IsType<CreateCompanyCommandResponse>(actualCreateCompanyCommandResponse);

            // additional checks : but we set this ourselves earlier
            Assert.True(actualCreateCompanyCommandResponse.IsSuccessful);
            Assert.Equal(expectedCreateCompanyResponse.Id, actualCreateCompanyCommandResponse.Id);
        }
    }
}
