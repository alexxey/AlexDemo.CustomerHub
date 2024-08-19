using AlexDemo.CustomerHub.Core.Application.Models.DTOs.Portfolio.Project;
using AlexDemo.CustomerHub.Core.Application.Persistence.Contracts.Portfolio;
using AlexDemo.CustomerHub.Core.Application.UseCases.Portfolio.Project.Requests.Queries;
using AlexDemo.CustomerHub.Core.Application.UseCases.Portfolio.ProjectUser.Requests.Queries;

namespace AlexDemo.CustomerHub.Core.Application.UseCases.Portfolio.Project.Handlers.Queries
{
    public class GetProjectDetailsRequestHandler : IRequestHandler<GetProjectDetailsRequest, ProjectDetailsDto>
    {
        private readonly IProjectRepository _projectRepository;
        private readonly IMapper _mapper;

        public GetProjectDetailsRequestHandler(IProjectRepository projectRepository, IMapper mapper)
        {
            _projectRepository = projectRepository;
            _mapper = mapper;
        }

        public async Task<ProjectDetailsDto> Handle(GetProjectDetailsRequest request, CancellationToken cancellationToken)
        {
            var projectDetails = await _projectRepository.GetById(request.Id);
            return _mapper.Map<ProjectDetailsDto>(projectDetails);
        }
    }
}
