using System.ComponentModel;

namespace AlexDemo.CustomerHub.Core.Enums
{
    public enum EmployeeCompanyRole : byte
    {
        [Description("Top-level management (e.g., CEO, CFO, CTO)")]
        Executive = 1,             

        [Description("Head of a specific department")]
        DepartmentHead = 2,        
        
        [Description("Senior management, but below department heads")]
        SeniorManager = 3,         
        
        [Description("General managers")]
        Manager = 4,               
        
        [Description(" Technical or subject-matter experts")]
        Specialist = 5,            
        
        [Description("Administrative or operational support roles")]
        SupportStaff = 6           
    }
}
