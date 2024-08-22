using AlexDemo.CustomerHub.Core.Application.Models.DTOs.Customer.CompanyOffice;

namespace AlexDemo.CustomerHub.Core.Application.UseCases.Customer.CompanyOffice.Actions.Commands
{
    public record CreateCompanyOfficeCommand : IRequest<int>
    {
        public CreateCompanyOfficeDto CreateDto { get; set; }
    }
}
