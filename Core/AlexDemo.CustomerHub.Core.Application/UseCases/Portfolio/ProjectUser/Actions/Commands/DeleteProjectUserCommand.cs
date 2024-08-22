using AlexDemo.CustomerHub.Core.Application.UseCases.Common.Actions.Commands;

namespace AlexDemo.CustomerHub.Core.Application.UseCases.Portfolio.ProjectUser.Actions.Commands
{
    internal record DeleteProjectUserCommand : DeleteEntityCommand<long>
    {
    }
}
