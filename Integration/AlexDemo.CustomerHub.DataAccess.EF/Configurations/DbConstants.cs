using Microsoft.EntityFrameworkCore.Metadata;

namespace AlexDemo.CustomerHub.DataAccess.EF.Configurations
{
    /// <summary>
    /// class to store EF specific rules and limitations
    /// </summary>
    internal static class DbConstants
    {
        public static class CommonSettings
        {
            public const string DateTimeDateOnlyFormat = "date";
            public const string DateTimeSecOnlyAccuracyFormat = "datetime2(0)";
        }

        public static class Domain
        {
            public const string DefaultSchemaName = "demo";

            public static class EntityNames
            {
                public const string CompanyEntityName = "Company";
                public const string CompanyOfficeEntityName = "CompanyOffice";
                public const string UserEntityName = "User";
                public const string ProjectEntityName = "Project";
                public const string ProjectUserEntityName = "ProjectUser";
            }
        }
    }
}
