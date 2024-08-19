using AlexDemo.CustomerHub.Core.Application.Models.DTOs.Customer.Company;

namespace AlexDemo.CustomerHub.Core.Application.UseCases.Customer.Company.Actions.Commands
{
    public class CreateCompanyCommand : IRequest<int>
    {
        /// <summary>
        /// there's no point to duplicate exact same fields that are stored in DTO: simply use this DTO as a property inside request
        /// </summary>
        public CreateCompanyDto CreateDto { get; set; }
    }
}
