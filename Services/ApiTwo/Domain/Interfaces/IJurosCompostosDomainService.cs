using ApiTwo.Domain.Models;
using System.Threading.Tasks;

namespace ApiTwo.Domain.Interfaces
{
    public interface IJurosCompostosDomainService
    {
        Task<JurosCompostosValueObject> CalcularJurosCompostos(double valorInicial, int tempo);
    }
}
