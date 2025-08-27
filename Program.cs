namespace Desafio2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ContaBancaria contaBarbara = new ContaBancaria("Bárbara Azevedo", "N54632", 50.00, 2.5);
            ContaBancaria contaFabiana = new ContaBancaria("Fabiana Azevedo", "N56132", -20.00, 2.5);

            contaBarbara.Depositar(150.00);
            contaBarbara.ExibirSaldo();

            contaBarbara.Sacar(70.00);
            contaBarbara.ExibirSaldo();
            ContaBancaria contaVictoria = new ContaBancaria("Victoria Azevedo", "N54631", 100.00, 3.0);
            contaVictoria.Transferir(contaBarbara, 30.00);
            contaBarbara.ExibirSaldo();
            contaVictoria.ExibirSaldo();

            ContaBancaria.ExibirRelatorio();
            ContaBancaria.AplicarJurosTodasContas();
            ContaBancaria.ExibirRelatorio();
            ContaBancaria.VerificarContasNegativas();

            contaBarbara.ExibirExtrato(30);
            contaFabiana.ExibirExtrato(60);
            contaVictoria.ExibirExtrato(90);
        }
    }
}
