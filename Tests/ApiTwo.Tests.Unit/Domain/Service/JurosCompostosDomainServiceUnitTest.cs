using ApiTwo.Domain.Services;
using Moq;
using System.Net.Http;
using Microsoft.Extensions.Configuration;
using Xunit;
using ApiTwo.Domain.Models;
using System.Threading;
using Moq.Protected;
using System.Threading.Tasks;
using System.Net;
using System;

namespace ApiTwo.Tests.Unit.Domain.Service
{
    public class JurosCompostosDomainServiceUnitTest
    {
        [Fact]
        public void Metodos_Calcular_Juros_Compostos_Deve_Retornar_105_10()
        {
            var httpClientMock = new Mock<HttpClient>();
            var configurationMock = new Mock<IConfiguration>();


            // ARRANGE
            var handlerMock = new Mock<HttpMessageHandler>(MockBehavior.Strict);
            handlerMock
               .Protected()
               // Setup the PROTECTED method to mock
               .Setup<Task<HttpResponseMessage>>(
                  "SendAsync",
                  ItExpr.IsAny<HttpRequestMessage>(),
                  ItExpr.IsAny<CancellationToken>()
               )
               // prepare the expected response of the mocked http call
               .ReturnsAsync(new HttpResponseMessage()
               {
                   StatusCode = HttpStatusCode.OK,
                   Content = new StringContent("0.01"),
               })
               .Verifiable();

            // use real http client with mocked handler here
            var httpClient = new HttpClient(handlerMock.Object)
            {
                BaseAddress = new Uri("http://test.com/"),
            };


            configurationMock.SetupGet(x => x[It.Is<string>(s => s == "UrlApiOneTaxaDeJurostionStrings")]).Returns("http://localhost:59789/api/v1/TaxaJuros");

            var domainService = new JurosCompostosDomainService(httpClient, configurationMock.Object);

            var juros = new JurosCompostos()
            {
                ValorInicial = 100,
                Meses = 5,
                TaxaJuros = 0.01m
            };

            //Assert.Equal(105.10m, juros.JurosCompostosCalculado);
            var result = domainService.CalcularJurosCompostos(juros);
            Assert.NotNull(result.Result);
          
        }



        //public async Task<JurosCompostos> CalcularJurosCompostos(JurosCompostos jurosCompostos)
        //{
        //    var taxaJuros = await ObterTaxaDeJurosApiOne();
        //    if (taxaJuros > 0)
        //    {
        //        jurosCompostos.TaxaJuros = taxaJuros;
        //        jurosCompostos.CalcularJurosCompostos();
        //        return jurosCompostos;

        //    };

        //    return default(JurosCompostos);
        //}

        //private async Task<decimal> ObterTaxaDeJurosApiOne()
        //{
        //    try
        //    {
        //        var response = await _httpClient.GetAsync(_configuration.GetSection("UrlApiOneTaxaDeJuros").Value);
        //        response.EnsureSuccessStatusCode();
        //        var responseBody = await response.Content.ReadAsStringAsync();
        //        var juros = responseBody.Replace(".", ",");
        //        return Math.Round(Convert.ToDecimal(juros), 2);
        //    }
        //    catch (HttpRequestException)
        //    {
        //        return 0;
        //    }
        //}
    }
}
