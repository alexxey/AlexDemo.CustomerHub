using AlexDemo.CustomerHub.Core.Application.UseCases.Common.Actions.Commands;
using AlexDemo.CustomerHub.Core.Application.UseCases.Customer.Company.Actions.Responses;

namespace AlexDemo.CustomerHub.Core.Application.UseCases.Customer.Company.Actions.Commands
{
    public class DeleteCompanyCommand : DeleteEntityCommand<int, DeleteCompanyCommandResponse>
    {
    }
}
