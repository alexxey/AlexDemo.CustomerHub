using AlexDemo.CustomerHub.Core.Application.Models.DTOs.Customer.User;

namespace AlexDemo.CustomerHub.Core.Application.UseCases.Customer.User.Requests.Queries
{
    /// <summary>
    /// Mediator's specific approach
    /// </summary>
    public class GetUsersListRequest : IRequest<List<UserListItemDto>>
    {
        public int CompanyId { get; set; }

        public int CompanyOfficeId { get; set; }
    }
}
