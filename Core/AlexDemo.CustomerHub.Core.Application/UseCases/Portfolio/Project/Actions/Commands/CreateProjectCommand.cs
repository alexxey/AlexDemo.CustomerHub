using AlexDemo.CustomerHub.Core.Application.Models.DTOs.Portfolio.Project;

namespace AlexDemo.CustomerHub.Core.Application.UseCases.Portfolio.Project.Requests.Commands
{
    public class CreateProjectCommand : IRequest<int>
    {
        /// <summary>
        /// there's no point to duplicate exact same fields that are stored in DTO: simply use this DTO as a property inside request
        /// </summary>
        public CreateProjectDto CreateDto { get; set; }
    }
}
