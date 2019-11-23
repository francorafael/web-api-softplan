using ApiTwo.Application.Base;
using ApiTwo.Application.Services.AppJurosCompostos.ViewModel;
using System.Threading.Tasks;

namespace ApiTwo.Application.Interfaces
{
    public interface IJurosCompostosAppService
    {
        Task<JsonResultBase<JurosCompostosViewModel>> CalcularJurosCompostos(decimal valorInicial, int tempo);
    }
}
