using System.ComponentModel;

namespace AlexDemo.CustomerHub.Core.Enums
{
    /// <summary>
    /// there should be a possibility to define specific set of roles with company, this can be done via additional entity
    /// </summary>
    [Flags]
    public enum ProjectUserRole : byte
    {
        [Description("External or Internal stakeholder ")]
        Stakeholder = 1,
        
        [Description("Product Owner")]
        ProductOwner = 2,          

        [Description("Project Manager")]
        ProjectManager = 3,        

        [Description("Scrum Master")]
        ScrumMaster = 4,           

        [Description("Business Analyst")]
        BusinessAnalyst = 5,

        [Description("Lead Developer")]
        LeadDeveloper = 6,        

        [Description("Software Developer")]
        Developer = 7,             

        [Description("Quality Assurance Specialist")]
        QA = 8,                    

        [Description(" DevOps Engineer")]
        DevOpsEngineer = 9,       

        [Description("Support Engineer or IT Support")]
        SupportEngineer = 10       
    }
}
