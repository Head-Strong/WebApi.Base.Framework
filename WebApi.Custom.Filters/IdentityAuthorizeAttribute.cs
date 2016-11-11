using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using System.Web.Http.Controllers;

namespace WebApi.Custom.Filters
{
    public class IdentityAuthorizeAttribute : AuthorizeAttribute
    {
        public override void OnAuthorization(HttpActionContext actionContext)
        {
            var user = HttpContext.Current?.User;

            if (user != null && user.Identity.IsAuthenticated)
            {
                
            }
            else
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
