using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;
using System.Web;

namespace WebUIMiddleware
{
    public class QueryStringMidddleware
    {
        private readonly RequestDelegate _next;

        public QueryStringMidddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext httpContext)
        {
            var queryString = HttpUtility.ParseQueryString(httpContext.Request.QueryString.ToUriComponent());
            if (queryString.AllKeys != null)
            {
                foreach(var key in queryString.AllKeys)
                {
                    string value = queryString[key];
                    httpContext.Request.Headers.Add(key, value);
                }    
            }    

            //httpContext.Request.Headers.Add()

            await _next(httpContext);
        }
    }
}
