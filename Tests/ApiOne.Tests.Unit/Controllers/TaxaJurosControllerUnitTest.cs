using ApiOne.Controllers;
using ApiOne.Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;

namespace ApiOne.Tests.Unit.Controllers
{
    public class TaxaJurosControllerUnitTest
    {

        [Fact]
        public void Metodo_Get_Deve_Retornar_Taxa_Juros_0_01_Com_Status_Code_200()
        {
            var domainServiceMock = new Mock<ITaxaJurosDomainService>();
            domainServiceMock.Setup(x => x.ObterTaxaDeJuros()).Returns(0.01m);
            var controller = new TaxaJurosController(domainServiceMock.Object);
            var resultado = controller.Get();
            Assert.NotNull(resultado);
            var okResult = resultado as OkObjectResult;
            Assert.Equal(0.01m, okResult.Value);
            Assert.Equal(200, okResult.StatusCode);
        }
    }
}
