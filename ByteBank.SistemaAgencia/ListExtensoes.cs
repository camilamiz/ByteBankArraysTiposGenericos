using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ByteBank.SistemaAgencia
{
    public static class ListExtensoes
    {
        //quando tenho uma classe estática, só posso ter membros estáticos
        //o this está sendo usado para ser um método de extensão, deste modo, consigo chamar
        //idades.AdicionarVarios() ao invés de ListExtensoes.AdicionarVarios();
        public static void AdicionarVarios(this List<int> listaDeInteiros, params int[] itens)
        {
            foreach (int item in itens)
            {
                listaDeInteiros.Add(item);
            }
        }
    }
}
