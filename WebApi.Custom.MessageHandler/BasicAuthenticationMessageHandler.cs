using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using WebApi.Common.Utility;
using WebApi.Custom.Configuration;

namespace WebApi.Custom.MessageHandler
{
    public class BasicAuthenticationMessageHandler : DelegatingHandler
    {
        private const string AuthorizationHeader = "Authorization";

        private IEnumerable<string> _headers;

        private readonly string _userName = CustomConfigReader.UserNameInConfig;

        private readonly string _password = CustomConfigReader.PasswordInConfig;

        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            var responseMessage = default(HttpResponseMessage);

            if (request != default(HttpRequestMessage))
            {
                request.Headers.TryGetValues(AuthorizationHeader, out _headers);

                var result = string.Empty;

                var encodedCredential = CredentialManager.EncodedCredentials(_userName, _password);

                if (_headers != null)
                {
                    result= _headers.ToList()
                        .FirstOrDefault(x => x.Equals(encodedCredential));
                }

                if (string.IsNullOrWhiteSpace(result))
                {
                    responseMessage = new HttpResponseMessage(System.Net.HttpStatusCode.Unauthorized)
                    {
                        Content = new StringContent("Basic Authentication [Authorization: YWRpdHlhOnRlc3Q=]")
                    };
                }
                else
                {
                    responseMessage = await base.SendAsync(request, cancellationToken);
                }
            }

            return responseMessage;
        }
    }
}
