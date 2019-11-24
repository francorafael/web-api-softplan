using System.Net.Http;
using System.Threading.Tasks;

namespace ApiTwo.Core
{
    public interface IHttpClientProvider
    {
        Task<HttpResponseMessage> GetAsync(string requestUri);
    }
}
