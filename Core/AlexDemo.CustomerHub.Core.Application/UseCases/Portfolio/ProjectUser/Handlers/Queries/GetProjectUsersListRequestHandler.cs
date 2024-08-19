using AlexDemo.CustomerHub.Core.Application.Models.DTOs.Portfolio.ProjectUser;
using AlexDemo.CustomerHub.Core.Application.Persistence.Contracts.Portfolio;
using AlexDemo.CustomerHub.Core.Application.UseCases.Portfolio.ProjectUser.Requests.Queries;

namespace AlexDemo.CustomerHub.Core.Application.UseCases.Portfolio.ProjectUser.Handlers.Queries
{
    public class GetProjectUsersListRequestHandler : IRequestHandler<GetProjectUsersListRequest, List<ProjectUserListItemDto>>
    {
        private readonly IProjectUserRepository _projectUserRepository;
        private readonly IMapper _mapper;

        public GetProjectUsersListRequestHandler(IProjectUserRepository projectUserRepository, IMapper mapper)
        {
            _projectUserRepository = projectUserRepository;
            _mapper = mapper;
        }

        public async Task<List<ProjectUserListItemDto>> Handle(GetProjectUsersListRequest request, CancellationToken cancellationToken)
        {
            IReadOnlyList<Entities.Portfolio.ProjectUser> projectUsers = null;
            
            if (request.ProjectId > 0)
            {
                projectUsers = await _projectUserRepository.GetAllByProject(request.ProjectId);
            }
            else if (request.UserId > 0)
            {
                projectUsers = await _projectUserRepository.GetAllByUser(request.UserId);
            }
            else
            {
                // todo : forbid cases to return complete list of entities as it simply does not make any sense
                throw new NotSupportedException("List without filters is not supported");
            }

            return _mapper.Map<List<ProjectUserListItemDto>>(projectUsers);
        }
    }
}
