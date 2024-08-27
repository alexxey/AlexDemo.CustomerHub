using System.Net.Http.Headers;
using AlexDemo.CustomerHub.Presentation.WebUI.Contracts;

namespace AlexDemo.CustomerHub.Presentation.WebUI.Services.Base
{
    public class BaseHttpService
    {
        protected readonly ILocalStorageService _localStorageService;

        protected readonly IClient _clent;

        public BaseHttpService(IClient client, ILocalStorageService localStorageService)
        {
            _clent = client;
            _localStorageService = localStorageService;
        }

        protected Response<T> ConvertApiExceptions<T>(ApiException ex)
        {
            if (ex.StatusCode == 400)
            {
                return new Response<T>
                {
                    Message = "Validation errors have occured", 
                    ValidationErrors = ex.Response, 
                    IsSuccessful = false
                };
            }

            if (ex.StatusCode == 404)
            {
                return new Response<T>
                {
                    Message = "The requested item could not be found",
                    ValidationErrors = ex.Response,
                    IsSuccessful = false
                };
            }

            return new Response<T>
            {
                Message = "Something went wrong, please try again",
                ValidationErrors = ex.Response,
                IsSuccessful = false
            };
        }

        protected void AddBearerToken()
        {
            if (_localStorageService.Exists("token"))
            {
                _clent.HttpClient.DefaultRequestHeaders.Authorization =
                    new AuthenticationHeaderValue("Bearer", _localStorageService.GetStorageValue<string>("token"));
            }
        }
    }
}
