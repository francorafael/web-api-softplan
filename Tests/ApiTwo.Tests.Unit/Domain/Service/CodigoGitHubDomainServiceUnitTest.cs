using ApiTwo.Domain.Services;
using Xunit;

namespace ApiTwo.Tests.Unit.Domain.Service
{
    public class CodigoGitHubDomainServiceUnitTest
    {
        [Fact]
        public void Metodo_ExibirUrlCodigoTesteSoftPlanoGitHub_Deve_Retornar_Url_Correta()
        {
            var domainService = new CodigoGitHubDomainService();
            var result = domainService.ExibirUrlCodigoTesteSoftPlanoGitHub();
            Assert.Equal("https://github.com/francorafael/web-api-softplan", result);
        }

        [Fact]
        public void Metodo_ExibirUrlCodigoTesteSoftPlanoGitHub_Deve_Retornar_Url_Errada()
        {
            var domainService = new CodigoGitHubDomainService();
            var result = domainService.ExibirUrlCodigoTesteSoftPlanoGitHub();
            Assert.NotEqual("http://google.com/", result);
        }
    }
}
