using Microsoft.EntityFrameworkCore.Metadata;

namespace AlexDemo.CustomerHub.DataAccess.EF
{
    internal static class DbConstants
    {
        public static class CommonSettings
        {
            public const int ExtraShortLength = 10;
            public const int ShortStringLength = 50;
            public const int MediumStringLength = 100;
            public const int LongStringLength = 255;
            public const int ExtraLongStringLength = 1000;

            public const string DateTimeDateOnlyFormat = "date";
            public const string DateTimeSecOnlyAccuracyFormat = "datetime2(0)";

            public const int EmailAddressLength = 100;
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

            public static class UserSettings
            {
                public const int LoginLength = 75;
                public const int PasswordHash = 128;
                public const int PasswordSalt = 64;
            }
        }
    }
}
