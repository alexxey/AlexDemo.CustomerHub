using AlexDemo.CustomerHub.Core.Application.Contracts.Persistence.Customer;
using AlexDemo.CustomerHub.Core.Application.Enums;
using AlexDemo.CustomerHub.Core.Application.Exceptions;
using AlexDemo.CustomerHub.Core.Application.Models.DTOs.Customer.Company.Constraints;
using AlexDemo.CustomerHub.Core.Application.Responses;
using AlexDemo.CustomerHub.Core.Application.ServiceProviders;
using AlexDemo.CustomerHub.Core.Application.UseCases.Customer.Company.Actions.Commands;
using AlexDemo.CustomerHub.Core.Application.UseCases.Customer.Company.Actions.Responses;
using AlexDemo.CustomerHub.Core.Enums;

namespace AlexDemo.CustomerHub.Core.Application.UseCases.Customer.Company.Handlers.Commands
{
    public class UpdateCompanyCommandHandler : IRequestHandler<UpdateCompanyCommand, UpdateCompanyCommandResponse>
    {
        private readonly ICompanyRepository _companyRepository;
        private readonly IMapper _mapper;

        public UpdateCompanyCommandHandler(ICompanyRepository companyRepository, IMapper mapper)
        {
            _companyRepository = companyRepository;
            _mapper = mapper;
        }

        public async Task<UpdateCompanyCommandResponse> Handle(UpdateCompanyCommand request, CancellationToken cancellationToken)
        {
            var response = new UpdateCompanyCommandResponse
            {
                Id = request.UpdateDto.Id
            };

            var companyValidator = new UpdateCompanyDtoValidator();
            var validationResult = await companyValidator.ValidateAsync(request.UpdateDto, cancellationToken);

            if (!validationResult.IsValid)
            {
                // an alternative approach not to throw exceptions but to work with response types
                response.IsSuccessful = false;
                response.Message = "Update Company Failed";
                response.Data = new List<ResponseMessageModel>();
                foreach (var validationResultError in validationResult.Errors)
                {
                    response.Data.Add(new ResponseMessageModel
                    {
                        ResponseType = ResponseType.ValidationError,
                        Message = validationResultError.ErrorMessage
                    });
                }

                return response;
            }

            // todo alex: health check can be executed on validator level, as an option - but we query company data anyway
            var companyToUpdate = await _companyRepository.GetById(request.UpdateDto.Id);
            if (companyToUpdate.Status == Status.Deleted)
            {
                // throw Business Logic Exception : company no longer exists
                throw new NotFoundException(nameof(Company), request.UpdateDto.Id);
            }

            _mapper.Map(request.UpdateDto, companyToUpdate);

            companyToUpdate.BusinessType = CompanyMetadataServiceProvider.DefineBusinessTypeModel(companyToUpdate);

            await _companyRepository.Update(companyToUpdate);

            response.IsSuccessful = true;
            response.Message = "Company updated";
            return response;
        }
    }
}
