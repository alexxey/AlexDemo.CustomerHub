using AlexDemo.CustomerHub.Core.Application.Responses;
using AlexDemo.CustomerHub.Core.Application.UseCases.Common.Actions.Commands;

namespace AlexDemo.CustomerHub.Core.Application.UseCases.Customer.Company.Actions.Commands
{
    public class DeleteCompanyCommand : DeleteEntityCommand<int>, IRequest<BaseModifyCommandResponse<int>>
    {
    }
}
