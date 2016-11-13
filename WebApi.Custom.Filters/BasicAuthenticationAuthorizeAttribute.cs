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
    public class BasicAuthenticationAuthorizeAttribute : BaseAuthorizeAttribute
    {
        public BasicAuthenticationAuthorizeAttribute(List<string> roles) : base(roles)
        {
        }

        public override void OnAuthorization(HttpActionContext actionContext)
        {
            var roleFound = roles.Select(role => Thread.CurrentPrincipal.IsInRole(role)).Any(checkAuthorization => checkAuthorization);

            if (!roleFound)
            {
                UnauthorizedAccess(actionContext);
            }
        }
    }
}
