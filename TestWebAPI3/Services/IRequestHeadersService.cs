namespace TestWebAPI3.Services
{
    using System.Collections.Generic;

    public interface IRequestHeadersService
    {
        IDictionary<string, string> GetHeaders(string key = null);
    }
}