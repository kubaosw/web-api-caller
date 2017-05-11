using System;
using System.Net.Http;
using WebApiCaller.Core;

namespace WebApiCaller_IntegrationTests.Base
{
    //public class TestHttpServer : IDisposable, IHttpClientProvider
    //{
    //    public const string ServerUrl = "http://testhost.com/api/test";

    //    private readonly HttpServer _httpServer;

    //    public TestHttpServer()
    //    {
    //        _httpServer = GetHttpServer();
    //    }

    //    public HttpClient GetHttpClient()
    //    {
    //        return new HttpClient(_httpServer);
    //    }

    //    private HttpServer GetHttpServer()
    //    {
    //        var serverConfiguration = GetServerConfiguration();

    //        return new HttpServer(serverConfiguration);
    //    }

    //    private HttpConfiguration GetServerConfiguration()
    //    {
    //        var config = new HttpConfiguration();

    //        config.Routes.MapHttpRoute(name: "Default", routeTemplate: "api/{controller}/{action}/{id}", defaults: new { id = RouteParameter.Optional });
    //        config.IncludeErrorDetailPolicy = IncludeErrorDetailPolicy.Always;
    //        config.MessageHandlers.Add(new WebApiKeyHandler());

    //        return config;
    //    }

    //    public void Dispose()
    //    {
    //        if (_httpServer != null)
    //        {
    //            _httpServer.Dispose();
    //        }
    //    }
    //}
}