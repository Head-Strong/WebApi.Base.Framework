using System.Web.Http;
using WebApi.Common.Utility;
using WebApi.Controller.Interface;

namespace WebApi.Controller.Implementation
{
    public class CredentialController : ApiController, ICredentialController
    {
        /// <summary>
        /// Base 64 Encode.
        /// </summary>
        /// <param name="username">Username</param>
        /// <param name="password">Password</param>
        /// <returns>Encoded String Username:Password</returns>
        public string Get(string username, string password)
        {
            return CredentialManager.EncodedCredentials(username, password);
        }

        /// <summary>
        /// Decode of Credential
        /// </summary>
        /// <param name="credential">Encoded String</param>
        /// <returns>Decoded String</returns>
        public string Get(string credential)
        {
            return CredentialManager.DecodeCredentials(credential);
        }
    }
}
