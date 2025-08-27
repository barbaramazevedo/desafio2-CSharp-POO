using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Desafio2
{
    internal class ContaBancaria
    {
        private static List<ContaBancaria> todasContas = new List<ContaBancaria>();
        private List<Movimentacao> extrato = new List<Movimentacao>();
        public string Titular { get; set; }
        public double Saldo { get; private set; }
        public string NumeroConta { get; set; }
        public double TaxaJuros { get; set; }

        public ContaBancaria(string titular, string numeroConta, double saldoInicial = 0, double taxaJuros = 0)
        {
            Titular = titular;
            NumeroConta = numeroConta;
            Saldo = saldoInicial;
            TaxaJuros = taxaJuros;

            todasContas.Add(this);
            RegistrarMovimentacao("Abertura de conta", saldoInicial);
        }

        private void RegistrarMovimentacao(string tipo, double valor)
        {
            var movimentacao = new Movimentacao(DateTime.Now, tipo, valor, Saldo);
            extrato.Add(movimentacao);
        }
        public static void ExibirRelatorio()
        {
            double saldoTotal = 0;
            Console.WriteLine("\n=== Relatório de Contas ===");
            foreach (var conta in todasContas)
            {
                Console.WriteLine($"Titular: {conta.Titular} | Conta: {conta.NumeroConta} | Saldo: {conta.Saldo:C}");
                saldoTotal += conta.Saldo;
            }
            Console.WriteLine($"Saldo total agregado: {saldoTotal:C}");
        }

        public void Depositar(double valor)
        {
            if (valor > 0)
            {
                Saldo += valor;
                RegistrarMovimentacao("Depósito", valor);
                Console.WriteLine($"Depósito de {valor:C} realizado com sucesso. Novo saldo: {Saldo:C}");
            }
            else
            {
                Console.WriteLine("O valor do depósito deve ser positivo.");
            }
        }

        public void Sacar(double valor)
        {
            if (valor > 0 && valor <= Saldo)
            {
                Saldo -= valor;
                RegistrarMovimentacao("Saque", -valor);
                Console.WriteLine($"Saque de {valor:C} realizado com sucesso. Novo saldo: {Saldo:C}");
            }
            else if (valor > Saldo)
            {
                Console.WriteLine("Saldo insuficiente para o saque.");
            }
            else
            {
                Console.WriteLine("O valor do saque deve ser positivo.");
            }
        }

        public void ExibirSaldo()
        {
            Console.WriteLine($"Saldo atual de {Titular} (Conta: {NumeroConta}): {Saldo:C}");
        }

        public void Transferir(ContaBancaria contaDestino, double valor)
        {
            if (valor > 0 && valor <= Saldo)
            {
                Saldo -= valor;
                contaDestino.Depositar(valor);
                RegistrarMovimentacao($"Transferência enviada para {contaDestino.Titular}", -valor);
                Console.WriteLine($"Transferência de {valor:C} para {contaDestino.Titular} realizada com sucesso. Novo saldo: {Saldo:C}");
            }
            else if (valor > Saldo)
            {
                Console.WriteLine("Saldo insuficiente para a transferência.");
            }
            else
            {
                Console.WriteLine("O valor da transferência deve ser positivo.");
            }
        }

        public void AplicarJuros()
        {
            if (TaxaJuros > 0)
            {
                double juros = Saldo * TaxaJuros / 100;
                Saldo += juros;
                RegistrarMovimentacao("Aplicação de juros", juros);
                Console.WriteLine($"Taxa de juros de {TaxaJuros}% aplicada para {Titular}. Juros: {juros:C}. Novo saldo: {Saldo:C}");
            }
            else
            {
                Console.WriteLine($"Conta de {Titular} não possui taxa de juros.");
            }
        }

        public static void AplicarJurosTodasContas()
        {
            Console.WriteLine("\n=== Aplicando juros em todas as contas ===");
            foreach (var conta in todasContas)
            {
                conta.AplicarJuros();
            }
        }

        public static void VerificarContasNegativas()
        {
            foreach (var conta in todasContas)
            {
                if (conta.Saldo < 0)
                {
                    Console.WriteLine($"A conta de {conta.Titular} está negativada. Saldo: {conta.Saldo:C}");
                }
            }
        }

         public void ExibirExtrato(int dias)
        {
            Console.WriteLine($"\n=== Extrato dos últimos {dias} dias para {Titular} ===");
            DateTime limite = DateTime.Now.AddDays(-dias);
            var movimentacoesFiltradas = extrato.FindAll(m => m.Data >= limite);

            if (movimentacoesFiltradas.Count == 0)
            {
                Console.WriteLine("Nenhuma movimentação nesse período.");
                return;
            }

            foreach (var mov in movimentacoesFiltradas)
            {
                Console.WriteLine($"{mov.Data:G} | {mov.Tipo,-30} | Valor: {mov.Valor,8:C} | Saldo: {mov.SaldoPosterior,8:C}");
            }
        }
    }
}
