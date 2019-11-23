using ApiOne.Domain.Interfaces;

namespace ApiOne.Domain.Services
{
    public class TaxaJurosDomainService : ITaxaJurosDomainService
    {
        public decimal ObterTaxaDeJuros()
        {
            var taxaDeJuros = 0.01m;
            return taxaDeJuros;
        }
    }
}
