namespace AlexDemo.CustomerHub.Core.Entities
{
    public abstract class BaseMonitoredEntity : BaseEntity
    {
        /// <summary>
        /// field to handle update/concurrency issues
        /// </summary>
        public required byte[] RowVersion { get; set; }
    }
}
