using System.Web.Http;

namespace Insurance.Api
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            SwaggerConfig.Register();

            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
