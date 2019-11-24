using ApiTwo.Application.Base;
using ApiTwo.Application.Interfaces;
using ApiTwo.Application.Services.AppJurosCompostos.Input;
using ApiTwo.Application.Services.AppJurosCompostos.ViewModel;
using ApiTwo.Controllers;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System.Threading.Tasks;
using Xunit;

namespace ApiTwo.Tests.Unit.Controllers
{
    public class JurosCompostoControllerUnitTest
    {
        [Fact]
        public async Task Metodo_GetAsync_Deve_Retornar_Juros_Calculado_Com_Status_Code_200()
        {
            var input = new JurosCompostosInput()
            {
                Meses = 5,
                ValorInicial = 100
            };

            var viewModel = new JurosCompostosViewModel()
            {
                Meses = 5,
                TaxaJuros = 0.01m,
                ValorInicial = 100,
                JurosCompostosCalculado = 105.10m
            };

            var jsonResult = new JsonResultBase<JurosCompostosViewModel>()
            {
                Data = viewModel,
                Error = false,
                Messages = null
            };


            var appServiceMock = new Mock<IJurosCompostosAppService>();
            appServiceMock.Setup(x => x.CalcularJurosCompostosAsync(input)).ReturnsAsync(jsonResult);
            var controller = new JurosCompostosController(appServiceMock.Object);
            var resultado = await controller.GetAsync(input);
            Assert.NotNull(resultado);
            var okResult = resultado as OkObjectResult;
            Assert.Equal(200, okResult.StatusCode);
        }

        [Fact]
        public async Task Metodo_GetAsync_Deve_Retornar_Juros_Calculado_Com_Status_Code_400()
        {
            var input = new JurosCompostosInput()
            {
                Meses = 0,
                ValorInicial = 0
            };

            var viewModel = new JurosCompostosViewModel()
            {
                Meses = 5,
                TaxaJuros = 0.01m,
                ValorInicial = 100,
                JurosCompostosCalculado = 105.10m
            };

            var jsonResult = new JsonResultBase<JurosCompostosViewModel>()
            {
                Data = viewModel,
                Error = true,
                Messages = null
            };
            
            var appServiceMock = new Mock<IJurosCompostosAppService>();
            appServiceMock.Setup(x => x.CalcularJurosCompostosAsync(input)).ReturnsAsync(jsonResult);
            var controller = new JurosCompostosController(appServiceMock.Object);
            var resultado = await controller.GetAsync(input);
            Assert.NotNull(resultado);
            var badRequestResult = resultado as BadRequestObjectResult;
            Assert.Equal(400, badRequestResult.StatusCode);
        }
    }
}
