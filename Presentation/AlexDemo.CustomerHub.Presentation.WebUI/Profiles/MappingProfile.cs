using AlexDemo.CustomerHub.Presentation.WebUI.Models.ViewModels.Customer.Company;
using AlexDemo.CustomerHub.Presentation.WebUI.Services.Base;
using AutoMapper;

namespace AlexDemo.CustomerHub.Presentation.WebUI.Profiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // customer
            CreateMap<CompanyDetailsDto, CompanyDetailsVm>().ReverseMap();
            CreateMap<CompanyListItemDto, CompanyListItemVm>().ReverseMap();
            CreateMap<CreateCompanyDto, CreateCompanyVm>().ReverseMap();
            CreateMap<UpdateCompanyDto, UpdateCompanyVm>().ReverseMap();

            CreateMap<CompanyDetailsDto, UpdateCompanyVm>().ReverseMap();

            //portfolio
        }
    }
}
