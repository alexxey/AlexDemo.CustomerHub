using AlexDemo.CustomerHub.Core.Application.UseCases.Common.Actions.Commands;

namespace AlexDemo.CustomerHub.Core.Application.UseCases.Portfolio.Project.Actions.Commands
{
    public record DeleteProjectCommand : DeleteEntityCommand<int>
    {
    }
}
