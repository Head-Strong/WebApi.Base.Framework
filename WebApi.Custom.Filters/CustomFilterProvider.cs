using System;
using System.Collections.Generic;
using System.Reflection;
using System.Web.Http;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;
using WebApi.Common.Utility;

namespace WebApi.Custom.Filters
{
    public class CustomFilterProvider : IFilterProvider
    {
        private static readonly Dictionary<RequestType, CustomType[]> RegisteredFilters;

        #region Custom Type
        private class CustomType
        {
            public CustomType(Type type)
            {
                Type = type;
            }

            public CustomType(Type type, List<string> roles) : this(type)
            {
                Roles = roles;
            }

            public Type Type { get; }

            public List<string> Roles { get; }
        }
        #endregion

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
                    return ((ControllerName?.GetHashCode() ?? 0) * 397) ^ (ActionName?.GetHashCode() ?? 0);
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
            RegisteredFilters = new Dictionary<RequestType, CustomType[]>
            {
                {
                    new RequestType("Customer","Get"), new[]
                    {
                       new CustomType(typeof(LoggingFilterAttribute)),
                       new CustomType(typeof(BasicAuthenticationAuthorizeAttribute),
                                        new List<string> { Roles.Read.ToString()}),
                    }
                },
                {
                    new RequestType("Customer","Post"), new[]
                    {
                        new CustomType(typeof(ValidateModelFilterAttribute)),
                        new CustomType(typeof(BasicAuthenticationAuthorizeAttribute),
                                        new List<string> {Roles.Write.ToString()}),
                    }
                },
                {
                    new RequestType("Customer","Delete"), new[]
                    {
                        new CustomType(typeof(ValidateModelFilterAttribute)),
                        new CustomType(typeof(BasicAuthenticationAuthorizeAttribute),
                                        new List<string> {Roles.Delete.ToString()}),
                    }
                },
                {
                    new RequestType("Customer","PostAsync"), new[]
                    {
                        new CustomType( typeof(ValidateModelFilterAttribute)),
                        new CustomType(typeof(BasicAuthenticationAuthorizeAttribute),
                                        new List<string> {Roles.Write.ToString()}),
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
                if (registeredFilter.Roles != null)
                {

                    yield return new FilterInfo((IFilter)registeredFilter.Type.Assembly.CreateInstance(registeredFilter.Type.FullName,
                            true,
                            BindingFlags.CreateInstance,
                            null,
                            new object[] { registeredFilter.Roles },
                            null,
                            null)
                        , FilterScope.Action);
                }
                else
                {
                    yield return new FilterInfo((IFilter)registeredFilter.Type.Assembly.CreateInstance(registeredFilter.Type.FullName)
                                    , FilterScope.Action);
                }
            }
        }
    }
}
