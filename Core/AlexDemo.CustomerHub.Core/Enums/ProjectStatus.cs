using System.ComponentModel;

namespace AlexDemo.CustomerHub.Core.Enums
{
    /// <summary>
    /// todo : add additional level of configuration for the project when/if needed
    /// </summary>
    public enum ProjectStatus : byte
    {
        [Description("The initial phase where the project is conceptualized")]
        Initiation = 1,       

        [Description("Detailed project planning and design")]
        Planning = 2,         

        [Description("The actual work to create the project's deliverables")]
        Execution = 3,        

        [Description("Tracking project progress, quality, and performance")]
        Monitoring = 4,       

        [Description("The phase where the project deliverables are handed over")]
        Delivery = 5,         

        [Description("Finalizing the project, closing contracts, and post-mortem analysis")]
        Closure = 6,

        [Description("Project is temporarily paused")]
        OnHold = 7,

        [Description("Project is permanently stopped")]
        Canceled = 8
    }
}
