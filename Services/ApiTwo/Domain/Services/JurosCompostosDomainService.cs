using ApiTwo.Domain.Core.Classes;
using ApiTwo.Domain.Interfaces;
using ApiTwo.Domain.Models;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace ApiTwo.Domain.Services
{
    public class JurosCompostosDomainService : IJurosCompostosDomainService
    {
        private readonly HttpClient _httpClient;
        public JurosCompostosDomainService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        
        public async Task<JurosCompostos> CalcularJurosCompostos(JurosCompostos jurosCompostos)
        {
            var taxaJuros = await ObterTaxaDeJurosApiOne();
            if(taxaJuros > 0)
            {
                return default(JurosCompostos);
            };
            
            return default(JurosCompostos);
        }

        private async Task<decimal> ObterTaxaDeJurosApiOne()
        {
            try
            {
                var response = await _httpClient.GetAsync(UrlApiTaxaJuros.Url);
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
