using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiTwo.Application.Base;
using ApiTwo.Application.Interfaces;
using ApiTwo.Application.Services.AppJurosCompostos.Input;
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

        public async Task<JsonResultBase<JurosCompostosViewModel>> CalcularJurosCompostos(JurosCompostosInput input)
        {
            var result = new JsonResultBase<JurosCompostosViewModel>();
         
            var validarParametros = ValidarParametrosJurosCompostos(input.ValorInicial, input.Meses);
            
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
                Meses = input.Meses,
                ValorInicial = input.ValorInicial
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
                ValorInicial = input.ValorInicial,
                Meses = input.Meses,
                JurosCompostosCalculado = jurosCalculado.JurosCompostosCalculado,
                TaxaJuros = jurosCalculado.TaxaJuros
            };

            result.Data = data;
            result.Error = false;

            return result;
        }

        private IList<ValidationMessageBase> ValidarParametrosJurosCompostos(decimal? valorInicial, int? meses)
        {
            var messages = new List<ValidationMessageBase>();
            if(!valorInicial.HasValue || (valorInicial.HasValue && valorInicial.Value <= 0))
            {
                messages.Add(new ValidationMessageBase() { Message = "O valor inicial é obrigatório e deve ser maior que 0." });
            }

            if (!meses.HasValue || (meses.HasValue && meses.Value <= 0))
            {
                messages.Add(new ValidationMessageBase() { Message = "A quantidade de meses é obrigatório e deve ser maior que 0." });
            }

            return messages;
        }
    }
}
