using AlexDemo.CustomerHub.Core.Application.Models.DTOs.Customer.CompanyOffice;

namespace AlexDemo.CustomerHub.Core.Application.UseCases.Customer.CompanyOffice.Actions.Commands
{
    public class UpdateCompanyOfficeCommand : IRequest<Unit>
    {
        public UpdateCompanyOfficeDto UpdateDto { get; set; }
    }
}
