using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Security.Principal;
using System.Threading;
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
            var user = HttpContext.Current?.User as ClaimsPrincipal;

            if (user != null && user.Identity.IsAuthenticated)
            {
                var claims = user.Claims.ToList().FindAll(x => x.Type.Contains("profile"));

                var claimsAssociatedWithUser = claims.Select(claim => claim.Value).ToArray();

                var roleFound = claimsAssociatedWithUser.Any(userClaim => roles.Contains(userClaim));

                if (!roleFound)
                {
                    UnauthorizedAccess(actionContext);
                }
            }
            else
            {
                UnauthorizedAccess(actionContext);
            }
        }       
    }
}
