using ApiTwo.Application.Base;
using ApiTwo.Application.Services.AppJurosCompostos;
using ApiTwo.Application.Services.AppJurosCompostos.Input;
using ApiTwo.Application.Services.AppJurosCompostos.ViewModel;
using ApiTwo.Domain.Interfaces;
using ApiTwo.Domain.Models;
using Moq;
using System.Threading.Tasks;
using Xunit;

namespace ApiTwo.Tests.Unit.Application
{
    public class JurosCompostosAppServiceUnitTest
    {
        [Fact]
        public async Task Metodo_CalcularJurosCompostosAsync_Deve_Retornar_Calculo_Com_Sucesso()
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

            var jurosCompostos = new JurosCompostos()
            {
                Meses = 5,
                TaxaJuros = 0,
                ValorInicial = 100
            };

            var jurosCompostosCalculado = new JurosCompostos()
            {
                Meses = 5,
                TaxaJuros = 0.01m,
                ValorInicial = 100
            };

            var jurosCompostosDomainServiceMock = new Mock<IJurosCompostosDomainService>();
            jurosCompostosDomainServiceMock.Setup(x => x.ObterTaxaDeJurosApiOneAsync()).ReturnsAsync(0.01m);
            jurosCompostosDomainServiceMock.Setup(x => x.CalcularJurosCompostosAsync(jurosCompostos)).ReturnsAsync(jurosCompostosCalculado);

            var jurosCompostosAppService = new JurosCompostosAppService(jurosCompostosDomainServiceMock.Object);
            var result = await jurosCompostosAppService.CalcularJurosCompostosAsync(input);
            Assert.NotNull(result);
            Assert.False(result.Error);

        }

        [Fact]
        public async Task Metodo_CalcularJurosCompostosAsync_Deve_Retornar_Parametros_Invalidos()
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
                Error = false,
                Messages = null
            };

            var jurosCompostos = new JurosCompostos()
            {
                Meses = 5,
                TaxaJuros = 0,
                ValorInicial = 100
            };

            var jurosCompostosDomainServiceMock = new Mock<IJurosCompostosDomainService>();
            jurosCompostosDomainServiceMock.Setup(x => x.CalcularJurosCompostosAsync(jurosCompostos)).ReturnsAsync(jurosCompostos);

            var jurosCompostosAppService = new JurosCompostosAppService(jurosCompostosDomainServiceMock.Object);
            var result = await jurosCompostosAppService.CalcularJurosCompostosAsync(input);
            Assert.NotNull(result);
            Assert.True(result.Error);
        }

        [Fact]
        public async Task Metodo_CalcularJurosCompostosAsync_Deve_Retornar_Nao_Foi_Possivel_Calcular()
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

            var jurosCompostos = default(JurosCompostos);

            var jurosCompostosDomainServiceMock = new Mock<IJurosCompostosDomainService>();
            jurosCompostosDomainServiceMock.Setup(x => x.CalcularJurosCompostosAsync(jurosCompostos)).ReturnsAsync(jurosCompostos);

            var jurosCompostosAppService = new JurosCompostosAppService(jurosCompostosDomainServiceMock.Object);
            var result = await jurosCompostosAppService.CalcularJurosCompostosAsync(input);
            Assert.NotNull(result);
            Assert.True(result.Error);
        }
    }
}
