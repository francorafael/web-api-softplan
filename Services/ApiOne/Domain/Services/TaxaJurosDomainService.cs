using ApiOne.Domain.Interfaces;

namespace ApiOne.Domain.Services
{
    public class TaxaJurosDomainService : ITaxaJurosDomainService
    {
        public double ObterTaxaDeJuros()
        {
            var taxaDeJuros = 0.01;
            return taxaDeJuros;
        }
    }
}
