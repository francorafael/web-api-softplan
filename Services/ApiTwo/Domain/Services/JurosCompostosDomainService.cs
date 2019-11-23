using ApiTwo.Domain.Interfaces;
using ApiTwo.Domain.Models;
using Microsoft.Extensions.Configuration;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace ApiTwo.Domain.Services
{
    public class JurosCompostosDomainService : IJurosCompostosDomainService
    {
        private readonly HttpClient _httpClient;
        private readonly IConfiguration _configuration;

        public JurosCompostosDomainService(HttpClient httpClient, IConfiguration configuration)
        {
            _httpClient = httpClient;
            _configuration = configuration;
        }
        
        public async Task<JurosCompostos> CalcularJurosCompostos(JurosCompostos jurosCompostos)
        {
            var taxaJuros = await ObterTaxaDeJurosApiOne();
            if(taxaJuros > 0)
            {
                jurosCompostos.TaxaJuros = taxaJuros;
                jurosCompostos.CalcularJurosCompostos();
                return jurosCompostos;
                
            };
            
            return default(JurosCompostos);
        }

        private async Task<decimal> ObterTaxaDeJurosApiOne()
        {
            try
            {
                var response = await _httpClient.GetAsync(_configuration.GetSection("UrlApiOneTaxaDeJuros").Value);
                response.EnsureSuccessStatusCode();
                var responseBody = await response.Content.ReadAsStringAsync();
                var juros = responseBody.Replace(".", ",");
                return Math.Round(Convert.ToDecimal(juros), 2);
            }
            catch (HttpRequestException)
            {
                return 0;
            }
        }
    }
}
