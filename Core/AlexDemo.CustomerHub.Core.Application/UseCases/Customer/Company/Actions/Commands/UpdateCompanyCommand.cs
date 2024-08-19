using AlexDemo.CustomerHub.Core.Application.Models.DTOs.Customer.Company;

namespace AlexDemo.CustomerHub.Core.Application.UseCases.Customer.Company.Actions.Commands
{
    public class UpdateCompanyCommand : IRequest<Unit>
    {
        public UpdateCompanyDto UpdateDto { get; set; }
    }
}
