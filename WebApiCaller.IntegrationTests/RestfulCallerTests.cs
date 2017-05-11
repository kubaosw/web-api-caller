using WebApiCaller_IntegrationTests.Base;
using WebApiCaller_IntegrationTests.Dto;
using Xunit;

namespace WebApiCaller.IntegrationTests
{
    //public class RestfulCallerTests
    //{
    //    private readonly TestHttpServer _httpServer;
    //    private readonly Fixture _fixture;

    //    public RestfulCallerTests()
    //    {
    //        _httpServer = new TestHttpServer();
    //        _fixture = new Fixture();
    //    }

    //    [Fact]
    //    public void GetCallWithoutInput_CallServer_OkMessageReceived()
    //    {
    //        var restfulCaller = GetRestfulCaller();
    //        var result = restfulCaller.Get<string>().Result;

    //        AssertOk(result);
    //    }

    //    [Fact]
    //    public void GetCallWithInput_CallServer_OkMessageReceived()
    //    {
    //        var input = _fixture.Create<InputDto>();
    //        var restfulCaller = GetRestfulCaller();
    //        var result = restfulCaller.Get<InputDto, string>(input).Result;

    //        AssertOk(result);
    //    }

    //    [Fact]
    //    public void PostCallWithInput_CallServer_OkMessageReceived()
    //    {
    //        var input = _fixture.Create<InputDto>();
    //        var restfulCaller = GetRestfulCaller();
    //        var result = restfulCaller.Post<InputDto, string>(input).Result;

    //        AssertOk(result);
    //    }

    //    [Fact]
    //    public void PutCallWithInput_CallServer_OkMessageReceived()
    //    {
    //        var input = _fixture.Create<InputDto>();
    //        var restfulCaller = GetRestfulCaller();
    //        var result = restfulCaller.Put<InputDto, string>(input).Result;

    //        AssertOk(result);
    //    }

    //    [Fact]
    //    public void DeleteCallWithInput_CallServer_OkMessageReceived()
    //    {
    //        var input = _fixture.Create<InputDto>();
    //        var restfulCaller = GetRestfulCaller();
    //        var result = restfulCaller.Delete<InputDto, string>(input).Result;

    //        AssertOk(result);
    //    }

    //    private void AssertOk(object result)
    //    {
    //        Assert.NotNull(result);
    //        Assert.True(result is string);
    //        Assert.Equal(WebApiKeyHandler.OkMessage, (string)result);
    //    }

    //    private RestfulCaller GetRestfulCaller()
    //    {
    //        var restfulCaller = new RestfulCaller(TestHttpServer.ServerUrl);

    //        restfulCaller.UseHttpClientProvider(_httpServer);

    //        return restfulCaller;
    //    }
    //}
}