using System;
using xadrez.tabuleiro;
using xadrez.Xadrez;

namespace xadrez
{
    class Program
    {
        static void Main(string[] args)
        {
            /*t
           PosicaoXadrez pos = new PosicaoXadrez('c', 7);
           Console.WriteLine( pos);
           Console.WriteLine(pos.toPosicao());
            */
            try
            {

                PartidaXadrez partida = new PartidaXadrez();
                while (!partida.Terminada)
                {
                    Console.Clear();
                    Tela.ImprimirTabuleiro(partida.tab);
                    Console.WriteLine("\nOrigem");
                    Posicao origem = Tela.LerPosicaoXadrez().toPosicao();
                    Console.Clear();
                    bool[,] posicoesPossiveis = partida.tab.Peca(origem).MovimentoPossivel();
                    Tela.ImprimirTabuleiro(partida.tab, posicoesPossiveis);
                    Console.WriteLine("Destino");
                    Posicao destino = Tela.LerPosicaoXadrez().toPosicao();
                    partida.ExecutaMovimento(origem, destino);
                }
            }
               
            catch (TabuleiroExeption e)
            {
                Console.WriteLine(e.Message);
            }
        }


    }
}
