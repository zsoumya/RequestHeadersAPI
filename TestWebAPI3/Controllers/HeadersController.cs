namespace TestWebAPI3.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Primitives;

    [Route("api/[controller]")]
    [ApiController]
    public class HeadersController : ControllerBase
    {
        [HttpGet("{key?}")]
        public ActionResult<IDictionary<string, string>> Get(string key)
        {
            IHeaderDictionary requestHeaders = this.HttpContext.Request.Headers;
            Dictionary<string, string> dictionary;

            if (!string.IsNullOrWhiteSpace(key))
            {
                dictionary = new Dictionary<string, string>
                {
                    {
                        key,
                        !StringValues.IsNullOrEmpty(requestHeaders[key]) ? string.Join('|', requestHeaders[key]) : "--NULL--"
                    }
                };
            }
            else
            {
                dictionary = requestHeaders.ToDictionary(requestHeader => requestHeader.Key,
                                                         requestHeader => string.Join('|', requestHeader.Value.ToArray()));
            }

            return dictionary;
        }
    }
}