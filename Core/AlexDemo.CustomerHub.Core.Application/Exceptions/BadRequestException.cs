namespace AlexDemo.CustomerHub.Core.Application.Exceptions
{
    public class BadRequestException : ApplicationException
    {
        public BadRequestException(string code) : base(code)
        {
            
        }
    }
}
