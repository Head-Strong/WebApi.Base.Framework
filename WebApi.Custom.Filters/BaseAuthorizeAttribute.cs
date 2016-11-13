using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Controllers;

namespace WebApi.Custom.Filters
{
    public abstract class BaseAuthorizeAttribute : AuthorizeAttribute
    {
        protected readonly List<string> roles;

        protected BaseAuthorizeAttribute(List<string> roles)
        {
            this.roles = roles;
        }

        protected static void UnauthorizedAccess(HttpActionContext context)
        {
            context.Response = context.Request.CreateResponse(HttpStatusCode.Forbidden);
            context.Response.Headers.Add("Authorization","OAuth Authentication is Required");
        }
    }
}