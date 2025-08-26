namespace Desafio2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Pessoa pessoa1 = new Pessoa("Bárbara", 25, "Desenvolvedora");
            Pessoa pessoa2 = new Pessoa("Karina", 30, "Arquiteta");

            Carro carro1 = new Carro("Ford", "Mustang", 1969);
            Carro carro2 = new Carro("Volkswagen", "Fusca", 1970);
            Carro carro3 = new Carro("Chevrolet", "Opala", 1978);

            pessoa1.AdquirirCarro(carro1);
            pessoa1.AdquirirCarro(carro2);
            pessoa2.AdquirirCarro(carro3);

            pessoa1.ListarCarros();
            pessoa2.ListarCarros();

            Console.ReadLine();
        }
    }
}
