using System.Collections.Generic;
using System.Net;
using System.Web.Http;
using Insurance.Api.RequestHandlers;
using Insurance.Models.Policy;
using Swashbuckle.Swagger.Annotations;

namespace Insurance.Api.Controllers
{
    [RoutePrefix("v1")]
    public class PolicyController : ApiController
    {
        private readonly IPolicyRequestHandler requestHandler;

        public PolicyController(IPolicyRequestHandler requestHandler)
        {
            this.requestHandler = requestHandler;
        }

        [HttpGet]
        [Route("policy")]
        [SwaggerResponse(HttpStatusCode.OK, "Search for policy", typeof(List<SearchPolicyResponse>))]
        public IHttpActionResult Get([FromUri] SearchPolicyRequest request)
        {
            return ResponseMessage(requestHandler.GetPolicy(request));
        }
    }
}
