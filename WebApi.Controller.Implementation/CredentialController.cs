using System.Web.Http;
using WebApi.Common.Utility;
using WebApi.Controller.Interface;

namespace WebApi.Controller.Implementation
{
    public class CredentialController : ApiController, ICredentialController
    {
        public string EncodedCredentials(string username, string password)
        {
            return CredentialManager.EncodedCredentials(username, password);
        }

        public string DecodeCredentials(string credential)
        {
            return CredentialManager.DecodeCredentials(credential);
        }
    }
}
