namespace AlexDemo.CustomerHub.Presentation.WebUI.Services.Base
{
    public class Response<T>
    {
        public string Message { get; set; }

        public string ValidationErrors { get; set; }

        public bool IsSuccessful { get; set; }

        public T Data { get; set; }
    }
}
