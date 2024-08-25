namespace AlexDemo.CustomerHub.Core.Application.Models.DTOs
{
    public class BaseDto<T>
    {
        public required T Id { get; set; }
    }
}
