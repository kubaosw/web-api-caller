using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace WebApiCaller.Core
{
    public abstract class WebApiCallerBase : IDisposable, IWebApiCaller
    {
        protected readonly string _webApiUrl;

        private HttpClientWrapper _httpClientWrapper;

        public WebApiCallerBase(string webApiUrl)
        {
            _webApiUrl = webApiUrl;

            _httpClientWrapper = new HttpClientWrapper(_webApiUrl);
        }

        public void UseHttpClientProvider(IHttpClientProvider provider)
        {
            _httpClientWrapper = new HttpClientWrapper(provider, _webApiUrl);
        }

        public Task<TOutputType> Get<TOutputType>()
        {
            return Get<object, TOutputType>(String.Empty);
        }

        public Task<TOutputType> Get<TInputType, TOutputType>(TInputType input)
        {
            return GetResultUsingQueryString<TInputType, TOutputType>(input, HttpMethod.Get);
        }

        public Task<TOutputType> Put<TInputType, TOutputType>(TInputType input)
        {
            return GetResultUsingStringContent<TInputType, TOutputType>(input, HttpMethod.Put);
        }

        public Task<TOutputType> Post<TInputType, TOutputType>(TInputType input)
        {
            return GetResultUsingStringContent<TInputType, TOutputType>(input, HttpMethod.Post);
        }

        public Task<TOutputType> Delete<TInputType, TOutputType>(TInputType input)
        {
            return GetResultUsingQueryString<TInputType, TOutputType>(input, HttpMethod.Delete);
        }

        private Task<TOutputType> GetResultUsingStringContent<TInputType, TOutputType>(TInputType input, HttpMethod method)
        {
            var content = GetStringContent(input);
            var request = _httpClientWrapper.GetResponseMessage(method, content);

            return GetRequestResult<TOutputType>(request);
        }

        private Task<TOutputType> GetResultUsingQueryString<TInputType, TOutputType>(TInputType input, HttpMethod method)
        {
            var queryStringUrl = GetQueryString(input);
            var request = _httpClientWrapper.GetResponseMessage(HttpMethod.Get, null, queryStringUrl);

            return GetRequestResult<TOutputType>(request);
        }

        private async Task<TOutputType> GetRequestResult<TOutputType>(Task<HttpResponseMessage> httpResponseMessage)
        {
            TOutputType result = default(TOutputType);

            return await httpResponseMessage.ContinueWith(requestTask =>
            {
                if (requestTask.Status == TaskStatus.RanToCompletion)
                {
                    requestTask.Result.EnsureSuccessStatusCode();

                    var resultValue = requestTask.Result.Content.ReadAsStringAsync().Result;

                    if (!String.IsNullOrEmpty(resultValue))
                    {
                        result = StringParser.ParseStringTo<TOutputType>(resultValue);
                    }
                }

                return result;
            });
        }

        private StringContent GetStringContent<TInputType>(TInputType input)
        {
            var content = StringifyRequestInput(input);

            return new StringContent(content, Encoding.UTF8, "application/json");
        }

        private string StringifyRequestInput<TInputType>(TInputType input)
        {
            var isSerialziable = StringParser.IsSerializable<TInputType>();

            if (!isSerialziable)
            {
                return StringParser.ChangeBase<TInputType, string>(input);
            }

            if (input == null)
            {
                return String.Empty;
            }

            return JsonConvert.SerializeObject(input);
        }

        private string GetQueryString(object input)
        {
            var queryString = input.ToQueryString();

            if (string.IsNullOrEmpty(queryString))
            {
                return string.Empty;
            }

            return string.Format("?{0}", queryString);
        }

        public void Dispose()
        {
            if (_httpClientWrapper != null)
            {
                _httpClientWrapper.Dispose();
            }
        }
    }
}