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
                    try
                    {
                        Console.Clear();
                        Tela.ImprimirPartida(partida);
                        Console.WriteLine("\nOrigem");
                        Posicao origem = Tela.LerPosicaoXadrez().toPosicao();
                        partida.ValidarPosicaoOrigem(origem);
                        Console.Clear();
                        bool[,] posicoesPossiveis = partida.tab.Peca(origem).MovimentoPossivel();
                        Tela.ImprimirTabuleiro(partida.tab, posicoesPossiveis);
                        Console.WriteLine("\nDestino");
                        Posicao destino = Tela.LerPosicaoXadrez().toPosicao();
                        partida.ValidarPosicaoDestino(origem, destino);
                        partida.RealizaJogada(origem, destino);
                    }
                    catch (TabuleiroExeption e)
                    {
                        Console.WriteLine(e.Message);
                        Console.ReadLine();
                    }
                }
                Tela.ImprimirPartida(partida);


            }
               
            catch (TabuleiroExeption e)
            {
                Console.WriteLine(e.Message);
            }
        }


    }
}
