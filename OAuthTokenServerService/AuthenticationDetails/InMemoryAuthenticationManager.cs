using System.Collections.Generic;
using IdentityServer3.Core;
using IdentityServer3.Core.Models;
using IdentityServer3.Core.Services.InMemory;
using System.Configuration;
using System.Security.Claims;

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
                    Password = "admin",
                    Subject = "Adi-Admin",
                    Claims = new List<Claim>
                    {
                       new Claim(Constants.ClaimTypes.Profile, "fo-write"),
                       new Claim(Constants.ClaimTypes.Profile, "fo-read")
                    }                    
                },
                new InMemoryUser
                {
                    Enabled = true,
                    Username = "adi",
                    Password = "read",
                    Subject = "Adi-Read",
                    Claims = new List<Claim>
                    {
                        new Claim(Constants.ClaimTypes.Profile, "fo-read")
                    },                   
                }
            };
        }

        public List<Scope> GetScopes()
        {
            var scopes = new List<Scope>
            {
                new Scope
                {
                    Enabled = true,
                    Name = "adread",
                    Type = ScopeType.Resource,
                    Claims = new List<ScopeClaim>
                    {
                        new ScopeClaim(Constants.ClaimTypes.Profile),                        
                    }
                },
                new Scope
                {
                    Enabled = true,
                    Name = "adwrite",
                    Type = ScopeType.Resource,
                    Claims = new List<ScopeClaim>
                    {
                        new ScopeClaim(Constants.ClaimTypes.Profile),                        
                    }
                }
            };

            scopes.AddRange(StandardScopes.All);

            return scopes;
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
                    "adread",
                    "adwrite",
                    Constants.StandardScopes.OpenId,                
                }
            };
        }

        #region MvcClient
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
        #endregion
    }
}
