using AlexDemo.CustomerHub.Core.Application.Models.DTOs.Customer.Company;
using AlexDemo.CustomerHub.Core.Application.UseCases.Customer.Company.Actions.Responses;

namespace AlexDemo.CustomerHub.Core.Application.UseCases.Customer.Company.Actions.Commands
{
    public class UpdateCompanyCommand : IRequest<UpdateCompanyCommandResponse>
    {
        public UpdateCompanyDto UpdateDto { get; set; }
    }
}
