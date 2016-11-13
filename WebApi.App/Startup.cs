using System.Collections.Generic;
using IdentityServer3.AccessTokenValidation;
using Microsoft.Owin;
using Owin;
using WebApi.Custom.Configuration;


[assembly: OwinStartup(typeof(WebApi.App.Startup))]

namespace WebApi.App
{
    /// <summary>
    /// 
    /// </summary>
    public partial class Startup
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="appBuilder"></param>
        public void Configuration(IAppBuilder appBuilder)
        {
            if (!CustomConfigReader.BasicAuthenticationToggle)
            {

                appBuilder.UseIdentityServerBearerTokenAuthentication(
                    new IdentityServerBearerTokenAuthenticationOptions
                    {
                        Authority = CustomConfigReader.AuthenticationServerUrl,
                        RequiredScopes = new List<string> { "roles", "openid", "profile" }
                    });
            }
        }
    }
}