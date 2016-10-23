using System.Collections.Generic;
using IdentityServer3.Core;
using IdentityServer3.Core.Models;
using IdentityServer3.Core.Services.InMemory;
using System.Configuration;

namespace OAuthTokenServerService.AuthenticationDetails
{
    class InMemoryAuthenticationManager
    {
        public List<InMemoryUser> GetUsers()
        {
            return new List<InMemoryUser>
            {
                new InMemoryUser
                {
                    Enabled = true,
                    Username = "aditya",
                    Password = "test",
                    Subject = "Aditya",
                    Claims = new List<System.Security.Claims.Claim>
                    {
                        new System.Security.Claims.Claim(Constants.ClaimTypes.Email, "aditya.magotra@gmail.com"),
                        new System.Security.Claims.Claim(Constants.ClaimTypes.Name, "Aditya"),
                        new System.Security.Claims.Claim(Constants.ClaimTypes.Role, "Read")
                    }
                }
            };
        }

        public List<Scope> GetScopes()
        {
            return new List<Scope>
            {
                new Scope
                {
                     Name = "Read",
                     DisplayName = "Read User Data",
                     //Required = true,
                     //IncludeAllClaimsForUser = true,
                     //Claims = new List<ScopeClaim>()
                     //{
                     //    new ScopeClaim
                     //    {
                     //        Name = "Read",
                     //        AlwaysIncludeInIdToken = true,
                     //        Description = "Read Data"
                     //    }
                     //}
                },
                StandardScopes.OpenId,
                StandardScopes.Profile,
                StandardScopes.OfflineAccess
            };
        }

        public List<Client> GetClients()
        {
            return new List<Client>
            {
                GetSpaClient()
            };
        }

        private static Client GetSpaClient()
        {
            return new Client
            {
                ClientId = "oauth2_api",
                ClientSecrets = new List<Secret>
                {
                    new Secret("oauth2apiservicessecret".Sha256())
                },
                Enabled = true,
                Flow = Flows.ResourceOwner,
                AllowedScopes = new List<string>
                {
                    Constants.StandardScopes.OpenId,
                    Constants.StandardScopes.Profile,
                    "Read"
                }
            };
        }

        private static Client GetMvcClient()
        {
            var redirectUrl = ConfigurationManager.AppSettings["RedirectUrl"];
            var postRedirectUrl = ConfigurationManager.AppSettings["RedirectUrl"];

            return new Client
            {
                ClientId = "oauth2_mvc",
                ClientSecrets = new List<Secret>
                {
                    new Secret("oauth2_mvc".Sha256())
                },
                Enabled = true,
                Flow = Flows.Implicit,
                AllowedScopes = new List<string>
                {
                    Constants.StandardScopes.OpenId,
                    Constants.StandardScopes.Profile,
                    "read",
                    Constants.StandardScopes.Roles
                },
                RedirectUris = new List<string>
                {
                    redirectUrl
                },
                PostLogoutRedirectUris = new List<string>
                {
                    postRedirectUrl
                }
            };
        }
    }
}
