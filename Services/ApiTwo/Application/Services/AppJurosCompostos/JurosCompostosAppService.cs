using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiTwo.Application.Base;
using ApiTwo.Application.Interfaces;
using ApiTwo.Application.Services.AppJurosCompostos.ViewModel;
using ApiTwo.Domain.Interfaces;

namespace ApiTwo.Application.Services.AppJurosCompostos
{
    public class JurosCompostosAppService: IJurosCompostosAppService
    {
        private readonly IJurosCompostosDomainService _jurosCompostosDomainService;

        public JurosCompostosAppService(IJurosCompostosDomainService jurosCompostosDomainService)
        {
            _jurosCompostosDomainService = jurosCompostosDomainService;
        }

        public async Task<JsonResultBaseViewModel<JurosCompostosViewModel>> CalcularJurosCompostos(double valorInicial, int tempo)
        {
            var result = new JsonResultBaseViewModel<JurosCompostosViewModel>();
            var validarParametros = ValidarParametrosJurosCompostos(valorInicial, tempo);
            
            if (validarParametros.Any())
            {
                result.Data = null;
                result.Error = true;
                result.Messages = validarParametros;
                return result;
            }

            var jurosCalculado = await _jurosCompostosDomainService.CalcularJurosCompostos(valorInicial, tempo);

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

            var data = new JurosCompostosViewModel() { Valor = jurosCalculado.Valor };
            result.Data = data;
            result.Error = false;

            return result;
        }

        private IList<ValidationMessageBase> ValidarParametrosJurosCompostos(double? valorInicial, int? tempo)
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
