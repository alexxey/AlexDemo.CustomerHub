using AlexDemo.CustomerHub.Core.Application.Contracts.Identity;
using AlexDemo.CustomerHub.Core.Application.Contracts.Persistence.Customer;
using AlexDemo.CustomerHub.Core.Application.Exceptions;
using AlexDemo.CustomerHub.Core.Application.Models.DTOs.Customer.User.Constraints;
using AlexDemo.CustomerHub.Core.Application.Models.Identity;
using AlexDemo.CustomerHub.Core.Application.UseCases.Customer.User.Actions.Commands;

namespace AlexDemo.CustomerHub.Core.Application.UseCases.Customer.User.Handlers.Commands
{
    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, int>
    {
        private readonly IUserRepository _userRepository;
        private readonly ICompanyOfficeRepository _companyOfficeRepository;

        private readonly IAuthService _authService;

        private readonly IMapper _mapper;

        public CreateUserCommandHandler(IAuthService authService, IUserRepository userRepository, ICompanyOfficeRepository companyOfficeRepository, IMapper mapper)
        {
            _authService = authService;
            _userRepository = userRepository;
            _companyOfficeRepository = companyOfficeRepository;
            _mapper = mapper;
        }

        public async Task<int> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            var userValidator = new CreateUserDtoValidator(_companyOfficeRepository);
            var validationResult = await userValidator.ValidateAsync(request.CreateDto, cancellationToken);

            if (!validationResult.IsValid)
            {
                throw new ValidationException(validationResult);
            }

            // todo: additional validations
            var isLoginUnique = await _userRepository.IsLoginUnique(request.CreateDto.Login, request.CreateDto.CompanyId);
            if (!isLoginUnique)
            {
                throw new ArgumentException("Login is not available");
            }

            // create auth registration service call
            var registrationResponse = await _authService.Register(new RegistrationRequest
            {
                Email = request.CreateDto.Email,
                Password = request.CreateDto.Password,
                UserName = request.CreateDto.Login
            });

            if (!string.IsNullOrWhiteSpace(registrationResponse?.UserId))
            {
                throw new ApplicationException("Unable to register user");
            }

            var user = _mapper.Map<Entities.Customer.CompanyUser>(request.CreateDto);
            user.IdentityUserId = registrationResponse.UserId;

            user = await _userRepository.Create(user);
            return user.Id;
        }
    }
}
