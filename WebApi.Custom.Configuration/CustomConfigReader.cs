using System.Configuration;

namespace WebApi.Custom.Configuration
{
    public static class CustomConfigReader
    {
        public static string SelfHostUrl => ConfigurationManager.AppSettings[CustomKeys.SelfHostUrl];
    }
}
