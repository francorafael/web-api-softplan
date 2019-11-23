using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiTwo.Application.Base;
using ApiTwo.Application.Interfaces;
using ApiTwo.Application.Services.AppJurosCompostos.ViewModel;
using ApiTwo.Domain.Interfaces;
using ApiTwo.Domain.Models;

namespace ApiTwo.Application.Services.AppJurosCompostos
{
    public class JurosCompostosAppService: IJurosCompostosAppService
    {
        private readonly IJurosCompostosDomainService _jurosCompostosDomainService;

        public JurosCompostosAppService(
            IJurosCompostosDomainService jurosCompostosDomainService)
        {
            _jurosCompostosDomainService = jurosCompostosDomainService;
        }

        public async Task<JsonResultBase<JurosCompostosViewModel>> CalcularJurosCompostos(decimal valorInicial, int tempo)
        {
            var result = new JsonResultBase<JurosCompostosViewModel>();
            var validarParametros = ValidarParametrosJurosCompostos(valorInicial, tempo);
            
            if (validarParametros.Any())
            {
                result.Data = null;
                result.Error = true;
                result.Messages = validarParametros;
                return result;
            }

            var jurosCompostos = new JurosCompostos()
            {
                TaxaJuros = 0,
                Tempo = tempo,
                ValorInicial = valorInicial
            };

            var jurosCalculado = await _jurosCompostosDomainService.CalcularJurosCompostos(jurosCompostos);

            if (jurosCalculado == null)
            {
                var errorMsg = new ValidationMessageBase() { Message = "Não foi possível calcular o juros." };
                var listMsg = new List<ValidationMessageBase>();
                listMsg.Add(errorMsg);
                result.Data = null;
                result.Error = true;
                result.Messages = listMsg;
                return result;
            }

            var data = new JurosCompostosViewModel()
            {
                ValorInicial = valorInicial,
                Meses = tempo,
                JurosCompostosCalculado = jurosCalculado.JurosCompostosCalculado,
                TaxaJuros = jurosCalculado.TaxaJuros
            };

            result.Data = data;
            result.Error = false;

            return result;
        }

        private IList<ValidationMessageBase> ValidarParametrosJurosCompostos(decimal? valorInicial, int? tempo)
        {
            var messages = new List<ValidationMessageBase>();
            if(!valorInicial.HasValue || (valorInicial.HasValue && valorInicial.Value <= 0))
            {
                messages.Add(new ValidationMessageBase() { Message = "O valor inicial é obrigatório e deve ser maior que 0." });
            }

            if (!tempo.HasValue || (tempo.HasValue && tempo.Value <= 0))
            {
                messages.Add(new ValidationMessageBase() { Message = "O tempo é obrigatório e deve ser maior que 0." });
            }

            return messages;
        }
    }
}
