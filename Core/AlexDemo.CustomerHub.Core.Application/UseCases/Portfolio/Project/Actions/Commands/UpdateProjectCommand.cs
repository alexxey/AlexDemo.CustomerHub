using AlexDemo.CustomerHub.Core.Application.Models.DTOs.Portfolio.Project;

namespace AlexDemo.CustomerHub.Core.Application.UseCases.Portfolio.Project.Actions.Commands
{
    public class UpdateProjectCommand : IRequest<Unit>
    {
        public UpdateProjectDto UpdateDto { get; set; }
    }
}
