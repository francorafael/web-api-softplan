﻿using System;

namespace ApiTwo.Domain.Models
{
    public class JurosCompostos
    {
        public decimal TaxaJuros { get; set; }
        public decimal ValorInicial { get; set; }
        public int Meses { get; set; }
        public decimal JurosCompostosCalculado => CalcularJurosCompostos();

        public decimal CalcularJurosCompostos()
        {
            var potenciacao = (decimal)Math.Pow((1 + (double)TaxaJuros), Meses);
            var juros =  ValorInicial * potenciacao;
            return decimal.Round(juros, 2);
        }
     
    }
}
