namespace TestWebAPI3.Services
{
    using System.Collections.Generic;
    using System.Linq;

    using Microsoft.AspNetCore.Http;
    using Microsoft.Extensions.Primitives;

    public class RequestHeadersService : IRequestHeadersService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public RequestHeadersService(IHttpContextAccessor httpContextAccessor)
        {
            this._httpContextAccessor = httpContextAccessor;
        }

        public IDictionary<string, string> GetHeaders(string key = null)
        {
            IHeaderDictionary requestHeaders = this._httpContextAccessor.HttpContext.Request.Headers;
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