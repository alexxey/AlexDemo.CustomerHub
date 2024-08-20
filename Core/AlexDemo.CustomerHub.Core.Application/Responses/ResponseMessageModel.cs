using AlexDemo.CustomerHub.Core.Application.Enums;

namespace AlexDemo.CustomerHub.Core.Application.Responses
{
    public class ResponseMessageModel
    {
        public ResponseType ResponseType { get; set; }

        public string Code { get; set; }

        public string Message { get; set; } 
    }
}
