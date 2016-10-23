using System;
using System.Configuration;
using System.Security.Cryptography.X509Certificates;
using IdentityServer3.Core.Configuration;
using IdentityServer3.Core.Services;
using IdentityServer3.Core.Services.Default;
using OAuthTokenServerService.AuthenticationDetails;
using Owin;

namespace OAuthTokenServerService
{
    public class Startup
    {
        public void Configuration(IAppBuilder appBuilder)
        {
            var authenticationManager = new InMemoryAuthenticationManager();

            var identityServerServiceFactory = new IdentityServerServiceFactory();

            identityServerServiceFactory.UseInMemoryClients(authenticationManager.GetClients());

            identityServerServiceFactory.UseInMemoryScopes(authenticationManager.GetScopes());

            identityServerServiceFactory.UseInMemoryUsers(authenticationManager.GetUsers());

            identityServerServiceFactory.CorsPolicyService =
                new Registration<ICorsPolicyService>(new DefaultCorsPolicyService
                {
                    AllowAll = true
                });


            var signingCertificate = new X509Certificate2(
                fileName: AppDomain.CurrentDomain.BaseDirectory + @"\" + ConfigurationManager.AppSettings["SigningCertificate"],
                password: ConfigurationManager.AppSettings["SigningCertificatePassword"]);

            var identityServerOptions = new IdentityServerOptions
            {
                Factory = identityServerServiceFactory,
                SigningCertificate = signingCertificate,
                RequireSsl = false
            };

            appBuilder.UseIdentityServer(identityServerOptions);
        }
    }
}
