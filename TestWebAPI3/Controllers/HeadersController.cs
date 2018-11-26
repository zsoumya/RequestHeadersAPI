namespace TestWebAPI3.Controllers
{
    using System.Collections.Generic;
    using System.Linq;

    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Primitives;

    using Services;

    [Route("api/[controller]")]
    [ApiController]
    public class HeadersController : ControllerBase
    {
        private IRequestHeadersService _requestHeadersService;

        public HeadersController(IRequestHeadersService requestHeadersService)
        {
            this._requestHeadersService = requestHeadersService;
        }

        [HttpGet]
        public ActionResult<IDictionary<string, string>> Get()
        {
            return this.Get(null);
        }


        [HttpGet("{key}")]
        public ActionResult<IDictionary<string, string>> Get(string key)
        {
            IDictionary<string, string> dictionary = this._requestHeadersService.GetHeaders(key);
            return this.Ok(dictionary);
        }
    }
}