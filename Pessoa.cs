using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Desafio2
{
    internal class Pessoa
    {
        public string Nome { get; set; }
        public int Idade { get; set; }
        public string Profissao { get; set; }

        public List<Carro> Carros { get; set; } = new List<Carro>();

        public Pessoa(string nome, int idade, string profissao)
        {
            Nome = nome;
            Idade = idade;
            Profissao = profissao;
        }

        public void AdquirirCarro(Carro carro)
        {
            Carros.Add(carro);
            Console.WriteLine($"{Nome} adquiriu um {carro.Marca} {carro.Modelo} ({carro.Ano}).");
        }

        public void ListarCarros()
        {
            if (Carros.Count == 0)
            {
                Console.WriteLine($"{Nome} não possui carros.");
                return;
            }

            Console.WriteLine($"\n{Nome} possui:");
            foreach (var c in Carros)
            {
                Console.WriteLine($"{c.Marca} {c.Modelo} ({c.Ano})");
            }
        
        }
    }
}
