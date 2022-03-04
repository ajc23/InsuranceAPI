using System.Net.Http;
using System.Web.Http.Filters;
using Insurance.Api.Exceptions;
using Insurance.Api.Helpers;

namespace Insurance.Api.Filters
{
    public class GlobalExceptionFilter : ExceptionFilterAttribute
    {
        public override void OnException(HttpActionExecutedContext context)
        {
            if (context.Exception != null)
            {
                if (context.Exception is ValidationException)
                {
                    context.Response = ((ValidationException)context.Exception).ValidationResult.AsHttpResponseMessage();
                }
                else if (context.Exception is HttpException)
                {
                    HttpResponseMessage response = new HttpResponseMessage(((HttpException)context.Exception).HttpStatusCode)
                    {
                        Content = new StringContent(context.Exception.Message),
                    };
                    context.Response = response;
                }
            }
            if (context.Response != null && !context.Response.IsSuccessStatusCode)
            {
                var json = context.Response.Content.ReadAsStringAsync().Result;
            }
        }
    }
}
