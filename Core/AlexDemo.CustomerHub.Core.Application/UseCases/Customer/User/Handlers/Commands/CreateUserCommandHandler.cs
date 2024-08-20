using AlexDemo.CustomerHub.Core.Application.Exceptions;
using AlexDemo.CustomerHub.Core.Application.Models.DTOs.Customer.User.Constraints;
using AlexDemo.CustomerHub.Core.Application.Persistence.Contracts.Customer;
using AlexDemo.CustomerHub.Core.Application.ServiceProviders;
using AlexDemo.CustomerHub.Core.Application.UseCases.Customer.User.Actions.Commands;

namespace AlexDemo.CustomerHub.Core.Application.UseCases.Customer.User.Handlers.Commands
{
    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, int>
    {
        private readonly IUserRepository _userRepository;
        private readonly ICompanyOfficeRepository _companyOfficeRepository;
        private readonly IMapper _mapper;

        public CreateUserCommandHandler(IUserRepository userRepository, ICompanyOfficeRepository companyOfficeRepository, IMapper mapper)
        {
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

            var user = _mapper.Map<Entities.Customer.User>(request.CreateDto);

            // set password details
            PasswordServiceProvider.CreatePasswordHash(request.CreateDto.Password, out byte[] hash, out byte[] salt);

            user.PasswordHash = Convert.ToBase64String(hash);
            user.PasswordSalt = Convert.ToBase64String(salt);

            user = await _userRepository.Create(user);
            return user.Id;
        }
    }
}
