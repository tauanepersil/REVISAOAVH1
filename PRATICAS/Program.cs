using EstruturaPilha.Entidades;
using System;

namespace EstruturaPilha
{
    class Program
    {
        static void Main(string[] args)
        {
            Questao8Revisao();
            Console.ReadLine();
        }

        public static void Questao8Revisao()
        {
            Console.WriteLine("Digite o número na base10 que vc deseja converter: ");
            int numeroBase10 = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite para qual base que vc deseja converter: ");
            int baseParaConverter = int.Parse(Console.ReadLine());

            var pilhaResultados = new PilhaDinamica();
            int quociente = numeroBase10;
            int resto = 0;
            while(quociente != 0)
            {
                resto = quociente % baseParaConverter;
                quociente = (quociente - resto) / baseParaConverter;
                pilhaResultados.Empilha(resto);
            }

            var listaPops = pilhaResultados.MultiPop(pilhaResultados.Tamanho());
            Console.WriteLine("Resultado da Operação é: ");
            foreach(var item in listaPops){
                Console.Write(item);
            }
            Console.WriteLine();
            Console.WriteLine("Deu bão! :)");
        }

        public static void Questao7Revisao()
        {
            var p = new PilhaEstatica();
            p.Empilha(1);
            p.Empilha(2);
            p.Empilha(3);
            p.Empilha(4);
            p.Empilha(5);
            p.Empilha(6);
            var listaPops = p.MultiPop(6);
            foreach(var item in listaPops){
                Console.WriteLine(item);
            }
        }

        public static void SegundoExercicioLista2()
        {
            Console.WriteLine("Digite o seu texto abaixo, apenas os 30 primeiros caracteres serão considerados: ");
            var texto = Console.ReadLine();

            if (texto.Length > 30)
                texto = texto.Substring(0, 30);

            var pilha = new PilhaParenteses();

            foreach (var caractere in texto)
            {
                if (caractere == '(')
                {
                    pilha.Empilha(caractere);
                }
                else if (caractere == ')')
                {
                    if (pilha.EstaVazia())
                    {
                        Console.WriteLine("Texto inválido");
                        return;
                    }
                    pilha.Desempilha();
                }
            }

            if (pilha.EstaVazia())
                Console.WriteLine("Texto válido");
            else
                Console.WriteLine("Texto inválido");
        }

        public static void PrimeiroExercicioLista1()
        {
            PilhaEstatica p = new PilhaEstatica();
            PilhaEstatica x = new PilhaEstatica();
            // PilhaDinamica p = new PilhaDinamica();
            bool flVazia = p.EstaVazia();
            p.Empilha(1);
            p.Empilha(2);
            p.Empilha(3);
            x.Empilha(1);
            x.Empilha(2);
            x.Empilha(3);
            var numeros = p.RetornaTodosElementos();
            int maior = p.MaiorElemento();
            int menor = p.MenorElemento();
            float media = p.Media();

            bool compare = p.Igual(x);

            foreach (int num in numeros)
            {
                Console.WriteLine(num);
            }
            Console.ReadLine();
            p.Desempilha();
            Console.WriteLine("E agora");
            numeros = p.RetornaTodosElementos();
            foreach (int num in numeros)
            {
                Console.WriteLine(num);
            }
        }
    }
}
