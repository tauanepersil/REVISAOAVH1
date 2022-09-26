using System;
using System.Collections.Generic;
using EstruturaPilha.Interfaces;

namespace EstruturaPilha.Entidades
{
    public class PilhaEstatica : IPilha<int>
    {
        private int[] VetorElementos;
        private int TamanhoMaximo = 30;
        private int Indice;

        public PilhaEstatica()
        {
            VetorElementos = new int[TamanhoMaximo];
            Indice = 0;
        }

        public PilhaEstatica(int tamanhoMaximo)
        {
            if (tamanhoMaximo < 0)
                throw new ArgumentException("tamanhoMaximo", "Tamanho não pode ser menor " +
                    "ou igual a zero");
            TamanhoMaximo = tamanhoMaximo;
            VetorElementos = new int[TamanhoMaximo];
            Indice = 0;
        }

        public int Desempilha()
        {
            if (EstaVazia())
                throw new InvalidOperationException("Pilha Vazia, operação não pode ser " +
                    "realizada");
            
            return VetorElementos[--Indice];
        }

        public void Empilha(int obj)
        {
            if (Indice == TamanhoMaximo)
                throw new InvalidOperationException("Pilha Cheia, operação não pode ser" +
                    " realizada");
            VetorElementos[Indice] = obj;
            Indice++;
        }

        public IEnumerable<int> RetornaTodosElementos()
        {
            for (int i = Indice-1; i >= 0; i--)
            {
                yield return VetorElementos[i];
            }        
        }

        public int Tamanho()
        {
            return Indice;
        }

        public int Topo()
        {
            if (EstaVazia())
                throw new InvalidOperationException("Exceção: Pilha Vazia");
            return VetorElementos[Indice-1];
        }

        public bool EstaVazia()
        {
            return Indice == 0;
        }

        public int MaiorElemento()
        {
            if (EstaVazia())
                throw new InvalidOperationException("Exceção: Pilha Vazia");

            int maior = VetorElementos[Indice - 1];
            for (int i = Indice - 2; i >= 0; i--)
            {
                if (maior < VetorElementos[i])
                    maior = VetorElementos[i];
            }
            return maior;
        }

        public int MenorElemento()
        {
            if (EstaVazia())
                throw new InvalidOperationException("Exceção: Pilha Vazia");

            int menor = VetorElementos[Indice - 1];
            for (int i = Indice - 2; i >= 0; i--)
            {
                if (menor > VetorElementos[i])
                    menor = VetorElementos[i];
            }
            return menor;
        }


        public float Media()
        {
            if (EstaVazia())
                return 0;

            int soma = 0;
            for (int i = Indice - 1; i >= 0; i--)
            {
                soma += VetorElementos[i];
            }
            return soma/ Indice;
        }

        public bool Igual(PilhaEstatica p)
        {
            if (Tamanho() != p.Tamanho())
                return false;
            for (int i = Indice - 1; i >= 0; i--)
            {
                if (VetorElementos[i] != p.VetorElementos[i])
                    return false;
            }            
            return true;
        }

        public IEnumerable<int> Esvaziar()
        {
            int tamanho = Tamanho();
            if (EstaVazia())
                throw new NotImplementedException("Pilha vazia, operação " +
                    "não realizada");
            for (int i = 0; i < tamanho; i++)
            {
                yield return Desempilha();
            }
        }

        public IEnumerable<int> MultiPop(int k)
        {
            if(k > Tamanho() + 1)
                throw new InvalidOperationException("A pilha possui menos itens do que a quantidade" +
                    "solicitada. Operacao não realizada");

            var itensRemovidos = new int[k];
            for(int i = 0; i < k; i++)
            {
                itensRemovidos[i] = Desempilha();
            }

            return itensRemovidos;
        }
    }
}
