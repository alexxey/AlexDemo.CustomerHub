using AlexDemo.CustomerHub.Core.Application.Models.DTOs.Portfolio.Project;

namespace AlexDemo.CustomerHub.Core.Application.UseCases.Portfolio.Project.Actions.Queries
{
    /// <summary>
    /// Mediator's specific approach
    /// </summary>
    public class GetProjectsListRequest : IRequest<List<ProjectListItemDto>>
    {
        public int CompanyId { get; set; }

        public int CompanyOfficeId { get; set; }
    }
}
