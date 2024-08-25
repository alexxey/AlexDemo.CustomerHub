using AlexDemo.CustomerHub.Core.Application.Models.DTOs.Customer.Company;
using AlexDemo.CustomerHub.Core.Application.Models.DTOs.Customer.CompanyOffice;
using AlexDemo.CustomerHub.Core.Application.Models.DTOs.Customer.User;
using AlexDemo.CustomerHub.Core.Application.Models.DTOs.Portfolio.Project;
using AlexDemo.CustomerHub.Core.Application.Models.DTOs.Portfolio.ProjectUser;
using AlexDemo.CustomerHub.Core.Entities.Customer;
using AlexDemo.CustomerHub.Core.Entities.Portfolio;

namespace AlexDemo.CustomerHub.Core.Application.Profiles
{
    /// <summary>
    /// class to manage Automatic mapping using Automapper
    /// </summary>
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // customer
            CreateMap<Company, CompanyDetailsDto>().ReverseMap();
            CreateMap<Company, CompanyListItemDto>().ReverseMap();
            CreateMap<CreateCompanyDto, Company>().ReverseMap();
            CreateMap<UpdateCompanyDto, Company>().ReverseMap();

            CreateMap<CompanyOffice, CompanyOfficeDetailsDto>().ReverseMap();
            CreateMap<CompanyOffice, CompanyOfficeListItemDto>().ReverseMap();
            CreateMap<CreateCompanyOfficeDto, CompanyOffice>().ReverseMap();
            CreateMap<UpdateCompanyOfficeDto, CompanyOffice>().ReverseMap();

            CreateMap<User, UserDetailsDto>().ReverseMap();
            CreateMap<User, UserListItemDto>().ReverseMap();
            CreateMap<CreateUserDto, User>().ReverseMap();
            CreateMap<UpdateUserDto, User>().ReverseMap();

            // portfolio
            CreateMap<Project, ProjectDetailsDto>().ReverseMap();
            CreateMap<Project, ProjectListItemDto>().ReverseMap();
            CreateMap<CreateProjectDto, Project>().ReverseMap();
            CreateMap<UpdateProjectDto, Project>().ReverseMap();

            CreateMap<ProjectUser, ProjectUserDetailsDto>().ReverseMap();
            CreateMap<ProjectUser, ProjectUserListItemDto>().ReverseMap();
            CreateMap<CreateProjectUserDto, ProjectUser>().ReverseMap();
            CreateMap<UpdateProjectUserDto, ProjectUser>().ReverseMap();
        }
    }
}
