using AlexDemo.CustomerHub.Core.Application.Models.DTOs.Customer.CompanyOffice;

namespace AlexDemo.CustomerHub.Core.Application.UseCases.Customer.CompanyOffice.Actions.Queries
{
    public class GetCompanyOfficeDetailsRequest : IRequest<CompanyOfficeDetailsDto>
    {
        public int Id { get; set; }
    }
}
