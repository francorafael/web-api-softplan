using ApiOne.Domain.Services;
using Xunit;

namespace ApiOne.Tests.Unit.Domain.Services
{
    public class TaxaJurosDomainServiceUnitTest
    {
        [Fact]
        public void Must_Return_Taxa_Juros_Equal_0_01_GetTaxaDeJuros()
        {
            var domainService = new TaxaJurosDomainService();
            var result = domainService.GetTaxaDeJuros();
            Assert.Equal(0.01, result);
        }

        [Fact]
        public void Must_Return_Taxa_Juros_Different_0_01_GetTaxaDeJuros()
        {
            var domainService = new TaxaJurosDomainService();
            var result = domainService.GetTaxaDeJuros();
            Assert.NotEqual(0.02, result);
        }

    }
}
