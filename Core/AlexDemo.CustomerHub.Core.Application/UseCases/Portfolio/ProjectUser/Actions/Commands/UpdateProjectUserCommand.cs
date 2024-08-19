using AlexDemo.CustomerHub.Core.Application.Models.DTOs.Portfolio.ProjectUser;

namespace AlexDemo.CustomerHub.Core.Application.UseCases.Portfolio.ProjectUser.Actions.Commands
{
    public class UpdateProjectUserCommand : IRequest<Unit>
    {
        public UpdateProjectUserDto UpdateDto { get; set; }
    }
}
