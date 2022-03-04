using System.Web.Http;
using Insurance.Api.Filters;

namespace Insurance.Api
{
    public class FilterConfig
    {
        public static void Register(HttpConfiguration config)
        {
            config.Filters.Add(new GlobalExceptionFilter());
            //config.Filters.Add(new AuthorizeAttribute());
        }
    }
}
