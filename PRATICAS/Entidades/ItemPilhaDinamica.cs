using System;
using System.Collections.Generic;
using System.Text;

namespace EstruturaPilha.Entidades
{
    public class ItemPilhaDinamica
    {
        public int Valor { get; private set; }
        public ItemPilhaDinamica PonteiroAnterior { get; private set; }
        public ItemPilhaDinamica(int valor, ItemPilhaDinamica ponteiroAnterior)
        {
            Valor = valor;
            PonteiroAnterior = ponteiroAnterior;
        }
    }
}