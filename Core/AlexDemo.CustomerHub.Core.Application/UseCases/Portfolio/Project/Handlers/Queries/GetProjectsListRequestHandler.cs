using AlexDemo.CustomerHub.Core.Application.Contracts.Persistence.Portfolio;
using AlexDemo.CustomerHub.Core.Application.Models.DTOs.Portfolio.Project;
using AlexDemo.CustomerHub.Core.Application.UseCases.Portfolio.Project.Actions.Queries;

namespace AlexDemo.CustomerHub.Core.Application.UseCases.Portfolio.Project.Handlers.Queries
{
    public class GetProjectsListRequestHandler : IRequestHandler<GetProjectsListRequest, List<ProjectListItemDto>>
    {
        private readonly IProjectRepository _projectRepository;
        private readonly IMapper _mapper;

        public GetProjectsListRequestHandler(IProjectRepository projectRepository, IMapper mapper)
        {
            _projectRepository = projectRepository;
            _mapper = mapper;
        }

        public async Task<List<ProjectListItemDto>> Handle(GetProjectsListRequest request, CancellationToken cancellationToken)
        {
            IReadOnlyList<Entities.Portfolio.Project> projects = null;
            if (request.CompanyId > 0)
            {
                projects = await _projectRepository.GetAllByCompany(request.CompanyId);
            }
            else if (request.CompanyOfficeId > 0)
            {
                projects = await _projectRepository.GetAllByCompanyOffice(request.CompanyOfficeId);
            }
            else
            {
                // todo : forbid cases to return complete list of entities as it simply does not make any sense
                throw new NotSupportedException("List without filters is not supported");
            }

            return _mapper.Map<List<ProjectListItemDto>>(projects);
        }
    }
}
