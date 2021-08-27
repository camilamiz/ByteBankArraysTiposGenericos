using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ByteBank.SistemaAgencia.Extensoes
{
    public static class ListExtensoes
    {
        //quando tenho uma classe estática, só posso ter membros estáticos
        //o this está sendo usado para ser um método de extensão, deste modo, consigo chamar
        //idades.AdicionarVarios() ao invés de ListExtensoes.AdicionarVarios();
        //public static void AdicionarVarios(this List<int> listaDeInteiros, params int[] itens)
        //{
        //    foreach (int item in itens)
        //    {
        //        listaDeInteiros.Add(item);
        //    }
        //}

        //vamos tornar a List genérica para tipos, não apenas int como havíamos feito
        public static void AdicionarVarios<T>(this List<T> lista, params T[] itens)
        {
            foreach (T item in itens)
            {
                lista.Add(item);
            }
        }

        public static void TesteGenerico<T2>(this string texto)
        {

        }

        static void Teste()
        {
            List<int> idades = new List<int>();
            idades.Add(14);
            idades.Add(26);
            idades.Add(60);

            idades.AdicionarVarios(54, 53, 77, 12);

            string guilherme = "Guilherme";
            guilherme.TesteGenerico<int>();

            List<string> nomes = new List<string>();
            nomes.Add("Guilhreme");
        }
    }
}
