using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Security.Principal;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using WebApi.Common.Utility;
using WebApi.Domains;

namespace WebApi.Custom.MessageHandler
{
    public class BasicAuthenticationMessageHandler : DelegatingHandler
    {
        private const string AuthorizationHeader = "Authorization";

        private IEnumerable<string> _headers;

        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            var responseMessage = default(HttpResponseMessage);

            if (request != default(HttpRequestMessage))
            {
                request.Headers.TryGetValues(AuthorizationHeader, out _headers);

                var user = default(User);

                if (_headers != null)
                {
                    user = UserManager.GetUserByPassword(_headers.ToList().FirstOrDefault());
                }

                if (user != default(User))
                {
                    SetUserDetails(user);

                    responseMessage = await base.SendAsync(request, cancellationToken);
                }
                else
                {
                    responseMessage = PrepareUnAuthorizedResponseMessage();
                }
            }

            return responseMessage;
        }

        private static void SetUserDetails(User user)
        {
            var genericIdentity = new GenericIdentity(user.UserName);

            var currentPrincipal = new GenericPrincipal(genericIdentity, user.Roles);

            Thread.CurrentPrincipal = currentPrincipal;

            if(HttpContext.Current != null)
            {
                HttpContext.Current.User = currentPrincipal;
            }
        }

        private static HttpResponseMessage PrepareUnAuthorizedResponseMessage()
        {
            var responseMessage = new HttpResponseMessage(System.Net.HttpStatusCode.Unauthorized)
            {
                Content = new StringContent("Basic Authentication [Authorization: Basic YWRpdHlhOnRlc3Q=]")
            };

            return responseMessage;
        }
    }
}
