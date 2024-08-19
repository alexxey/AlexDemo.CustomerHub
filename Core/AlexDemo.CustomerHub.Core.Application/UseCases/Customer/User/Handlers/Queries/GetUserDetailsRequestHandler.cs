using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AlexDemo.CustomerHub.Core.Application.Models.DTOs.Customer.User;
using AlexDemo.CustomerHub.Core.Application.Persistence.Contracts.Customer;
using AlexDemo.CustomerHub.Core.Application.UseCases.Customer.User.Requests.Queries;

namespace AlexDemo.CustomerHub.Core.Application.UseCases.Customer.User.Handlers.Queries
{
    public class GetUserDetailsRequestHandler : IRequestHandler<GetUserDetailsRequest, UserDetailsDto>
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public GetUserDetailsRequestHandler(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task<UserDetailsDto> Handle(GetUserDetailsRequest request, CancellationToken cancellationToken)
        {
            // todo : validation
            if (request.Id <= 0)
            {
                throw new ArgumentException(nameof(request.Id));
            }

            var userDetails = await _userRepository.GetById(request.Id);
            return _mapper.Map<UserDetailsDto>(userDetails);
        }
    }
}
