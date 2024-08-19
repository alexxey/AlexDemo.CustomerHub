using AlexDemo.CustomerHub.Core.Application.Models.DTOs.Customer.CompanyOffice;

namespace AlexDemo.CustomerHub.Core.Application.UseCases.Customer.CompanyOffice.Actions.Queries
{
    /// <summary>
    /// Mediator's specific approach
    /// </summary>
    public class GetCompanyOfficesListRequest : IRequest<List<CompanyOfficeListItemDto>>
    {
        public int CompanyId { get; set; }
    }
}
