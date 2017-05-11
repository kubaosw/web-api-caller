using System.Threading.Tasks;

namespace WebApiCaller.Core
{
    public interface IWebApiCaller
    {
        Task<TOutputType> Get<TOutputType>();

        Task<TOutputType> Get<TInputType, TOutputType>(TInputType input);

        Task<TOutputType> Put<TInputType, TOutputType>(TInputType input);

        Task<TOutputType> Post<TInputType, TOutputType>(TInputType input);

        Task<TOutputType> Delete<TInputType, TOutputType>(TInputType input);
    }
}