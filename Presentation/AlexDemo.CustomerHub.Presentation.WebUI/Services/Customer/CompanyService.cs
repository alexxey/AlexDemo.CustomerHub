using AlexDemo.CustomerHub.Core.Entities.Customer;
using AlexDemo.CustomerHub.Presentation.WebUI.Contracts;
using AlexDemo.CustomerHub.Presentation.WebUI.Contracts.Customer;
using AlexDemo.CustomerHub.Presentation.WebUI.Models.ViewModels.Customer.Company;
using AlexDemo.CustomerHub.Presentation.WebUI.Services.Base;
using AutoMapper;

namespace AlexDemo.CustomerHub.Presentation.WebUI.Services.Customer
{
    public class CompanyService : BaseHttpService, ICompanyService
    {
        private readonly ILocalStorageService _localStorageService;
        private readonly IMapper _mapper;
        private readonly IClient _client;

        public CompanyService(IClient client, ILocalStorageService localStorageService, IMapper mapper) : base(client, localStorageService)
        {
            _client = client;
            _localStorageService = localStorageService;
            _mapper = mapper;
        }

        public async Task<List<CompanyListItemVm>> GetList()
        {
            ICollection<CompanyListItemDto>? companyListItemDtos = await _client.CompanyAllAsync(CancellationToken.None);
            var companyListItemVms = _mapper.Map<List<CompanyListItemVm>>(companyListItemDtos);

            // todo alex : add additional mapping routine if/when needed
            return companyListItemVms;
        }

        public async Task<CompanyDetailsVm> GetDetailsById(int id)
        {
            var companyDto = await _client.CompanyGETAsync(id);
            var companyVm = _mapper.Map<CompanyDetailsVm>(companyDto);

            // todo alex : add additional mapping routine if/when needed
            return companyVm;
        }

        public async Task<CompanyDetailsDto> GetDtoDetailsById(int id)
        {
            var companyDto = await _client.CompanyGETAsync(id);
            
            // todo alex : add additional mapping routine if/when needed
            return companyDto;
        }

        public async Task<Response<int>> CreateCompany(CreateCompanyVm createVm)
        {
            try
            {
                var response = new Response<int>();
                CreateCompanyDto createDto = _mapper.Map<CreateCompanyDto>(createVm);

                var apiResponse = await _client.CompanyPOSTAsync(createDto);
                response.IsSuccessful = apiResponse.IsSuccessful;

                if (apiResponse.IsSuccessful)
                {
                    // todo alex: combine and build additional entity details
                    response.Data = apiResponse.Id;
                }
                else
                {
                    // todo alex : filter details using validation model error types
                    if (apiResponse.Data != null)
                    {
                        foreach (ResponseMessageModel? messageModel in apiResponse.Data)
                        {
                            response.ValidationErrors += messageModel.Message + Environment.NewLine;
                        }
                    }
                }

                return response;
            }
            catch (ApiException ex)
            {
                return ConvertApiExceptions<int>(ex);
            }
        }

        public async Task<Response<int>> UpdateCompany(int id, UpdateCompanyVm updateVm)
        {
            try
            {
                var response = new Response<int>();
                UpdateCompanyDto updateDto = _mapper.Map<UpdateCompanyDto>(updateVm);

                UpdateCompanyCommandResponse? apiResponse = await _client.CompanyPUTAsync(id, updateDto);
                response.IsSuccessful = apiResponse.IsSuccessful;

                if (apiResponse.IsSuccessful)
                {
                    // todo alex: combine and build additional entity details
                    response.Data = apiResponse.Id;
                }
                else
                {
                    // todo alex : filter details using validation model error types
                    foreach (ResponseMessageModel? messageModel in apiResponse.Data)
                    {
                        response.ValidationErrors += messageModel.Message + Environment.NewLine;
                    }
                }

                return response;
            }
            catch (ApiException ex)
            {
                return ConvertApiExceptions<int>(ex);
            }
        }

        public async Task<Response<int>> DeleteCompany(int id)
        {
            try
            {
                var response = new Response<int>();
                var apiResponse = await _client.CompanyDELETEAsync(id);
                response.IsSuccessful = apiResponse.IsSuccessful;

                if (apiResponse.IsSuccessful)
                {
                    // todo alex: combine and build additional entity details if needed (pass log entity id or something else)
                    response.Data = apiResponse.Id;
                }

                return response;
            }
            catch (ApiException ex) 
            {
                return ConvertApiExceptions<int>(ex);
            }
        }
    }
}
