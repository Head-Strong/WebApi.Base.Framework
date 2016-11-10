using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Web.Http;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;

namespace WebApi.Custom.Filters
{
    public class BasicAuthenticationAuthorizeAttribute : AuthorizeAttribute
    {
        private readonly List<string> _roles;

        public BasicAuthenticationAuthorizeAttribute(List<string> roles)
        {
            _roles = roles;
        }

        public override void OnAuthorization(HttpActionContext actionContext)
        {
            var roleFound = _roles.Select(role => Thread.CurrentPrincipal.IsInRole(role)).Any(checkAuthorization => checkAuthorization);

            if (!roleFound)
            {
                UnauthorizedAccess(actionContext);
            }
        }

        private static void UnauthorizedAccess(HttpActionContext context)
        {
            context.Response = context.Request.CreateResponse(HttpStatusCode.Forbidden);
        }
    }
}
