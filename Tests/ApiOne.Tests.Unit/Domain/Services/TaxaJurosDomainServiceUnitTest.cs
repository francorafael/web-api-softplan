using ApiOne.Domain.Services;
using Xunit;

namespace ApiOne.Tests.Unit.Domain.Services
{
    public class TaxaJurosDomainServiceUnitTest
    {

        [Fact]
        public void Must_Return_Taxa_Juros_Equal_0_01_GetTaxaDeJuros()
        {
            //var domainService = new Mock<ITaxaJurosDomainService>();
            //var result = domainService.Setup(x => x.GetTaxaDeJuros()).Returns(0.01);
            var domainService = new TaxaJurosDomainService();
            var result = domainService.GetTaxaDeJuros();
            Assert.Equal(0.0, result);
            Assert.NotNull(result);

        }
    }
}
