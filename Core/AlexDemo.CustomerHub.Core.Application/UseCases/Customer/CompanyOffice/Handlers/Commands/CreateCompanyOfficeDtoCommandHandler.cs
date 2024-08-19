using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AlexDemo.CustomerHub.Core.Application.Models.DTOs.Customer.CompanyOffice.Constraints;
using AlexDemo.CustomerHub.Core.Application.Persistence.Contracts.Customer;
using AlexDemo.CustomerHub.Core.Application.UseCases.Customer.CompanyOffice.Actions.Commands;

namespace AlexDemo.CustomerHub.Core.Application.UseCases.Customer.CompanyOffice.Handlers.Commands
{
    public class CreateCompanyOfficeDtoCommandHandler : IRequestHandler<CreateCompanyOfficeDtoCommand, int>
    {
        private readonly ICompanyOfficeRepository _companyOfficeRepository;
        private readonly ICompanyRepository _companyRepository;
        private readonly IMapper _mapper;

        public CreateCompanyOfficeDtoCommandHandler(ICompanyOfficeRepository companyOfficeRepository, ICompanyRepository companyRepository, IMapper mapper)
        {
            _companyOfficeRepository = companyOfficeRepository;
            _companyRepository = companyRepository;
            _mapper = mapper;
        }

        public async Task<int> Handle(CreateCompanyOfficeDtoCommand request, CancellationToken cancellationToken)
        {
            var companyOfficeValidator = new CreateCompanyOfficeDtoValidator(_companyRepository);

            var validationResult = await companyOfficeValidator.ValidateAsync(request.CreateDto, cancellationToken);

            if (!validationResult.IsValid)
            {
                throw new ArgumentException("Command details are not valid");
            }

            var companyOffice = _mapper.Map<Entities.Customer.CompanyOffice>(request.CreateDto);

            companyOffice = await _companyOfficeRepository.Create(companyOffice);
            return companyOffice.Id;
        }
    }
}
