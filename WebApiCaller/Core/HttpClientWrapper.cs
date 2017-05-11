using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace WebApiCaller.Core
{
    public class HttpClientWrapper : IDisposable
    {
        private const string JsonMediaTypeHeaderValue = "application/json";

        private readonly HttpClient _httpClient;
        private readonly string _baseUrl;

        public HttpClientWrapper(IHttpClientProvider httpClientProvider, string baseUrl)
        {
            _baseUrl = baseUrl;
            _httpClient = httpClientProvider.GetHttpClient();
        }

        public HttpClientWrapper(string baseUrl)
        {
            _baseUrl = baseUrl;
            _httpClient = new HttpClient();
        }

        public Task<HttpResponseMessage> GetResponseMessage(HttpMethod method, StringContent content = null, string relativeUrl = null)
        {
            return GetResponseMessage(JsonMediaTypeHeaderValue, method, content, relativeUrl);
        }

        public Task<HttpResponseMessage> GetResponseMessage(string mediaTypeHeaderValue, HttpMethod method, StringContent content = null, string relativeUrl = null)
        {
            var request = new HttpRequestMessage();
            var mediaTypeHeader = new MediaTypeWithQualityHeaderValue(mediaTypeHeaderValue);

            request.RequestUri = new Uri(_baseUrl + relativeUrl);
            request.Headers.Accept.Add(mediaTypeHeader);
            request.Method = method;

            if (content != null)
            {
                request.Content = content;
            }

            return _httpClient.SendAsync(request);
        }

        public void Dispose()
        {
            _httpClient.Dispose();
        }
    }
}