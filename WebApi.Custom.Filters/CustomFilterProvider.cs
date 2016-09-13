using System;
using System.Collections.Generic;
using System.Web.Http;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;

namespace WebApi.Custom.Filters
{
    public class CustomFilterProvider : IFilterProvider
    {
        private static readonly Dictionary<RequestType, Type[]> RegisteredFilters;

        #region Request Type
        private class RequestType
        {
            public RequestType(string controllerName, string actionName)
            {
                ControllerName = controllerName;
                ActionName = actionName;
            }

            private string ControllerName { get; }

            private string ActionName { get; }

            public override bool Equals(object obj)
            {
                var requestTypeObj = obj as RequestType;

                return Equals(requestTypeObj);

            }

            public override int GetHashCode()
            {
                unchecked
                {
                    return ((ControllerName?.GetHashCode() ?? 0)*397) ^ (ActionName?.GetHashCode() ?? 0);
                }
            }

            private bool Equals(RequestType other)
            {
                return string.Equals(ControllerName, other.ControllerName) && string.Equals(ActionName, other.ActionName);
            }

        }
        #endregion
        
        static CustomFilterProvider()
        {
            RegisteredFilters = new Dictionary<RequestType, Type[]>
            {
                //{
                //    new RequestType("Customer","Get"), new[]
                //    {
                //        typeof(LoggingFilterAttribute)
                //    }
                //},
                {
                    new RequestType("Customer","Post"), new[]
                    {
                        typeof(ValidateModelFilterAttribute)
                    }
                }
            };
        }

        public IEnumerable<FilterInfo> GetFilters(HttpConfiguration configuration, HttpActionDescriptor actionDescriptor)
        {
            var actionName = actionDescriptor.ActionName;
            var controllerName = actionDescriptor.ControllerDescriptor.ControllerName;

            var requestType = new RequestType(controllerName, actionName);

            var isValidAction = RegisteredFilters.ContainsKey(requestType);

            if (!isValidAction) yield break;

            var registeredFilters = RegisteredFilters[requestType];

            foreach (var registeredFilter in registeredFilters)
            {
                yield return new FilterInfo((IFilter)registeredFilter
                    .Assembly
                    .CreateInstance(registeredFilter.FullName),
                    FilterScope.Action);
            }
        }
    }
}
