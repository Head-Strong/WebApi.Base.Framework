using System.Configuration;

namespace WebApi.Custom.Configuration
{
    public static class CustomConfigReader
    {
        public static string SelfHostUrl => ConfigurationManager.AppSettings[CustomKeys.SelfHostUrl];

        public static string RequestHeaderValueInConfig
            => ConfigurationManager.AppSettings[CustomKeys.RequestHeaderValueInConfig];

        public static string UserNameInConfig
            => ConfigurationManager.AppSettings[CustomKeys.UserName];

        public static string PasswordInConfig
            => ConfigurationManager.AppSettings[CustomKeys.Password];

        public static string AuthenticationServerUrl
            => ConfigurationManager.AppSettings[CustomKeys.AuthenticationServerUrl];
    }
}
