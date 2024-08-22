using AlexDemo.CustomerHub.Core.Application.UseCases.Common.Actions.Commands;

namespace AlexDemo.CustomerHub.Core.Application.UseCases.Customer.User.Actions.Commands
{
    public record DeleteUserCommand : DeleteEntityCommand<int>
    {
    }
}
