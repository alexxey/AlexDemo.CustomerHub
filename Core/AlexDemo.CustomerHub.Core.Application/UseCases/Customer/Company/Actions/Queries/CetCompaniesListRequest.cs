using AlexDemo.CustomerHub.Core.Application.Models.DTOs.Customer.Company;

namespace AlexDemo.CustomerHub.Core.Application.UseCases.Customer.Company.Requests.Queries
{
    /// <summary>
    /// Mediator's specific approach
    /// </summary>
    public class GetCompaniesListRequest : IRequest<List<CompanyListItemDto>>
    {
    }
}
