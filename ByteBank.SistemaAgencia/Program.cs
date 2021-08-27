using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ByteBank.Modelos;
using ByteBank.Modelos.Funcionarios;

namespace ByteBank.SistemaAgencia
{
    class Program
    {
        static void Main(string[] args)
        {
            ListaDeContaCorrente lista = new ListaDeContaCorrente();
            lista.Adicionar(new ContaCorrente(874, 567888));
            lista.Adicionar(new ContaCorrente(874, 567899));
            lista.Adicionar(new ContaCorrente(874, 567822));
            lista.Adicionar(new ContaCorrente(874, 567822));
            lista.Adicionar(new ContaCorrente(874, 567822));
            lista.Adicionar(new ContaCorrente(874, 567822));
            lista.Adicionar(new ContaCorrente(874, 567822));
            lista.Adicionar(new ContaCorrente(874, 567822));
            lista.Adicionar(new ContaCorrente(874, 567822));
            lista.Adicionar(new ContaCorrente(874, 567822));
            lista.Adicionar(new ContaCorrente(874, 567822));

            Console.ReadLine();
        }

        static void TestaArrayInt()
        {
            int[] idades = new int[5];
            idades[0] = 15;
            idades[1] = 28;
            idades[2] = 35;
            idades[3] = 50;
            idades[4] = 28;

            int acumulador = 0;

            for (int i = 0; i < idades.Length - 1; i++)
            {
                int idade = idades[i];
                acumulador += idade;
            }

            int media = acumulador / idades.Length;
            Console.WriteLine(media);

            Console.ReadLine();
        }

        static void TestaArrayDeContaCorrente()
        {
            ContaCorrente[] contas = new ContaCorrente[]
                {
                    new ContaCorrente(874, 5677878),
                    new ContaCorrente(874, 5677844),
                    new ContaCorrente(874, 5677855),
                };

            for (int i = 0; i < contas.Length; i++)
            {
                ContaCorrente contaAtual = contas[i];
                Console.WriteLine($"Conta {i} {contaAtual.Numero}");
            }
            Console.ReadLine();
        }
    }
}
