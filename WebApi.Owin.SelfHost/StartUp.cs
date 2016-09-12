using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.Http.Filters;
using System.Web.Http.Validation;
using Owin;
using WebApi.Custom.Filters;
using WebApi.Custom.Unity;
using WebApi.Custom.Validator;

namespace WebApi.Owin.SelfHost
{
    /// <summary>
    /// 
    /// </summary>
    public class StartUp
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="appBuilder"></param>
        public void Configuration(IAppBuilder appBuilder)
        {
            var config = new HttpConfiguration();

            config.EnableCors(new EnableCorsAttribute("*", "*", "*"));

            UnityContainerSetup(config);

            RoutingSetup(config);

            config.Services.Add(typeof(IFilterProvider), new CustomFilterProvider());

            config.Services.Add(typeof(ModelValidatorProvider), new ValidateProvider());

            appBuilder.UseWebApi(config);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="config"></param>
        private static void RoutingSetup(HttpConfiguration config)
        {
            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { controller = "api/Customer", action = "Get", id = RouteParameter.Optional }
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
