using System.Net.Http;

namespace AlexDemo.CustomerHub.Presentation.WebUI.Services.Base
{
    public partial class Client : IClient
    {
        public HttpClient HttpClient => _httpClient;
    }
}
