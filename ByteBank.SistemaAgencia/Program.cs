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
            Lista<int> idades = new Lista<int>();

            //não funciona mais. Agora só podemos adicionar int!
            //Isso resolve o problema que antes tínhamos na classe ListaDeObject, que aceitava qualquer tipo
            //idades.Adicionar("string qualquer");
            idades.Adicionar(5);
            idades.AdicionarVarios(7, 14, 55, 35, 90);

            for (int i = 0; i < idades.Tamanho; i++)
            {
                //não foi necessário fazer conversão de tipo agora - (int)idades[i]
                int idadeAtual = idades[i];
            }

            Console.ReadLine();
        }

        static void TestaListaDeObject()
        {
            ListaDeObject listaDeIdades = new ListaDeObject();


            listaDeIdades.AdicionarVarios(16, 23, 60);

            for (int i = 0; i < listaDeIdades.Tamanho; i++)
            {
                int idade = (int)listaDeIdades[i];
                Console.WriteLine($"Idade no índice {i}: {idade}");
            }

            Console.WriteLine(SomarVarios(12, 4, 666, 6, 22, 567));
            Console.WriteLine(SomarVarios(1, 2, 45));

            Console.ReadLine();
        }

        static void TestaListaDeContaCorrente()
        {
            ListaDeContaCorrente lista = new ListaDeContaCorrente();
            ContaCorrente contaDoGui = new ContaCorrente(1111111, 88899);

            lista.Adicionar(new ContaCorrente(874, 567822));
            lista.Adicionar(new ContaCorrente(874, 567822));
            lista.Adicionar(new ContaCorrente(874, 567822));
            lista.Adicionar(new ContaCorrente(874, 567822));
            lista.Adicionar(new ContaCorrente(874, 567822));
            lista.Adicionar(new ContaCorrente(874, 567822));
            lista.Adicionar(new ContaCorrente(874, 567822));
            lista.Adicionar(new ContaCorrente(874, 567822));
            lista.Adicionar(new ContaCorrente(874, 567822));

            lista.AdicionarVarios(
                contaDoGui,
                new ContaCorrente(111, 22222),
                new ContaCorrente(222, 33333)
                );

            //lista.EscreverListaNaTela();
            //lista.Remover(contaDoGui);
            //Console.WriteLine("Após remover o item");
            //lista.EscreverListaNaTela();

            for (int i = 0; i < lista.Tamanho; i++)
            {
                //ContaCorrente itemAtual = lista.GetItemNoIndice(i);
                //com o indexador
                ContaCorrente itemAtual = lista[i];
                Console.WriteLine($"Item na posição {i} = Conta {itemAtual.Numero}/{itemAtual.Agencia}");
            }

            Console.ReadLine();
        }

        //exemplo de params
        static int SomarVarios(params int[] numeros)
        {
            int acumulador = 0;
            foreach(int numero in numeros)
            {
                acumulador += numero;
            }
            return acumulador;
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
