using ApiTwo.Tests.Integration.Fixtures;
using FluentAssertions;
using System.Net;
using System.Threading.Tasks;
using Xunit;

namespace ApiTwo.Tests.Integration.Scenarios
{
    public class JurosCompostosControllerIntegrationTeste
    {
        private readonly TestContext _testContext;
        public JurosCompostosControllerIntegrationTeste()
        {
            _testContext = new TestContext();
        }

        [Fact]
        public async Task Metodo_GetAsync_Deve_Ser_Executado_Retornar_Status_Code_BadRequest()
        {
            var request = new
            {
                Url = "/api/v1/JurosCompostos/calculajuros?valorinicial=100&amp; meses=5",
                
            }; ;

            var response = await _testContext.Client.GetAsync(request.Url);
            response.StatusCode.Should().Be(HttpStatusCode.BadRequest);
        }

        [Fact]
        public async Task Metodo_GetAsync_Deve_Ser_Executado_Retornar_Status_Code_NotFound()
        {
            var request = new
            {
                Url = "/api/v1/JurosCompostos/?valorinicial=100&amp; meses=5",

            }; ;

            var response = await _testContext.Client.GetAsync(request.Url);
            response.StatusCode.Should().Be(HttpStatusCode.NotFound);
        }
    }
}
