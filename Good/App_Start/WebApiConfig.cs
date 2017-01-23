using System.Web.Http;
using Good.App_Start;

namespace Good
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            //Dependency injection
            DependencyInjectionConfig.Configure(config);

            // Web API configuration and services

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
