using System.Globalization;

namespace ApiTwo.Application.Services.AppJurosCompostos.ViewModel
{
    public class JurosCompostosViewModel
    {
        public decimal TaxaJuros { get; set; }
        public decimal ValorInicial { get; set; }
        public int Meses { get; set; }
        public decimal JurosCompostosCalculado { get; set; }
        public string JurosCompostosCalculadoFormatoBrasil => ConverterJurosCalculadoFormatoBR();

        public string ConverterJurosCalculadoFormatoBR()
        {
            return JurosCompostosCalculado.ToString(CultureInfo.CreateSpecificCulture("pt-BR"));
        }
    }
}
