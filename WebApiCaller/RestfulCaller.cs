using WebApiCaller.Core;

namespace WebApiCaller
{
    public class RestfulCaller : WebApiCallerBase
    {
        public RestfulCaller(string webApiUrl) : base(webApiUrl)
        {
        }
    }
}