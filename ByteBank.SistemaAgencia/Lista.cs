using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ByteBank.SistemaAgencia
{
    //Indica uma lista de tipos
    //O T indica todos os lugares em que o tipo será substituído, é um tipo genérico
    //Se colocarmos int, por exemplo, o tipo dessa lista será int
    public class Lista<T>
    {
        private T[] _itens;
        private int _proximaPosicao;

        public int Tamanho
        {
            get
            {
                return _proximaPosicao;
            }
        }

        public Lista(int capacidadeInicial = 5)
        {
            _itens = new T[capacidadeInicial];
            _proximaPosicao = 0;
        }

        public void Adicionar(T item)
        {
            VerificarCapacidade(_proximaPosicao + 1);

            //Console.WriteLine($"Adicionando item na posição {_proximaPosicao}.");
            _itens[_proximaPosicao] = item;
            _proximaPosicao++;
        }

        //parms possibilita chamar o método com vários argumentos
        public void AdicionarVarios(params T[] itens)
        {
            foreach (T item in itens)
            {
                Adicionar(item);
            }
        }

        public void Remover(T item)
        {
            int indiceItem = -1; //para sinalizar que é um valor inválido

            for (int i = 0; i < _proximaPosicao; i++)
            {
                //Equals sobrescrito, não é o padrão
                if (_itens[i].Equals(item))
                {
                    indiceItem = i;
                    break;
                }
            }

            for (int i = indiceItem; i < _proximaPosicao; i++)
            {
                _itens[i] = _itens[i + 1];
            }

            _proximaPosicao--;

            //_itens[_proximaPosicao] = null;
            //um int, ou bool, sempre apontam para um valor, não faz sentido serem nulos pois são tipos de valor
            //se for ContaCorrente conta = null, isso é aceitável, pois é um tipo de referência
        }

        public T GetItemNoIndice(int indice)
        {
            if (indice < 0 || indice >= _proximaPosicao)
            {
                throw new ArgumentOutOfRangeException(nameof(indice));
            }

            return _itens[indice];
        }

        public void EscreverListaNaTela()
        {
            for (int i = 0; i < _proximaPosicao; i++)
            {
                T item = _itens[i];
                //Console.WriteLine($"Conta numero #{i}: {conta.Agencia} {conta.Numero}");
            }
        }

        private void VerificarCapacidade(int tamanhoNecessario)
        {
            if (_itens.Length >= tamanhoNecessario)
            {
                return;
            }

            int novoTamanho = _itens.Length * 2;
            if (novoTamanho < tamanhoNecessario)
            {
                novoTamanho = tamanhoNecessario;
            }

            //Console.WriteLine("Aumentando capacidade da lista!");
            T[] novoArray = new T[novoTamanho];

            for (int i = 0; i < _itens.Length; i++)
            {
                novoArray[i] = _itens[i];
                //Console.WriteLine("."); 
                //para mostrar que temos que percorrer a lista inteira para adicionar um novo item
            }

            _itens = novoArray;
        }

        //Criando um indexador
        public T this[int indice]
        {
            get
            {
                return GetItemNoIndice(indice);
            }
        }
    }
}
