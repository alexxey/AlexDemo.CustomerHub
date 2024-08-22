using AlexDemo.CustomerHub.Core.Application.Contracts.Persistence.Portfolio;
using AlexDemo.CustomerHub.Core.Application.Models.DTOs.Portfolio.ProjectUser;
using AlexDemo.CustomerHub.Core.Application.UseCases.Portfolio.ProjectUser.Actions.Queries;

namespace AlexDemo.CustomerHub.Core.Application.UseCases.Portfolio.ProjectUser.Handlers.Queries
{
    public class GetProjectUserDetailsRequestHandler : IRequestHandler<GetProjectUserDetailsRequest, ProjectUserDetailsDto>
    {
        private readonly IProjectUserRepository _projectUserRepository;
        private readonly IMapper _mapper;

        public GetProjectUserDetailsRequestHandler(IProjectUserRepository projectUserRepository, IMapper mapper)
        {
            _projectUserRepository = projectUserRepository;
            _mapper = mapper;
        }

        public async Task<ProjectUserDetailsDto> Handle(GetProjectUserDetailsRequest request, CancellationToken cancellationToken)
        {
            var projectUserDetails = await _projectUserRepository.GetById(request.Id);
            return _mapper.Map<ProjectUserDetailsDto>(projectUserDetails);
        }
    }
}
