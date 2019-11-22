using ApiTwo.Application.Base;
using ApiTwo.Application.Services.AppJurosCompostos.ViewModel;
using System.Threading.Tasks;

namespace ApiTwo.Application.Interfaces
{
    public interface IJurosCompostosAppService
    {
        Task<JsonResultBaseViewModel<JurosCompostosViewModel>> CalcularJurosCompostos(double valorInicial, int tempo);
    }
}
