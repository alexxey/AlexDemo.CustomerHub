using AlexDemo.CustomerHub.Core.Application.Models.DTOs.Customer.Company.Constraints;
using AlexDemo.CustomerHub.Core.Application.Persistence.Contracts.Customer;
using AlexDemo.CustomerHub.Core.Application.UseCases.Customer.Company.Actions.Commands;

namespace AlexDemo.CustomerHub.Core.Application.UseCases.Customer.Company.Handlers.Commands
{
    public class CreateCompanyCommandHandler : IRequestHandler<CreateCompanyCommand, int>
    {
        private readonly ICompanyRepository _companyRepository;
        private readonly IMapper _mapper;

        public CreateCompanyCommandHandler(ICompanyRepository companyRepository, IMapper mapper)
        {
            _companyRepository = companyRepository;
            _mapper = mapper;
        }

        public async Task<int> Handle(CreateCompanyCommand request, CancellationToken cancellationToken)
        {
            var companyValidator = new CreateCompanyDtoValidator();
            var validationResult = await companyValidator.ValidateAsync(request.CreateDto, cancellationToken);

            if (!validationResult.IsValid)
            {
                throw new ArgumentException("Command details are not valid");
            }
            
            var company = _mapper.Map<Entities.Customer.Company>(request.CreateDto);

            company = await _companyRepository.Create(company);
            return company.Id;
        }
    }
}
