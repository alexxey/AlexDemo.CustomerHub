using AlexDemo.CustomerHub.Core.Application.Models.DTOs.Portfolio.ProjectUser;

namespace AlexDemo.CustomerHub.Core.Application.UseCases.Portfolio.ProjectUser.Actions.Queries
{
    public class GetProjectUserDetailsRequest : IRequest<ProjectUserDetailsDto>
    {
        public long Id { get; set; }
    }
}
