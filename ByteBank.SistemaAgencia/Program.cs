using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ByteBank.Modelos;
using ByteBank.Modelos.Funcionarios;
using ByteBank.SistemaAgencia.Comparadores;
using ByteBank.SistemaAgencia.Extensoes;

namespace ByteBank.SistemaAgencia
{
    class Program
    {
        static void Main(string[] args)
        {
            var contas = new List<ContaCorrente>()
            {
                new ContaCorrente(99999, 57480),
                new ContaCorrente(1, 11111),
                null,
                new ContaCorrente(340, 48480),
                new ContaCorrente(340, 999999),
                null,
                new ContaCorrente(290, 18480),
                null
            };

            //IComparable na classe ContaCorrente
            //contas.Sort();
            //IComparer
            //contas.Sort(new ComparadorContaCorrentePorAgencia());

            //O método orderby tem um retorno, por isso temos que guardar em uma variável
            //(conta => conta.Numero) - expressão lambda
            //IOrderedEnumerable<ContaCorrente> contasOrdenadas = contas.OrderBy(conta => conta.Numero);

            //IEnumerable<ContaCorrente> contasNaoNulas = contas.Where(conta => conta != null);

            ////o OrderBy não trata referências nulas, como fizemos no nosso Comparador
            ////escrevemos o orderby por completo para entendermos melhor os tipos, mas ele pode ser simplificado com o var
            ////tanto o orderby quanto o where são métodos de extenão e fazem parte da biblioteca Linq
            ////var contasOrdenadas = contasNaoNulas.OrderBy(conta =>...);
            //IOrderedEnumerable<ContaCorrente> contasOrdenadas = contasNaoNulas.OrderBy<ContaCorrente, int>(conta => 
            //    {
            //        //if (conta == null)
            //        //{
            //        //    //jogar referências nulas para o final da lista
            //        //    return int.MaxValue;
            //        //}

            //        return conta.Numero;
            //    }
            //);

            //SIMPLIFICANDO
            var contasOrdenadas = contas
                .Where(conta => conta != null)
                .OrderBy(conta => conta.Numero);

            foreach (var conta in contasOrdenadas)
            {
                //if (conta != null)
                //{
                    Console.WriteLine($"Conta número {conta.Numero}, ag. {conta.Agencia}");
                //}
            }

            Console.ReadLine();
        }

        static void TestaSort()
        {
            var nomes = new List<string>() { "Guilherme", "Luana", "Wellington", "Ana" };
            nomes.Sort();

            foreach (var nome in nomes)
            {
                Console.WriteLine(nome);
            }

            var idades = new List<int>();

            idades.Add(1);
            idades.Add(5);
            idades.Add(14);
            idades.Add(25);
            idades.Add(38);
            idades.Add(61);
            idades.Remove(25);

            idades.AdicionarVarios(99, -1);
            //ListExtensoes.AdicionarVarios(idades, 45, 89, 12);
            idades.Sort();

            for (int i = 0; i < idades.Count; i++)
            {
                Console.WriteLine(idades[i]);
            }

            Console.ReadLine();
        }

        static void TestaInferenciaDeTipoVariavel()
        {
            //usando var - fica bem mais enxuto
            //inferência de tipo de variável
            var conta = new ContaCorrente(344, 3445666);
            var gerenciador = new GerenciadorBonificacao();
            var gerenciadores = new List<GerenciadorBonificacao>();

            //não posso fazer var idade, sempre tenho que inicializar
            var idade = 14;
            var nome = "Alura";
            nome.IndexOf('u');

            var resultado = SomarVarios(1, 5, 9, 2);
            Console.WriteLine(resultado);

            Console.ReadLine();
        }

        static void TestaMetodoDeExtensao()
        {
            List<int> idades = new List<int>();
            idades.Add(1);
            idades.Add(5);
            idades.Add(14);
            idades.Add(25);
            idades.Add(38);
            idades.Add(61);
            idades.Remove(25);

            idades.AdicionarVarios(45, 89, 12);
            //ListExtensoes.AdicionarVarios(idades, 45, 89, 12);

            for (int i = 0; i < idades.Count; i++)
            {
                Console.WriteLine(idades[i]);
            }

            Console.ReadLine();
        }

        static void TestaTiposGenericos()
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
