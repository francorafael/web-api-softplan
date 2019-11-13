using ApiOne.Domain.Services;
using Xunit;

namespace ApiOne.Tests.Unit.Domain.Services
{
    public class TaxaJurosDomainServiceUnitTest
    {
        [Fact]
        public void Metodo_ObterTaxaDeJuros_Deve_Retornar_Taxa_Juros_Igual_0_01()
        {
            var domainService = new TaxaJurosDomainService();
            var result = domainService.ObterTaxaDeJuros();
            Assert.Equal(0.01, result);
        }

        [Fact]
        public void Metodo_ObterTaxaDeJuros_Deve_Retornar_Taxa_Juros_Diferente_0_01()
        {
            var domainService = new TaxaJurosDomainService();
            var result = domainService.ObterTaxaDeJuros();
            Assert.NotEqual(0.02, result);
        }

    }
}
