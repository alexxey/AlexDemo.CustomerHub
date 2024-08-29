namespace AlexDemo.CustomerHub.Core.Application.Exceptions
{
    public class NotFoundException : ApplicationException
    {
        public NotFoundException(string entityName, object key) : base($"{entityName}, {key} is not found")
        {
            
        }
    }
}
