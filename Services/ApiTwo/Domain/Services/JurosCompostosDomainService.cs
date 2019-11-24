using ApiTwo.Core;
using ApiTwo.Domain.Interfaces;
using ApiTwo.Domain.Models;
using Microsoft.Extensions.Configuration;
using System;
using System.Globalization;
using System.Net.Http;
using System.Threading.Tasks;

namespace ApiTwo.Domain.Services
{
    public class JurosCompostosDomainService : IJurosCompostosDomainService
    {
        private readonly IHttpClientProvider _httpClientProvider;
        private readonly IConfiguration _configuration;

        public JurosCompostosDomainService(IHttpClientProvider httpClientProvider, IConfiguration configuration)
        {
            _httpClientProvider = httpClientProvider;
            _configuration = configuration;
        }
        
        public async Task<JurosCompostos> CalcularJurosCompostosAsync(JurosCompostos jurosCompostos)
        {
            var taxaJuros = await ObterTaxaDeJurosApiOneAsync();
            if(taxaJuros > 0)
            {
                jurosCompostos.TaxaJuros = taxaJuros;
                jurosCompostos.CalcularJurosCompostos();
                return jurosCompostos;
                
            };
            
            return default(JurosCompostos);
        }

        private async Task<decimal> ObterTaxaDeJurosApiOneAsync()
        {
            try
            {
                var requestUri = _configuration.GetSection("UrlApiOneBase").Value + "api/v1/taxajuros";
                var response = await _httpClientProvider.GetAsync(requestUri);
                var responseBody = await response.Content.ReadAsStringAsync();
                CultureInfo usCulture = new CultureInfo("en-US");
                var juros = Convert.ToDecimal(responseBody.Replace(",", ".").Trim(), usCulture);
                return Math.Round(juros, 2);
            }
            catch (HttpRequestException)
            {
                return 0;
            }
        }
    }
}
