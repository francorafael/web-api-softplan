using ApiTwo.Core.Providers;
using ApiTwo.Domain.Models;
using ApiTwo.Domain.Services;
using ApiTwo.Tests.Unit.Core;
using Microsoft.Extensions.Configuration;
using Moq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Xunit;

namespace ApiTwo.Tests.Unit.Domain.Service
{
    public class JurosCompostosDomainServiceUnitTest
    {
        [Fact]
        public async Task Metodo_CalcularJurosCompostosAsync_Deve_Retornar_Juros_Calculado_105_10m()
        {
            var httpClientMock = new Mock<HttpClient>();
            var configurationMock = new Mock<IConfiguration>();

            var configurationSectionMock = new Mock<IConfigurationSection>();
            configurationSectionMock.Setup(x => x.Value).Returns("http://localhost:59789/api/v1/TaxaJuros");
            configurationMock.Setup(x => x.GetSection("UrlApiOneTaxaDeJuros")).Returns(configurationSectionMock.Object);

            var fakeHttpMessageHandler = new Mock<FakeHttpMessageHandler> { CallBase = true };
            HttpContent content = new StringContent("0.01");
            fakeHttpMessageHandler.Setup(x => x.Send(It.IsAny<HttpRequestMessage>()))
                                  .Returns(new HttpResponseMessage()
                                  {
                                      Content = content,
                                      StatusCode = HttpStatusCode.OK
                                  });

            var fakeHttpClient = new HttpClient(fakeHttpMessageHandler.Object);

            var httpClientProvider = new HttpClientProvider(fakeHttpClient);


            var domainService = new JurosCompostosDomainService(httpClientProvider, configurationMock.Object);
            var juros = new JurosCompostos()
            {
                ValorInicial = 100,
                Meses = 5,
                TaxaJuros = 0.01m
            };

            var result = await domainService.CalcularJurosCompostosAsync(juros);
            Assert.NotNull(result);
            Assert.Equal(105.10m, result.JurosCompostosCalculado);
        }

        [Fact]
        public async Task Metodo_CalcularJurosCompostosAsync_Deve_Retornar_Null()
        {
            var httpClientMock = new Mock<HttpClient>();
            var configurationMock = new Mock<IConfiguration>();

            var configurationSectionMock = new Mock<IConfigurationSection>();
            configurationSectionMock.Setup(x => x.Value).Returns("http://localhost:59789/api/v1/TaxaJuros");
            configurationMock.Setup(x => x.GetSection("UrlApiOneTaxaDeJuros")).Returns(configurationSectionMock.Object);

            var fakeHttpMessageHandler = new Mock<FakeHttpMessageHandler> { CallBase = true };
            HttpContent content = new StringContent("0.00");
            fakeHttpMessageHandler.Setup(x => x.Send(It.IsAny<HttpRequestMessage>()))
                                  .Returns(new HttpResponseMessage()
                                  {
                                      Content = content,
                                      StatusCode = HttpStatusCode.OK
                                  });

            var fakeHttpClient = new HttpClient(fakeHttpMessageHandler.Object);

            var httpClientProvider = new HttpClientProvider(fakeHttpClient);


            var domainService = new JurosCompostosDomainService(httpClientProvider, configurationMock.Object);
            var juros = new JurosCompostos()
            {
                ValorInicial = 100,
                Meses = 5,
                TaxaJuros = 0.00m
            };

            var result = await domainService.CalcularJurosCompostosAsync(juros);
            Assert.Null(result);
        }

    }

}
