using System.Threading;
using System.Threading.Tasks;
using System.Web.Http.Filters;

namespace WebApi.Custom.Filters
{
    public class BasicAuthenticationFilter : IAuthenticationFilter
    {
        public bool AllowMultiple { get; }

        public Task AuthenticateAsync(HttpAuthenticationContext context, CancellationToken cancellationToken)
        {
            throw new System.NotImplementedException();
        }

        public Task ChallengeAsync(HttpAuthenticationChallengeContext context, CancellationToken cancellationToken)
        {
            throw new System.NotImplementedException();
        }
    }
}
