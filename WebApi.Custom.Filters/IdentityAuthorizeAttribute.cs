using System.Collections.Generic;
using System.Web;
using System.Web.Http.Controllers;

namespace WebApi.Custom.Filters
{
    public class IdentityAuthorizeAttribute : BaseAuthorizeAttribute
    {
        public IdentityAuthorizeAttribute(List<string> roles) : base(roles)
        {
        }

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
    }
}
