using ApiOne.Tests.Integration.Fixtures;
using FluentAssertions;
using System.Net;
using System.Threading.Tasks;
using Xunit;

namespace ApiOne.Tests.Integration.Scenarios
{
    public class TaxaJurosControllerIntegrationTest
    {
        private readonly TestContext _testContext;
        public TaxaJurosControllerIntegrationTest()
        {
            _testContext = new TestContext();         
        }

        [Fact]
        public async Task Metodo_Get_Deve_Ser_Executado_Retornar_Status_Code_OK()
        {
            var request = new
            {
                Url = "/api/v1/taxaJuros"
            }; ;

            var response = await _testContext.Client.GetAsync(request.Url);
            response.StatusCode.Should().Be(HttpStatusCode.OK);
        }
    }
}
