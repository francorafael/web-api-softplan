using Newtonsoft.Json;

namespace ApiTwo.Application.Services.AppJurosCompostos.Input
{
    public class JurosCompostosFiltroInput
    {
        [JsonProperty("valorinicial")]
        public decimal ValorInicial { get; set; }
        public int Meses { get; set; }
    }
}
