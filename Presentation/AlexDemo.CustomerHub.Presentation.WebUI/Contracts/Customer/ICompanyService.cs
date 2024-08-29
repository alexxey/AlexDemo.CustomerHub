using AlexDemo.CustomerHub.Presentation.WebUI.Models.ViewModels.Customer.Company;
using AlexDemo.CustomerHub.Presentation.WebUI.Services.Base;

namespace AlexDemo.CustomerHub.Presentation.WebUI.Contracts.Customer
{
    public interface ICompanyService
    {
        // getList might not be available in this context as this is company specific domain
        Task<List<CompanyListItemVm>> GetList();

        Task<CompanyDetailsVm> GetDetailsById(int id);

        Task<CompanyDetailsDto> GetDtoDetailsById(int id);

        Task<Response<int>> CreateCompany(CreateCompanyVm createVm);

        Task<Response<int>> UpdateCompany(int id, UpdateCompanyVm updateVm);

        Task<Response<int>> DeleteCompany(int id);
    }
}
