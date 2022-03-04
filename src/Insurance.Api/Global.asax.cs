using System.Web;
using System.Web.Http;
using Autofac.Integration.WebApi;

namespace Insurance.Api
{
    public class WebApiApplication : HttpApplication
    {
        protected void Application_Start()
        {            
            var config = GlobalConfiguration.Configuration;

            IocConfig.RegisterModules();
            IocConfig.Build();
            
            config.DependencyResolver = new AutofacWebApiDependencyResolver(IocConfig.Container);
            
            GlobalConfiguration.Configure(WebApiConfig.Register);
            GlobalConfiguration.Configure(FilterConfig.Register);
        }
    }
}
