namespace AlexDemo.CustomerHub.Core.Application.Models.DTOs
{
    public record BaseDto<T>
    {
        public required T Id { get; set; }
    }
}
