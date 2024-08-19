using AlexDemo.CustomerHub.Core.Application.Models.DTOs.Customer.Company.Constraints;
using AlexDemo.CustomerHub.Core.Application.Persistence.Contracts.Customer;
using AlexDemo.CustomerHub.Core.Application.UseCases.Customer.Company.Actions.Commands;
using AlexDemo.CustomerHub.Core.Enums;

namespace AlexDemo.CustomerHub.Core.Application.UseCases.Customer.Company.Handlers.Commands
{
    public class UpdateCompanyCommandHandler : IRequestHandler<UpdateCompanyCommand, Unit>
    {
        private readonly ICompanyRepository _companyRepository;
        private readonly IMapper _mapper;

        public UpdateCompanyCommandHandler(ICompanyRepository companyRepository, IMapper mapper)
        {
            _companyRepository = companyRepository;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(UpdateCompanyCommand request, CancellationToken cancellationToken)
        {
            var companyValidator = new UpdateCompanyDtoValidator();
            var validationResult = await companyValidator.ValidateAsync(request.UpdateDto, cancellationToken);

            if (!validationResult.IsValid)
            {
                throw new ArgumentException("Command details are not valid");
            }

            // todo alex: health check can be executed on validator level, as an option - but we query company data anyway
            var companyToUpdate = await _companyRepository.GetById(request.UpdateDto.Id);
            if (companyToUpdate.Status == Status.Deleted)
            {
                // throw Business Logic Exception : company no longer exists
                throw new ApplicationException("Company is not found");
            }

            _mapper.Map(request.UpdateDto, companyToUpdate);

            await _companyRepository.Update(companyToUpdate);

            return Unit.Value;
        }
    }
}
