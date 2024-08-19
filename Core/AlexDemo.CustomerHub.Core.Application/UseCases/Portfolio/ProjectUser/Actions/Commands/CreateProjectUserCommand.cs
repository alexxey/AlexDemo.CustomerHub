using AlexDemo.CustomerHub.Core.Application.Models.DTOs.Portfolio.ProjectUser;

namespace AlexDemo.CustomerHub.Core.Application.UseCases.Portfolio.ProjectUser.Actions.Commands
{
    public class CreateProjectUserCommand : IRequest<long>
    {
        public CreateProjectUserDto CreateDto { get; set; }
    }
}
