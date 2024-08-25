using AlexDemo.CustomerHub.Core.Application.Contracts.Persistence.Customer;
using AlexDemo.CustomerHub.Core.Application.Exceptions;
using AlexDemo.CustomerHub.Core.Application.Models.DTOs.Customer.CompanyOffice.Constraints;
using AlexDemo.CustomerHub.Core.Application.UseCases.Customer.CompanyOffice.Actions.Commands;
using AlexDemo.CustomerHub.Core.Enums;

namespace AlexDemo.CustomerHub.Core.Application.UseCases.Customer.CompanyOffice.Handlers.Commands
{
    public class UpdateCompanyOfficeCommandHandler : IRequestHandler<UpdateCompanyOfficeCommand, Unit>
    {
        private readonly ICompanyOfficeRepository _companyOfficeRepository;
        private readonly IMapper _mapper;

        public UpdateCompanyOfficeCommandHandler(ICompanyOfficeRepository companyOfficeRepository, IMapper mapper)
        {
            _companyOfficeRepository = companyOfficeRepository;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(UpdateCompanyOfficeCommand request, CancellationToken cancellationToken)
        {
            var companyOfficeValidator = new UpdateCompanyOfficeDtoValidator();
            var validationResult = await companyOfficeValidator.ValidateAsync(request.UpdateDto, cancellationToken);

            if (!validationResult.IsValid)
            {
                throw new ValidationException(validationResult);
            }

            // todo alex: health check can be executed on validator level, as an option - but we query company data anyway
            var companyOfficeToUpdate = await _companyOfficeRepository.GetById(request.UpdateDto.Id);
            if (companyOfficeToUpdate.Status == Status.Deleted)
            {
                // throw Business Logic Exception : company no longer exists
                throw new NotFoundException(nameof(CompanyOffice), request.UpdateDto.Id);
            }

            _mapper.Map(request.UpdateDto, companyOfficeToUpdate);

            await _companyOfficeRepository.Update(companyOfficeToUpdate);

            return Unit.Value;
        }
    }
}
