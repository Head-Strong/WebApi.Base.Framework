using System;
using System.Diagnostics;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;

namespace WebApi.Custom.Filters
{
    public class LoggingFilterAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(HttpActionContext actionContext)
        {
            base.OnActionExecuting(actionContext);

            var controllerName = actionContext.ControllerContext.ControllerDescriptor.ControllerName;

            var actionName = actionContext.ActionDescriptor.ActionName;

            var noOfArguments = actionContext.ActionArguments.Count;

            var requestTime = DateTime.Now;

            var message = $"Controller Name: {controllerName}, " +
                          $"Action Name: {actionName}, " +
                          $"Parameters: {noOfArguments}, " +
                          $"Time: {requestTime}";

            EventLog.WriteEntry("Application", message, EventLogEntryType.Information);
        }
    }
}