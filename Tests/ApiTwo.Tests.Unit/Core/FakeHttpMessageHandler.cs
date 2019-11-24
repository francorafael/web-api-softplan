using System.Diagnostics.CodeAnalysis;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace ApiTwo.Tests.Unit.Core
{
    [ExcludeFromCodeCoverage]
    public class FakeHttpMessageHandler : HttpMessageHandler
    {
        public virtual HttpResponseMessage Send(HttpRequestMessage request)
        {
            HttpContent content = new StringContent("0.01");

            HttpResponseMessage response = new HttpResponseMessage()
            {
                Content = content,
                StatusCode = HttpStatusCode.OK
            };

            return response;
        }

        protected async override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            return await Task.FromResult(Send(request));
        }
    }
}
