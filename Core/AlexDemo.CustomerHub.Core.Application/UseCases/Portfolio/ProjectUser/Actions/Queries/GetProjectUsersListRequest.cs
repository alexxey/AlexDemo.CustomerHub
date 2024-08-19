using AlexDemo.CustomerHub.Core.Application.Models.DTOs.Portfolio.ProjectUser;

namespace AlexDemo.CustomerHub.Core.Application.UseCases.Portfolio.ProjectUser.Requests.Queries
{
    /// <summary>
    /// Mediator's specific approach
    /// </summary>
    public class GetProjectUsersListRequest : IRequest<List<ProjectUserListItemDto>>
    {
        public int ProjectId { get; set; }

        public int CompanyOfficeId { get; set; }

        public int UserId { get; set; }
    }
}
