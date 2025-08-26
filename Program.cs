namespace Desafio2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Retangulo retangulo = new Retangulo(5.5, 10.2);

            Console.WriteLine($"Retângulo com largura de {retangulo.Largura} e altura de {retangulo.Altura}");
            Console.WriteLine($"Área: {retangulo.CalcularArea():F2}");
            Console.WriteLine($"Perímetro: {retangulo.CalcularPerimetro():F2}");
        }
    }
}
