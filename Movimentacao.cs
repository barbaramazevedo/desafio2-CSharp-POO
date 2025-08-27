using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Desafio2
{
    internal class Movimentacao
    {
        public DateTime Data { get; set; }
        public string Tipo { get; set; }
        public double Valor { get; set; }
        public double SaldoPosterior { get; set; }
        public Movimentacao(DateTime data, string tipo, double valor, double saldoPosterior)
        {
            Data = data;
            Tipo = tipo;
            Valor = valor;
            SaldoPosterior = saldoPosterior;
        }
    }
}
