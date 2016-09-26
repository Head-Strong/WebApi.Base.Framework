using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.Http.Filters;
using System.Web.Http.ModelBinding;
using System.Web.Http.Validation;
using WebApi.Custom.Filters;
using WebApi.Custom.MessageHandler;
using WebApi.Custom.ModalBinder;
using WebApi.Custom.Unity;
using WebApi.Custom.Validator;

namespace WebApi.App
{
    /// <summary>
    /// 
    /// </summary>
    public static class WebApiConfig
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="config"></param>
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services

            config.EnableCors(new EnableCorsAttribute("*", "*", "*"));

            UnityContainerSetup(config);

            RoutingSetup(config);

            config.Services.Insert(typeof(ModelBinderProvider), 0, new CustomModelBinderProvider());

            config.Services.Add(typeof(IFilterProvider), new CustomFilterProvider());

            //config.Services.Add(typeof(ModelValidatorProvider), new CustomValidateProvider());

            config.MessageHandlers.Add(new BasicAuthenticationMessageHandler());

            SwaggerConfig.Register();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="config"></param>
        private static void RoutingSetup(HttpConfiguration config)
        {
            // Web API routes
            config.MapHttpAttributeRoutes();

            //config.Routes.MapHttpRoute(
            //    name: "DefaultActionApi",
            //    routeTemplate: "api/{controller}/{action}/{id}",
            //    defaults: new { id = RouteParameter.Optional }
            //    );

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
                );
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="config"></param>
        private static void UnityContainerSetup(HttpConfiguration config)
        {
            var container = new UnityRegister().Register();

            config.DependencyResolver = new UnityResolver(container);
        }
    }
}
