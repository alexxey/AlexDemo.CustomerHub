using AlexDemo.CustomerHub.Core.Enums;

namespace AlexDemo.CustomerHub.Core.Entities
{
    public abstract class BaseEntity
    {
        /// <summary>
        /// field designed for logs/statistic purposes
        /// </summary>
        public DateTime UpdatedOn { get; set; }

        public Status Status { get; set; }
    }
}
