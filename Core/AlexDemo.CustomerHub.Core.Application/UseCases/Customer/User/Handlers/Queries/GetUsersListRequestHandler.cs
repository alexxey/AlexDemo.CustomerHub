using System.Collections.Generic;
using AlexDemo.CustomerHub.Core.Application.Models.DTOs.Customer.User;
using AlexDemo.CustomerHub.Core.Application.Persistence.Contracts.Customer;
using AlexDemo.CustomerHub.Core.Application.UseCases.Customer.User.Actions.Queries;

namespace AlexDemo.CustomerHub.Core.Application.UseCases.Customer.User.Handlers.Queries
{
    public class GetUsersListRequestHandler : IRequestHandler<GetUsersListRequest, List<UserListItemDto>>
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public GetUsersListRequestHandler(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task<List<UserListItemDto>> Handle(GetUsersListRequest request, CancellationToken cancellationToken)
        {
            List<Entities.Customer.User> usersList = null;
            
            if (request.CompanyId > 0)
            {
                usersList = await _userRepository.GetAllByCompany(request.CompanyId);
            }
            else if (request.CompanyOfficeId > 0)
            {
                usersList = await _userRepository.GetAllByCompanyOffice(request.CompanyOfficeId);
            }
            else
            {
                throw new NotSupportedException("List without parameters is not supported");
            }

            return _mapper.Map<List<UserListItemDto>>(usersList);
        }
    }
}
