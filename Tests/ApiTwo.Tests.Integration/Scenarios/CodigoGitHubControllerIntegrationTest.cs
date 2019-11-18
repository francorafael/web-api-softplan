using ApiTwo.Tests.Integration.Fixtures;
using FluentAssertions;
using System.Net;
using System.Threading.Tasks;
using Xunit;

namespace ApiTwo.Tests.Integration.Scenarios
{
    public class CodigoGitHubControllerIntegrationTest
    {
        private readonly TestContext _testContext;
        public CodigoGitHubControllerIntegrationTest()
        {
            _testContext = new TestContext();
        }

        [Fact]
        public async Task Metodo_Get_Deve_Ser_Executado_Retornar_Status_Code_OK()
        {
            var request = new
            {
                Url = "/api/v1/CodigoGitHub/showmethecode"
            }; ;

            var response = await _testContext.Client.GetAsync(request.Url);
            response.StatusCode.Should().Be(HttpStatusCode.OK);
        }
    }
}
