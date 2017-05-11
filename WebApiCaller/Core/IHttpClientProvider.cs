using System.Net.Http;

namespace WebApiCaller.Core
{
    public interface IHttpClientProvider
    {
        HttpClient GetHttpClient();
    }
}