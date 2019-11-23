using ApiTwo.Domain.Models;
using Xunit;

namespace ApiTwo.Tests.Unit.Domain.Models
{
    public class JurosCompostosTest
    {
        [Fact]
        public void Metodo_Calcular_Juros_Compostos_Deve_Retornar_105_10()
        {
            var juros = new JurosCompostos()
            {
                ValorInicial = 100,
                Meses = 5,
                TaxaJuros = 0.01m
            };

            Assert.Equal(105.10m, juros.JurosCompostosCalculado);
        }
    }
}
