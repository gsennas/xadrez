using System;
using xadrez.tabuleiro;

namespace xadrez
{
    class Program
    {
        static void Main(string[] args)
        {
            Posicao P = new Posicao(3, 4);
            Console.WriteLine("Posicao:" + P);
            Tabuleiro tabuleiro = new Tabuleiro(8, 8);
            Tela.ImprimirTabuleiro(tabuleiro);
        }
    }
}
