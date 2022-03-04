using System.Net;
using System.Web.Http;
using Insurance.Api.RequestHandlers;
using Insurance.Models.Claim;
using Swashbuckle.Swagger.Annotations;

namespace Insurance.Api.Controllers
{
    [RoutePrefix("v1")]
    public class ClaimController : ApiController
    {
        private readonly IClaimRequestHandler requestHandler;

        public ClaimController(IClaimRequestHandler requestHandler)
        {
            this.requestHandler = requestHandler;
        }

        [HttpGet]
        [Route("claim/{claimNumber}")]
        [SwaggerResponse(HttpStatusCode.OK, "Search for claim", typeof(SearchClaimResponse))]
        public IHttpActionResult GetClaim([FromUri] int claimNumber)
        {
            var request = new SearchClaimRequest()
            {
                ClaimNumber = claimNumber
            };

            return ResponseMessage(requestHandler.GetClaim(request));
        }

        [HttpPost]
        [Route("claim")]
        [SwaggerResponse(HttpStatusCode.OK, "Submit new claim", typeof(CreateClaimResponse))]
        public IHttpActionResult SubmitClaim([FromBody] CreateClaimRequest request)
        {
            return ResponseMessage(requestHandler.SubmitClaim(request));
        }
    }
}
