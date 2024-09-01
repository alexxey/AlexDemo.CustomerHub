using AlexDemo.CustomerHub.Core.Application.Contracts.Persistence.Customer;
using AlexDemo.CustomerHub.Core.Application.Models.DTOs.Customer.Company;
using AlexDemo.CustomerHub.Core.Application.Profiles;
using AlexDemo.CustomerHub.Core.Application.UseCases.Customer.Company.Actions.Commands;
using AlexDemo.CustomerHub.Core.Application.UseCases.Customer.Company.Actions.Responses;
using AlexDemo.CustomerHub.Core.Application.UseCases.Customer.Company.Handlers.Commands;
using AlexDemo.CustomerHub.Core.Enums;
using AutoMapper;
using Moq;

namespace AlexDemo.CustomerHub.Core.Application.UnitTests.UseCases.Customer.Company
{
    public class UpdateCompanyCommandHandlerTests
    {
        private readonly Mock<ICompanyRepository> _companyRepositoryMock = new();
        private IMapper _mapper;

        public UpdateCompanyCommandHandlerTests()
        {
            var mapperConfig = new MapperConfiguration(c =>
            {
                c.AddProfile<MappingProfile>();
            });
            _mapper = new Mapper(mapperConfig);
        }

        [Fact]
        public async Task Handle_ValidInfo_ShouldCreateSuccessResult()
        {
            // arrange 
            var updateCompanyDto = new UpdateCompanyDto
            {
                Id = 12345,
                AnnualRevenue = 123,
                NumberOfEmployees = 123,
                CeoName = "Test CEO",
                Email = "Test Email",
                WebSite = "Test Website",
                Status = Status.Active
            };

            var companyEntity = new Entities.Customer.Company
            {
                BrandName = "TEST Company",
                HeadOfficeCountry = Country.Sweden,
                AnnualRevenue = 999,
                NumberOfEmployees = 888,
                Status = Status.Draft,
                Id = 12345
            };

            var updateCompanyCommand = new UpdateCompanyCommand
            {
                UpdateDto = updateCompanyDto
            };

            var updateCompanyCommandHandler = new UpdateCompanyCommandHandler(_companyRepositoryMock.Object, _mapper);

            // todo alex: validation setup?

            _companyRepositoryMock.Setup(x => x.GetById(
                    It.Is<int>(data => data.Equals(12345))))
                .ReturnsAsync(companyEntity);

            _companyRepositoryMock.Setup(x => x.Update(
                It.Is<Entities.Customer.Company>(data => data.Id == 12345))).Returns(Task.CompletedTask);

            var expectedUpdateCompanyResponse = new UpdateCompanyCommandResponse
            {
                Id = companyEntity.Id,
                IsSuccessful = true,
                Message = "Company updated"
            };

            // act 
            var actualUpdateCompanyCommandResponse = await updateCompanyCommandHandler.Handle(updateCompanyCommand, CancellationToken.None);

            // assert
            // ensure that response is of expected type
            Assert.IsType<UpdateCompanyCommandResponse>(actualUpdateCompanyCommandResponse);

            // additional checks : but we set this ourselves earlier
            Assert.True(actualUpdateCompanyCommandResponse.IsSuccessful);
            Assert.Equal(expectedUpdateCompanyResponse.Id, actualUpdateCompanyCommandResponse.Id);
        }
    }
}
