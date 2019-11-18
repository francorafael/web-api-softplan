using ApiTwo.Controllers;
using ApiTwo.Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;

namespace ApiTwo.Tests.Unit.Controllers
{
    public class CodigoGitHubControllerUnitTest
    {
        [Fact]
        public void Metodo_Get_Deve_Retornar_Url_Teste_SoftPlan_GitHub_Com_Status_Code_200()
        {
            var domainServiceMock = new Mock<ICodigoGitHubDomainService>();
            domainServiceMock.Setup(x => x.ExibirUrlCodigoTesteSoftPlanoGitHub()).Returns("https://github.com/francorafael/web-api-softplan");
            var controller = new CodigoGitHubController(domainServiceMock.Object);
            var resultado = controller.Get();
            Assert.NotNull(resultado);
            var okResult = resultado as OkObjectResult;
            Assert.Equal("https://github.com/francorafael/web-api-softplan", okResult.Value);
            Assert.Equal(200, okResult.StatusCode);
        }
    }
}
