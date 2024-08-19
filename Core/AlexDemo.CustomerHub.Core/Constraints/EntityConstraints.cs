namespace AlexDemo.CustomerHub.Core.Constraints
{
    /// <summary>
    /// class to define entity constraints that can be reused across all application layers
    /// </summary>
    public static class EntityConstraints
    {
        public static class CommonSettings
        {
            public const int ExtraShortStringLength = 10;
            public const int ShortStringLength = 50;
            public const int MediumStringLength = 100;
            public const int LongStringLength = 255;
            public const int ExtraLongStringLength = 1000;

            public const int EmailAddressLength = 100;
        }

        public static class Domain
        {
            public static class UserSettings
            {
                public const int LoginLength = 75;
                public const int PasswordHash = 128;
                public const int PasswordSalt = 64;
            }
        }
    }
}
