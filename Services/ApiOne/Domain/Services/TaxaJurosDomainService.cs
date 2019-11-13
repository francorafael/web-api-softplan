using ApiOne.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
