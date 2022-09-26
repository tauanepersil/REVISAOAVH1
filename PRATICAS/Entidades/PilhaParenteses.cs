using System;
using System.Collections.Generic;
using EstruturaPilha.Interfaces;

namespace EstruturaPilha.Entidades
{
    public class PilhaParenteses : IPilha<char>
    {
        private readonly char[] VetorElementos;
        private readonly int TamanhoMaximo = 30;
        private int Indice;

        public PilhaParenteses()
        {
            VetorElementos = new char[TamanhoMaximo];
            Indice = 0;
        }

        public char Desempilha()
        {
            if (EstaVazia())
                throw new InvalidOperationException("Pilha Vazia, operação não pode ser " +
                    "realizada");

            return VetorElementos[--Indice];
        }

        public void Empilha(char obj)
        {
            if (Indice == TamanhoMaximo)
                throw new InvalidOperationException("Pilha Cheia, operação não pode ser" +
                    " realizada");
            VetorElementos[Indice] = obj;
            Indice++;
        }

        public IEnumerable<char> RetornaTodosElementos()
        {
            for (int i = Indice - 1; i >= 0; i--)
            {
                yield return VetorElementos[i];
            }
        }

        public int Tamanho()
        {
            return Indice;
        }

        public char Topo()
        {
            if (EstaVazia())
                throw new InvalidOperationException("Exceção: Pilha Vazia");
            return VetorElementos[Indice - 1];
        }

        public bool EstaVazia()
        {
            return Indice == 0;
        }

        public IEnumerable<char> Esvaziar()
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

        public IEnumerable<char> MultiPop(int k)
        {
            if(k > Tamanho() + 1)
                throw new InvalidOperationException("A pilha possui menos itens do que a quantidade" +
                    "solicitada. Operacao não realizada");

            var itensRemovidos = new char[k];
            for(int i = 0; i < k; i++)
            {
                itensRemovidos[i] = Desempilha();
            }

            return itensRemovidos;
        }

    }
}
