using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using WebApi.Custom.Configuration;

namespace WebApi.Custom.MessageHandler
{
    public class CustomMessageHandler : DelegatingHandler
    {
        private const string RequestHeader = "RequestHeader";

        private IEnumerable<string> _headers;

        private readonly string _requestHeaderValueInConfig = CustomConfigReader.RequestHeaderValueInConfig;

        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            var responseMessage = default(HttpResponseMessage);

            if (request != default(HttpRequestMessage))
            {
                request.Headers.TryGetValues(RequestHeader, out _headers);

                var result = string.Empty;

                if (_headers != null)
                {
                    result= _headers.ToList()
                        .FirstOrDefault(x => x.Equals(_requestHeaderValueInConfig, StringComparison.OrdinalIgnoreCase));
                }

                if (string.IsNullOrWhiteSpace(result))
                {
                    responseMessage = new HttpResponseMessage(System.Net.HttpStatusCode.BadRequest)
                    {
                        Content = new StringContent("Invalid Request Specified (or) RequestHeader Missing!")
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
