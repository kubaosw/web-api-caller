using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace WebApiCaller_IntegrationTests.Base
{
    public class WebApiKeyHandler : DelegatingHandler
    {
        public const string OkMessage = "OK";

        protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            return SendOk(OkMessage, HttpStatusCode.OK);
        }

        private Task<HttpResponseMessage> SendOk(string message, HttpStatusCode code)
        {
            var response = new HttpResponseMessage();
            response.Content = new StringContent(message);
            response.StatusCode = code;
            return Task<HttpResponseMessage>.Factory.StartNew(() => response);
        }
    }
}